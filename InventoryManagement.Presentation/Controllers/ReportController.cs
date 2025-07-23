using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICustomerOrderService _customerOrderService;
        public ReportController(IProductService productService, ICustomerOrderService customerOrderService)
        {
            _productService = productService;
            _customerOrderService = customerOrderService;
        }
        [HttpGet("stock/overview")]
        public async Task<IActionResult> GetStockOverview()
        {
            var result = await _productService.GetStockOverviewAsync();
            return Ok(result);
        }

        [HttpGet("top/selling/products/{topN}")]
        public async Task<IActionResult> GetTopSellingProducts(int topN = 5)
        {
            var result = await _customerOrderService.GetTopSellingProductsAsync(topN);
            return Ok(result);
        }
    }


}
