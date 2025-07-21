using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;
using InventoryManagement.Infrastructure.MyDbContext;

namespace InventoryManagement.Infrastructure.DataAccess
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
