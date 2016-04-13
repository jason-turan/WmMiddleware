namespace Middleware.Wm.Manhattan.Shipment
{
    public class ManhattanShipmentSearchCriteria
    {
        public const string BrickAndClickShipTo = "CDX";
        public string ShipTo { get; set; }
        public bool UnprocessedForAuroraShipment { get; set; }
        public bool UnprocessedForAuroraShipmentGeneralLedger { get; set; }
    }
}
