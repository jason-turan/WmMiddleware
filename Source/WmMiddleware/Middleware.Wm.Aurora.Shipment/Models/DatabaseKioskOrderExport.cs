using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.Aurora.Shipment.Models
{
    // ReSharper disable InconsistentNaming
    [Table("KioskOrderExport")]
    public class DatabaseKioskOrderExport
    {
        [Key]
        public int KioskOrderExportId { get; set; }

        public string order_number { get; set; }
        public int internal_order_number { get; set; }
        public string customerid { get; set; }
        public DateTime date_ordered { get; set; }
        public string order_status { get; set; }
        public string coupon_type { get; set; }
        public decimal coupon_amount { get; set; }
        public string coupon_code { get; set; }
        public decimal gift_amount { get; set; }
        public string gift_code { get; set; }
        public string shipping_method { get; set; }
        public decimal shipping_cost { get; set; }
        public decimal original_shipping_cost { get; set; }
        public decimal sales_tax { get; set; }
        public decimal sales_tax_rate { get; set; }
        public decimal sub_total { get; set; }
        public decimal order_total { get; set; }
        public string bill_first_name { get; set; }
        public string bill_last_name { get; set; }
        public string bill_email { get; set; }
        public string bill_telephone { get; set; }
        public string bill_address { get; set; }
        public string bill_address2 { get; set; }
        public string bill_city { get; set; }
        public string bill_state { get; set; }
        public string bill_zip { get; set; }
        public string bill_country { get; set; }
        public string ship_first_name { get; set; }
        public string ship_last_name { get; set; }
        public string ship_telephone { get; set; }
        public string ship_address { get; set; }
        public string ship_address2 { get; set; }
        public string ship_city { get; set; }
        public string ship_state { get; set; }
        public string ship_zip { get; set; }
        public string ship_country { get; set; }
        public string payment_type { get; set; }
        public string order_source { get; set; }
        public bool is_row_exchange { get; set; }
        public string auth_number { get; set; }
    }
    // ReSharper restore InconsistentNaming
}
