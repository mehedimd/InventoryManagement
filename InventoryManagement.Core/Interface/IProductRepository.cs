using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> CreateProductAsync(Product product);
    }
}
