namespace InventoryManagement.Core.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Navigation
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }

}
