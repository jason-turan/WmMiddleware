﻿using System;

// ReSharper disable once CheckNamespace
namespace WmMiddleware.Picking.Models
{
    // DO NOT CHANGE THE NAMES OF PROPERTIES IN THIS CLASS
    // ReSharper disable InconsistentNaming
    public partial class DatabasePickTicket
    {
        public int HeaderId { get; set; } //(int, not null)
        public string Company { get; set; } //(varchar(10), not null)
        public string OrderNumber { get; set; } //(varchar(15), not null)
        public DateTime OrderDate { get; set; } //(smalldatetime, not null)
        public DateTime HeaderDownloadDate { get; set; } //(smalldatetime, not null)
        public string CustomerNumber { get; set; } //(varchar(10), not null)
        public string OrderPriority { get; set; } //(varchar(4), not null)
        public string BillingName { get; set; } //(varchar(64), not null)
        public string BillingAddress1 { get; set; } //(varchar(60), not null)
        public string BillingAddress2 { get; set; } //(varchar(60), not null)
        public string BillingAddress3 { get; set; } //(varchar(60), not null)
        public string BillingCity { get; set; } //(varchar(35), not null)
        public string BillingState { get; set; } //(varchar(29), not null)
        public string BillingZip { get; set; } //(varchar(10), not null)
        public string BillingCountry { get; set; } //(varchar(60), not null)
        public string BillingPhone { get; set; } //(varchar(14), not null)
        public string ShippingName { get; set; } //(varchar(64), not null)
        public string ShippingAddress1 { get; set; } //(varchar(60), not null)
        public string ShippingAddress2 { get; set; } //(varchar(60), not null)
        public string ShippingAddress3 { get; set; } //(varchar(60), not null)
        public string ShippingCity { get; set; } //(varchar(35), not null)
        public string ShippingState { get; set; } //(varchar(29), not null)
        public string ShippingZip { get; set; } //(varchar(10), not null)
        public string ShippingCountry { get; set; } //(varchar(60), not null)
        public string ShippingPhone { get; set; } //(varchar(14), not null)
        public string EmailAddress { get; set; } //(varchar(60), not null)
        public string TransactionType { get; set; } //(varchar(6), not null)
        public string ShippingMethod { get; set; } //(varchar(20), not null)
        public double Subtotal { get; set; } //(float, not null)
        public double Discount { get; set; } //(float, not null)
        public double Freight { get; set; } //(float, not null)
        public double MiscHandling { get; set; } //(float, not null)
        public double TaxAmount { get; set; } //(float, not null)
        public double Total { get; set; } //(float, not null)
        public int OriginalOrder { get; set; } //(int, not null)
        public string PaymentOnly { get; set; } //(varchar(3), not null)
        public string HeaderGPStatus { get; set; } //(varchar(10), not null)
        public string ShippingNote { get; set; } //(nvarchar(90), null)
        public string GiftMessage1 { get; set; } //(varchar(100), null)
        public string GiftMessage2 { get; set; } //(varchar(100), null)
        public string OrderSource { get; set; } //(varchar(50), null)
        public string PaymentApplied { get; set; } //(varchar(50), not null)
        public DateTime HeaderDISDownloadedWhen { get; set; } //(smalldatetime, not null)
        public bool HeaderDISDownloadReady { get; set; } //(bit, not null)
        public int HeaderDISRowDownloaded { get; set; } //(int, not null)
        public double ItemNumber { get; set; } //(float, null)
        public string ItemSKU { get; set; } //(varchar(30), null)
        public string ItemDescription { get; set; } //(varchar(100), null)
        public int Quantity { get; set; } //(int, null)
        public string UnitsOfMeasure { get; set; } //(varchar(8), null)
        public double EachPrice { get; set; } //(float, null)
        public double ItemDiscount { get; set; } //(float, null)
        public double ExtendedPrice { get; set; } //(float, null)
        public string ItemComments { get; set; } //(varchar(500), null)
        public string InventoryType { get; set; } //(varchar(10), null)
        public string ReturnTo { get; set; } //(varchar(20), null)
        public DateTime ShipDate { get; set; } //(smalldatetime, null)
        public string SeasonYear { get; set; } //(varchar(2), null)
        public string Style { get; set; } //(varchar(7), null)
        public string Color { get; set; } //(varchar(11), null)
        public string Size { get; set; } //(varchar(11), null)
        // ReSharper restore InconsistentNaming
    }
}
