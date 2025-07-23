using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class CustomerOrderRepository : GenericRepository<CustomerOrder>, ICustomerOrderRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public CustomerOrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerOrder> CreateOrderAsync(CustomerOrder order)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Add order
                _dbContext.CustomerOrders.Add(order);
                await _dbContext.SaveChangesAsync();

                foreach (var detail in order.CustomerOrderDetails)
                {
                    // Decrease product stock
                    var product = await _dbContext.Products.FindAsync(detail.ProductId);
                    if (product == null)
                        throw new Exception($"Product with ID {detail.ProductId} not found.");

                    if (product.StockQuantity < detail.Quantity)
                        throw new Exception($"Not enough stock for product {product.ProductName}");

                    product.StockQuantity -= detail.Quantity;

                    // Add stock transaction (OUT)
                    var stockTransaction = new StockTransaction
                    {
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        Type = "OUT",
                        Remarks = $"Customer Order ID: {order.CustomerOrderId}",
                        TransactionDate = DateTime.Now
                    };
                    _dbContext.StockTransactions.Add(stockTransaction);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<(int ProductId, string ProductName, int TotalQuantity)>> GetTopSellingProductsAsync(int topN)
        {
            var result = await _dbContext.CustomerOrderDetails
                .Include(c => c.Product)
                .GroupBy(c => new { c.ProductId, c.Product.ProductName })
                .Select(g => new
                {
                    g.Key.ProductId,
                    g.Key.ProductName,
                    TotalQuantity = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(topN)
                .ToListAsync();

            return result
                .Select(x => (x.ProductId, x.ProductName, x.TotalQuantity))
                .ToList();
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllWithDetailsAsync()
        {
            return await _dbContext.CustomerOrders
                .Include(x => x.CustomerOrderDetails)
                .ToListAsync();
        }
        public async Task<CustomerOrder> GetByIdWithDetailsAsync(int id)
        {
            return await _dbContext.CustomerOrders
                .Include(x => x.CustomerOrderDetails)
                .FirstOrDefaultAsync(x => x.CustomerOrderId == id);
        }

    }
}
