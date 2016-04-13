using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    [Table("POReceiptDetail_LineItem")]
    public class DatabasePurchaseOrderReceiptDetailLineItem
    {
        public int PoReceiptDetailId { get; set; }
        public string LineNumber { get; set; }
        public string Upc { get; set; }
        public string Uom { get; set; }
        public string VendorStyleNumber { get; set; }
        public string QuantityInvoiced { get; set; }
        public decimal UnitPrice { get; set; }
        public int Idprhi { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
