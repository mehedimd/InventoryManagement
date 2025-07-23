using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interface;

namespace InventoryManagement.Application.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _repo;
        private readonly IMapper _mapper;

        public CustomerOrderService(ICustomerOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerOrderDto>> GetAllAsync()
        {
            var orders = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<CustomerOrderDto>>(orders);
        }

        public async Task<CustomerOrderDto?> GetByIdAsync(int id)
        {
            var order = await _repo.GetByIdWithDetailsAsync(id);
            return order == null ? null : _mapper.Map<CustomerOrderDto>(order);
        }

        public async Task<CustomerOrderDto> CreateAsync(CustomerOrderDto dto)
        {
            var order = _mapper.Map<CustomerOrder>(dto);
            await _repo.CreateOrderAsync(order);
            await _repo.SaveChangesAsync();
            return _mapper.Map<CustomerOrderDto>(order);
        }

        public async Task<bool> UpdateAsync(int id, CustomerOrderDto dto)
        {
            var existing = await _repo.GetByIdWithDetailsAsync(id);
            if (existing == null) return false;

            // Map only scalar values & details if needed
            _mapper.Map(dto, existing);

            _repo.Update(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            _repo.Delete(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        // report
        public async Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int topN)
        {
            var rawData = await _repo.GetTopSellingProductsAsync(topN);

            return rawData.Select(x => new TopSellingProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TotalQuantitySold = x.TotalQuantity
            }).ToList();
        }

    }
}
