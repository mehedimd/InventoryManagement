using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public class StockTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; } // Positive or negative

        [Required]
        [MaxLength(10)]
        public string Type { get; set; } // "IN" or "OUT"

        public string? Remarks { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
