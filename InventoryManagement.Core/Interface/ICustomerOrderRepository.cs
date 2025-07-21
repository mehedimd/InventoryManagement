using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Interface
{
    public interface ICustomerOrderRepository : IGenericRepository<CustomerOrder>
    {
        Task<IEnumerable<CustomerOrder>> GetAllWithDetailsAsync();
        Task<CustomerOrder> GetByIdWithDetailsAsync(int id);
    }
}
