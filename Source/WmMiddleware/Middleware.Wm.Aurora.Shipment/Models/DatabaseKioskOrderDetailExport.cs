using Dapper.Contrib.Extensions;

namespace Middleware.Wm.Aurora.Shipment.Models
{
    // ReSharper disable InconsistentNaming
    [Table("KioskOrderDetailExport")]
    public class DatabaseKioskOrderDetailExport
    {
        [Key]
        public int KioskOrderDetailExportId { get; set; }

        public string order_number { get; set; }
        public int internal_order_number { get; set; }
        public decimal item_number { get; set; }
        public string item_status { get; set; }
        public string style_number { get; set; }
        public string prod_size { get; set; }
        public string attribute { get; set; }
        public int qty { get; set; }
        public bool is_discountable { get; set; }
        public decimal our_price { get; set; }
        public string discount_type { get; set; }
        public decimal discount_amount { get; set; }
        public string discount_string { get; set; }
        public decimal taxable_amount { get; set; }
        public string upc_number { get; set; }
        public string isCloseout { get; set; }
        public string legal_entity { get; set; }
    }
    // ReSharper restore InconsistentNaming
}
