using System;

// ReSharper disable once CheckNamespace
namespace WmMiddleware.ProductReceiving.Models
{
    // ReSharper disable InconsistentNaming
    public partial class DatabasePurchaseReturn
    {
        public string Company { get; set; }
        public string Order_Number { get; set; }
        public string SKU { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public DateTime? Timestamp { get; set; }

        public decimal QtyOrd { get; set; } //(decimal(19,0), null)

        public string ExternalUid { get; set; } 
    }
}
