namespace InventoryManagement.Core.Entities
{
    public class CustomerOrderDetail
    {
        public int CustomerOrderDetailId { get; set; }

        public int CustomerOrderId { get; set; }
        public CustomerOrder CustomerOrder { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }

}
