using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
