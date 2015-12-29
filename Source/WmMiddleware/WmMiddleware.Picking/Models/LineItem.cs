using System;

namespace WmMiddleware.Picking.Models
{
    public class LineItem
    {
        public double ItemNumber { get; set; }
        public string ItemSku { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public string UnitsOfMeasure { get; set; }
        public double EachPrice { get; set; }
        public double ItemDiscount { get; set; }
        public double ExtendedPrice { get; set; }
        public string ItemComments { get; set; }
        public string InventoryType { get; set; }
        public string ReturnTo { get; set; }
        public DateTime ShipDate { get; set; }
        public string DetailGPStatus { get; set; }
        public int DetailDISRowDownloaded { get; set; }
        public DateTime DetailDISDownloadedWhen { get; set; }
        public bool DetailDISDownloadReady { get; set; }
        public string DetailCadreStatus { get; set; }
        public string SeasonYear { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
