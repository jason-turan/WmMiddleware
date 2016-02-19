using System.Collections.Generic;

namespace Middleware.Wm.Manhattan.Shipment
{
    public class ManhattanShipment
    {
        public ManhattanShipmentHeader Header { get; set; }
        public IList<ManhattanShipmentLineItem> LineItems { get; set; }
        public IList<ManhattanShipmentCartonHeader> ManhattanShipmentCartonHeader { get; set; }
        public IList<ManhattanShipmentCartonDetail> ManhattanShipmentCartonDetails { get; set; } 
    }
}
