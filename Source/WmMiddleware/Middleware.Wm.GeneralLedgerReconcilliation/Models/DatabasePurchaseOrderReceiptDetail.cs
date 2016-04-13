using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable CheckNamespace
    [Table("POReceiptDetail")]
    public class DatabasePurchaseOrderReceiptDetail
    {
        public int POReceiptHeaderID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InoviceIssueDate { get; set; }
        public string PurchaserPODate { get; set; }
        public string PONumber { get; set; }
        public string VendorOrderNumber { get; set; }
        public string termsnetdays { get; set; }
        public string termsnetdate { get; set; }
        public string TermsDiscountDueDate { get; set; }
        public string TermsDiscountDaysDue { get; set; }
        public string TermsTypeCode { get; set; }
        public string shippeddatetimereference { get; set; }
        public decimal TotalMonetaryValue { get; set; }
        public string CarrierDetailRouting { get; set; }
        public string CarrierDetailReferenceID { get; set; }
        public string ShipmentWeight { get; set; }
        public string NumberUnitsShipped { get; set; }
        public string NumberLineItems { get; set; }
        public string IntegrationStatus { get; set; }
        public string IntegrationMessage { get; set; }
        public DateTime? IntegrationDT { get; set; }
        public string IntegrationBatchID { get; set; }
        public decimal sum_po_unitcost { get; set; }
        public decimal sum_li_unitcost { get; set; }
        public string ShipToSuffix { get; set; }
        public string WeightUOM { get; set; }
        public string ShipmentBox { get; set; }
        public DateTime? DateAdded { get; set; }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore CheckNamespace
}
