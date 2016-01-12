using System;

namespace WmMiddleware.ProductReturn.Models
{
    public class DatabaseProductReturn 
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
    }
}
