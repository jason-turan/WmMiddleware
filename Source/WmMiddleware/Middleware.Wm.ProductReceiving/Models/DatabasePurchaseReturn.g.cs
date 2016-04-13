using System;

// ReSharper disable once CheckNamespace
namespace Middleware.Wm.ProductReceiving.Models
{
    // ReSharper disable InconsistentNaming
    public partial class DatabasePurchaseReturn
    {
        public int rowId { get; set; }
        public string order_number { get; set; }
        public string style_number { get; set; }
        public string prod_size { get; set; }
        public string attribute { get; set; }
        public string UPC { get; set; }
        public string return_reason { get; set; }
        public string additional_return_reason { get; set; }
        public string to_be_exchange { get; set; }
        public DateTime row_submit_date { get; set; }
        public string tracking { get; set; }
        public string row_item_status { get; set; }
    }
}
