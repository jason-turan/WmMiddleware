using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Middleware.Wm.ProductReceivingng.Models
{
    public class AutomatedShippingNotification : IReceivedProduct
    {
        public AutomatedShippingNotification()
        {
            Items = new Collection<AutomatedShippingNotificationItem>();
        }

        public ICollection<AutomatedShippingNotificationItem> Items { get; set; }

        public DateTime UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePid { get; set; }
        public DateTime InsertDate { get; set; }
        public int IdInterfaceShipmentConfirmationHeader { get; set; }
        public string ExternalUid { get; set; }
        public string OrderId { get; set; }
        public string LoadId { get; set; }
        public string TrackingNumber { get; set; }
        public string ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }
        public string OrderPriority { get; set; }
        public string OrderStatus { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string CustomerPurchaseOrderReference { get; set; }
        public DateTime CustomerPurchaseOrderDate { get; set; }
        public string RouteId { get; set; }
        public string StopId { get; set; }
        public string FacilityNumber { get; set; }
        public string BillToCustomerId { get; set; }
        public string SoldToCustomerId { get; set; }
        public string ShipToCustomerId { get; set; }
        public string CarrierCode { get; set; }
        public string Scac { get; set; }
        public string ShippingTerms { get; set; }
        public string Bol { get; set; }
        public string Seal1 { get; set; }
        public string Seal2 { get; set; }
        public int ContainerSequenceNumber { get; set; }
        public string EquipmentId { get; set; }
        public string EquipmentType { get; set; }
        public string WeightUom { get; set; }
        public double TotalWeightShipped { get; set; }
        public int TotalUnitsShipped { get; set; }
        public int TotalPalletsShipped { get; set; }
        public int TotalChepPalletsShipped { get; set; }
        public string HeaderInterfaceUser1 { get; set; }
        public string HeaderInterfaceUser2 { get; set; }
        public string HeaderInterfaceUser3 { get; set; }
        public string HeaderInterfaceUser4 { get; set; }
        public string HeaderInterfaceUser5 { get; set; }
        public string HeaderInterfaceUser6 { get; set; }
        public string HeaderInterfaceUser7 { get; set; }
        public string HeaderInterfaceUser8 { get; set; }
        public string HeaderInterfaceUser9 { get; set; }
        public string HeaderInterfaceUser10 { get; set; }
        public string InterfaceStatus { get; set; }
        public string InterfaceErrorText { get; set; }
        public string OriginalMeasureType { get; set; }
        public string ShipPackagingCode { get; set; }
        public int ShipLadingQuantity { get; set; }
        public double ShipWeight { get; set; }
        public string ShipWeightUom { get; set; }
        public string OrderPackagingCode { get; set; }
        public int OrderLadingQuantity { get; set; }
        public double OrderWeight { get; set; }
        public string OrderWeightUom { get; set; }
        public string ShipFromId { get; set; }
        public double ActualFreightCharge { get; set; }
        public double DiscountedFreightCharge { get; set; }
        public string AutomatedShippingNotificationNumber { get; set; }
        public string ShipmentId { get; set; }
        public string VendorId { get; set; }
        public string AutomatedShippingNotificationDirection { get; set; }
        public string AutomatedShippingNotificationFacilityNumber { get; set; }
        public string ProNumber { get; set; }
        public string BuyerReferenceNumber { get; set; }
        public string OutboundCarrierCode { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return ExternalUid;
        }
    }
}
