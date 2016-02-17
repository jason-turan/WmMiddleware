using System;

namespace WmMiddleware.PixReturn.Models
{
    public class ReturnOnWeb
    {
        public string OrderNumber { get; set; }
        public string Company { get; set; }
        public string StockKeepingUnit { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Condition { get; set; }
        public string Reason { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
    }
}
