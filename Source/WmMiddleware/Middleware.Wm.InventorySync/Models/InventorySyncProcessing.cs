using System;

namespace Middleware.Wm.InventorySync.Models
{
    public class InventorySyncProcessing
    {
        public int InventorySyncProcessingId { get; set; }
        
        public int TransactionNumber { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public int ManhattanDateCreated { get; set; }

        public int ManhattanTimeCreated { get; set; }
    }
}
