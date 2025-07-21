using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetByIdAsync(int id);
        Task<SupplierDto> CreateAsync(SupplierDto dto);
        Task<bool> UpdateAsync(int id, SupplierDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
