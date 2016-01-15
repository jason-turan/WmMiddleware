using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmMiddleware.InventorySync.Models
{
    public class InventorySyncProcessing
    {
        public int InventorySyncProcessingId { get; set; }
        
        public int TransactionNumber { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
