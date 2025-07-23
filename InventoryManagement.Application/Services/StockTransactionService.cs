using InventoryManagement.Application.Interfaces;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;

namespace InventoryManagement.Application.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _repo;
        public StockTransactionService(IStockTransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task AddStockTransactionAsync(StockTransaction tx)
        {
            await _repo.Add(tx);
            await _repo.SaveChangesAsync();
        }
    }
}
