using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Interface
{
    public interface ICustomerOrderRepository : IGenericRepository<CustomerOrder>
    {
        Task<List<(int ProductId, string ProductName, int TotalQuantity)>> GetTopSellingProductsAsync(int topN);
        Task<CustomerOrder> CreateOrderAsync(CustomerOrder order);
        Task<IEnumerable<CustomerOrder>> GetAllWithDetailsAsync();
        Task<CustomerOrder> GetByIdWithDetailsAsync(int id);
    }
}
