using InventoryManagement.Core.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface IStockTransactionService
    {
        Task AddStockTransactionAsync(StockTransaction tx);
    }
}
