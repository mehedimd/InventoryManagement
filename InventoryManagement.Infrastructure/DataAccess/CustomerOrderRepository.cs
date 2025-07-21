using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class CustomerOrderRepository : GenericRepository<CustomerOrder>, ICustomerOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerOrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
