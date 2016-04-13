namespace Middleware.Wm.InventorySync.Models
{
    public class StlInventorySyncAudit
    {
        public string Status { get; set; }
        public string Upc { get; set; }
        public int Quantity { get; set; }
    }
}
