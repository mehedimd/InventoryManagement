using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Entities;

namespace InventoryManagement.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto,Product>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

            CreateMap<CustomerOrder, CustomerOrderDto>();
            CreateMap<CustomerOrderDto, CustomerOrder>();

            CreateMap<CustomerOrderDetail, CustomerOrderDetailDto>();
            CreateMap<CustomerOrderDetailDto, CustomerOrderDetail>();
        }
    }
}
