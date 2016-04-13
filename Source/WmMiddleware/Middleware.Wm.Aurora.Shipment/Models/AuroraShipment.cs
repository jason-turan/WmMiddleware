using System.Collections.Generic;

namespace Middleware.Wm.Aurora.Shipment.Models
{
    public class AuroraShipment
    {
        public string OrderNumber { get; set; }
        public IList<AuroraShipmentDetail> Details { get; set; }
    }
}
