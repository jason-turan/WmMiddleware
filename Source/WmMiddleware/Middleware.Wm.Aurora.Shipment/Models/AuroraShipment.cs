using System.Collections.Generic;

namespace Middleware.Wm.Aurora.Shipment.Models
{
    public class AuroraShipment
    {
        public IEnumerable<AuroraShipmentDetail> Details { get; set; }
    }
}
