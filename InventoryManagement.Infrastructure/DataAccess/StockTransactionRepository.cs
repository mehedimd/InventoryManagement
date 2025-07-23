using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class StockTransactionRepository : GenericRepository<StockTransaction>, IStockTransactionRepository
    {
        public StockTransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
