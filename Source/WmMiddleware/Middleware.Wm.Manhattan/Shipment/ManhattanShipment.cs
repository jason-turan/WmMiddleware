using System.Collections.Generic;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.Shipment.Models
{
    public class ManhattanShipment
    {
        public ManhattanShipmentHeader Header { get; set; }
        public IList<ManhattanShipmentLineItem> LineItems { get; set; }
        public ManhattanShipmentCartonHeader ManhattanShipmentCartonHeader { get; set; }
        public IList<ManhattanShipmentCartonDetail> ManhattanShipmentCartonDetails { get; set; } 
    }
}
