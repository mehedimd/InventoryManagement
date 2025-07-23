using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int topN);
        Task<IEnumerable<CustomerOrderDto>> GetAllAsync();
        Task<CustomerOrderDto?> GetByIdAsync(int id);
        Task<CustomerOrderDto> CreateAsync(CustomerOrderDto dto);
        Task<bool> UpdateAsync(int id, CustomerOrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
