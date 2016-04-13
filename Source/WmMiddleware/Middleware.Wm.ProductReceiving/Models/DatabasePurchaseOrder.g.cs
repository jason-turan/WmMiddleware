using System;

// ReSharper disable once CheckNamespace
namespace Middleware.Wm.ProductReceiving.Models
{
    // ReSharper disable InconsistentNaming
    internal partial class DatabasePurchaseOrder
    {
        public string ActionCode { get; set; } //(varchar(1), null)
        public string InterfaceStatus { get; set; } //(varchar(32), null)
        public DateTime InterfaceDate { get; set; } //(datetime, null)
        public string ExternalUID { get; set; } //(varchar(17), null)
        public DateTime PODate { get; set; } //(datetime, null)
        public string FacilityNbr { get; set; } //(varchar(2), null)
        public string VendorAcct { get; set; } //(varchar(15), null)
        public decimal AmtCost { get; set; } //(decimal(19,5), null)
        public decimal DiscAvail { get; set; } //(decimal(19,5), null)
        public decimal AmtFreight { get; set; } //(decimal(19,5), null)
        public DateTime DateDue { get; set; } //(datetime, null)
        public string CreateReceiver { get; set; } //(varchar(1), null)
        public string BuyerRefNbr { get; set; } //(varchar(17), null)
        public int IDPOHeaderInterface { get; set; } //(int, null)
        public int POLineNbr { get; set; } //(int, null)
        public string SKU { get; set; } //(varchar(31), null)
        public string UPC { get; set; } //(varchar(31), null)
        public string Class { get; set; } //(varchar(10), null)
        public decimal QtyOrd { get; set; } //(decimal(19,0), null)
        public string VendorPartNbr { get; set; } //(varchar(31), null)
        public decimal Price { get; set; } //(decimal(19,5), null)
        public decimal Extension { get; set; } //(decimal(19,5), null)
        public string BuyerRef { get; set; } //(varchar(17), null)
        public string UOM { get; set; } //(varchar(10), null)
        public string SeasonYear { get; set; } //(varchar(2), null)
        public string Style { get; set; } //(varchar(7), null)
        public string Color { get; set; } //(varchar(11), null)
        public string Size { get; set; } //(varchar(11), null)
    }
    // ReSharper restore InconsistentNaming
}
