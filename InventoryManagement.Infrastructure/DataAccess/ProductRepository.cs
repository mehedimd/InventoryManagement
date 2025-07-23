using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                 _context.Add(product);
                await _context.SaveChangesAsync();

                // Initial Stock Transaction
                if (product.StockQuantity > 0)
                {
                    var stockTx = new StockTransaction
                    {
                        ProductId = product.ProductId,
                        Quantity = product.StockQuantity,
                        Type = "IN",
                        Remarks = "Initial stock entry",
                        TransactionDate = DateTime.Now
                    };

                    _dbContext.Add(stockTx);
                    await _dbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return product;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
