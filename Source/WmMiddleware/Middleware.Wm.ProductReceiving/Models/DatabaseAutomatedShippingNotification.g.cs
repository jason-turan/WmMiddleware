﻿using System;

// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Middleware.Wm.ProductReceiving.Models
{
    internal partial class DatabaseAutomatedShippingNotification
    {
        public DateTime UpdateDate { get; set; } //(datetime, not null)
        public string UpdateUserID { get; set; } //(varchar(20), not null)
        public string UpdatePID { get; set; } //(varchar(20), not null)
        public DateTime InsertDate { get; set; } //(datetime, not null)
        public int IDInterfaceShipmentConfirmationHeader { get; set; } //(int, not null)
        public string ExternalUID { get; set; } //(varchar(50), not null)
        public string OrderID { get; set; } //(varchar(50), not null)
        public string LoadID { get; set; } //(varchar(20), not null)
        public string TrackingNumber { get; set; } //(varchar(30), not null)
        public string ClientID { get; set; } //(varchar(20), not null)
        public DateTime OrderDate { get; set; } //(datetime, not null)
        public string OrderType { get; set; } //(varchar(10), not null)
        public string OrderPriority { get; set; } //(varchar(10), not null)
        public string OrderStatus { get; set; } //(varchar(10), not null)
        public DateTime ShipDate { get; set; } //(datetime, not null)
        public DateTime ExpectedDeliveryDate { get; set; } //(datetime, not null)
        public string CustomerPORef { get; set; } //(varchar(20), not null)
        public DateTime CustomerPODate { get; set; } //(datetime, not null)
        public string RouteID { get; set; } //(varchar(15), not null)
        public string StopID { get; set; } //(varchar(5), not null)
        public string FacilityNbr { get; set; } //(varchar(2), not null)
        public string BillToCustomerID { get; set; } //(varchar(20), not null)
        public string SoldToCustomerID { get; set; } //(varchar(20), not null)
        public string ShipToCustomerID { get; set; } //(varchar(50), not null)
        public string CarrierCode { get; set; } //(varchar(20), not null)
        public string SCAC { get; set; } //(varchar(20), not null)
        public string ShippingTerms { get; set; } //(varchar(10), not null)
        public string BOL { get; set; } //(varchar(30), not null)
        public string Seal1 { get; set; } //(varchar(15), not null)
        public string Seal2 { get; set; } //(varchar(15), not null)
        public int ContainerSeqNbr { get; set; } //(int, not null)
        public string EquipmentID { get; set; } //(varchar(15), not null)
        public string EquipmentType { get; set; } //(varchar(15), not null)
        public string WeightUOM { get; set; } //(char(4), not null)
        public double TotalWeightShipped { get; set; } //(float, not null)
        public int TotalUnitsShipped { get; set; } //(int, not null)
        public int TotalPalletsShipped { get; set; } //(int, not null)
        public int TotalChepPalletsShipped { get; set; } //(int, not null)
        public string HeaderInterfaceUser1 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser2 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser3 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser4 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser5 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser6 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser7 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser8 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser9 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceUser10 { get; set; } //(varchar(256), not null)
        public string HeaderInterfaceStatus { get; set; } //(char(32), not null)
        public string HeaderInterfaceErrorText { get; set; } //(varchar(256), not null)
        public string OriginalMeasType { get; set; } //(varchar(10), not null)
        public string ShipPackagingCode { get; set; } //(varchar(5), not null)
        public int ShipLadingQty { get; set; } //(int, not null)
        public double ShipWeight { get; set; } //(float, not null)
        public string ShipWeightUOM { get; set; } //(varchar(3), not null)
        public string OrderPackagingCode { get; set; } //(varchar(3), not null)
        public int OrderLadingQty { get; set; } //(int, not null)
        public double OrderWeight { get; set; } //(float, not null)
        public string OrderWeightUOM { get; set; } //(varchar(3), not null)
        public string ShipFromID { get; set; } //(varchar(15), not null)
        public double ActualFreightCharge { get; set; } //(float, not null)
        public double DiscountedFreightCharge { get; set; } //(float, not null)
        public string ASNnbr { get; set; } //(varchar(15), not null)
        public string ShipmentID { get; set; } //(varchar(30), not null)
        public string ActionCode { get; set; } //(char(1), not null)
        public string VendorID { get; set; } //(varchar(15), not null)
        public string ASNdirection { get; set; } //(varchar(3), not null)
        public string ASNfacilityNbr { get; set; } //(varchar(2), not null)
        public string ProNbr { get; set; } //(varchar(30), not null)
        public string BuyerRefNbr { get; set; } //(varchar(20), not null)
        public string OutBoundCarrierCode { get; set; } //(varchar(20), not null)
        public string Status { get; set; } //(varchar(10), not null)
        public string SKU { get; set; } //(varchar(20), not null)
        public string SKUClass { get; set; } //(varchar(10), not null)
        public string SKUdesc { get; set; } //(varchar(50), not null)
        public string UPC { get; set; } //(varchar(20), not null)
        public string UOM { get; set; } //(varchar(20), not null)
        public int UnitsShipped { get; set; } //(int, not null)
        public int UnitsOrdered { get; set; } //(int, not null)
        public string ParentMUID { get; set; } //(varchar(20), not null)
        public string ParentMUType { get; set; } //(varchar(20), not null)
        public string ChildMUID { get; set; } //(varchar(20), not null)
        public string ChildMUType { get; set; } //(varchar(20), not null)
        public double Height { get; set; } //(float, not null)
        public double Width { get; set; } //(float, not null)
        public double Length { get; set; } //(float, not null)
        public decimal Weight { get; set; } //(decimal(18,4), not null)
        public string LotID { get; set; } //(varchar(20), not null)
        public DateTime MfgDate { get; set; } //(datetime, not null)
        public DateTime ExpDate { get; set; } //(datetime, not null)
        public string SerialNbr { get; set; } //(varchar(20), not null)
        public string InterfaceUser1 { get; set; } //(varchar(256), not null)
        public string InterfaceUser2 { get; set; } //(varchar(256), not null)
        public string InterfaceUser3 { get; set; } //(varchar(256), not null)
        public string InterfaceUser4 { get; set; } //(varchar(256), not null)
        public string InterfaceUser5 { get; set; } //(varchar(256), not null)
        public string InterfaceUser6 { get; set; } //(varchar(256), not null)
        public string InterfaceUser7 { get; set; } //(varchar(256), not null)
        public string InterfaceUser8 { get; set; } //(varchar(256), not null)
        public string InterfaceUser9 { get; set; } //(varchar(256), not null)
        public string InterfaceUser10 { get; set; } //(varchar(256), not null)
        public string InterfaceStatus { get; set; } //(char(32), not null)
        public string InterfaceErrorText { get; set; } //(varchar(256), not null)
        public string PalletTypeCode { get; set; } //(varchar(3), not null)
        public int PalletTiers { get; set; } //(int, not null)
        public int PalletBlocks { get; set; } //(int, not null)
        public int PalletInnerBlocks { get; set; } //(int, not null)
        public decimal PalletWeight { get; set; } //(decimal(18,4), not null)
        public string PalletWeightUOM { get; set; } //(varchar(3), not null)
        public double PalletVolume { get; set; } //(float, not null)
        public string PalletVolumeUOM { get; set; } //(varchar(3), not null)
        public string PalletDimensionUOM { get; set; } //(varchar(3), not null)
        public int EachQty { get; set; } //(int, not null)
        public int DetailSeqNbr { get; set; } //(int, not null)
        public int CartonQTY { get; set; } //(int, not null)
        public int PalletQTY { get; set; } //(int, not null)
        public decimal TareWeight { get; set; } //(decimal(18,4), not null)
        public decimal NetWeight { get; set; } //(decimal(18,4), not null)
        public string SeasonYear { get; set; } //(varchar(2), null)
        public string Style { get; set; } //(varchar(7), null)
        public string Color { get; set; } //(varchar(11), null)
        public string Size { get; set; } //(varchar(11), null)
    }
    // ReSharper restore InconsistentNaming
}