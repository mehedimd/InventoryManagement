namespace InventoryManagement.Application.DTOs
{
    public class StockOverviewDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string StockStatus { get; set; } // "OK", "Low".
    }
}
