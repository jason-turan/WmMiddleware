namespace Middleware.Wm.ShipmentCancellationEmail.Models
{
    public class ShipmentCancellationEmail
    {
        public string OrderNumber { get; set; }
        public string OrderId { get; set; }
        public string LineNumber { get; set; }
        public string StockKeepingUnit { get; set; }
        public string LineStatus { get; set; }
        public string TrackingId { get; set; }
        public string Style { get; set; }
    }
}
