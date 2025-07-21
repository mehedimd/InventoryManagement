namespace InventoryManagement.Application.DTOs
{
    public class CustomerOrderDto
    {
        public int CustomerOrderId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<CustomerOrderDetailDto> CustomerOrderDetails { get; set; }
    }
}
