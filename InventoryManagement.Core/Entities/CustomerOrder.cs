namespace InventoryManagement.Core.Entities
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Navigation
        public ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    }

}
