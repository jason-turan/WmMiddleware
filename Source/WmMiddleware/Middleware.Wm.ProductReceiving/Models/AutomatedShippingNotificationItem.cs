using System;

namespace WmMiddleware.ProductReceiving.Models
{
    public class AutomatedShippingNotificationItem
    {
        public string Sku { get; set; }
        public string SkuClass { get; set; }
        public string SkuDesc { get; set; }
        public string Upc { get; set; }
        public string Uom { get; set; }
        public int UnitsShipped { get; set; }
        public int UnitsOrdered { get; set; }
        public string ParentMuId { get; set; }
        public string ParentMuType { get; set; }
        public string ChildMuId { get; set; }
        public string ChildMuType { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal Weight { get; set; }
        public string LotId { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SerialNumber { get; set; }
        public string InterfaceUser1 { get; set; }
        public string InterfaceUser2 { get; set; }
        public string InterfaceUser3 { get; set; }
        public string InterfaceUser4 { get; set; }
        public string InterfaceUser5 { get; set; }
        public string InterfaceUser6 { get; set; }
        public string InterfaceUser7 { get; set; }
        public string InterfaceUser8 { get; set; }
        public string InterfaceUser9 { get; set; }
        public string InterfaceUser10 { get; set; }
        public string PalletTypeCode { get; set; }
        public int PalletTiers { get; set; }
        public int PalletBlocks { get; set; }
        public int PalletInnerBlocks { get; set; }
        public decimal PalletWeight { get; set; }
        public string PalletWeightUom { get; set; }
        public double PalletVolume { get; set; }
        public string PalletVolumeUom { get; set; }
        public string PalletDimensionUom { get; set; }
        public int EachQuantity { get; set; }
        public string ActionCode { get; set; }
        public int DetailSequenceNumber { get; set; }
        public int CartonQuantity { get; set; }
        public int PalletQuantity { get; set; }
        public decimal TareWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string SeasonYear { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
