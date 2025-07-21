namespace InventoryManagement.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }

        // Navigation
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    }

}
