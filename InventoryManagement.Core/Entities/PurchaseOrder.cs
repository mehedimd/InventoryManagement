using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public decimal TotalAmount { get; set; }

        // Navigation
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }

}
