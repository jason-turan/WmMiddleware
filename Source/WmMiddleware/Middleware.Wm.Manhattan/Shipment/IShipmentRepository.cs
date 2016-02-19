using System.Collections.Generic;
using Middleware.Wm.Shipment.Models;

namespace Middleware.Wm.Manhattan.Shipment
{
    public interface IShipmentRepository
    {
        void InsertShipmentHeaders(IList<ManhattanShipmentHeader> shipmentHeader);
        void InsertShipmentLineItems(IList<ManhattanShipmentLineItem> shipmentLineItems);
        void InsertShipmentCartonHeaders(IList<ManhattanShipmentCartonHeader> shipmentCartonHeaders);
        void InsertShipmentCartonDetails(IList<ManhattanShipmentCartonDetail> shipmentCartonDetails);
        IEnumerable<ManhattanShipmentLineItem> FindShipmentLineItems();
        IList<ManhattanShipment> FindManhattanShipmentHeaders(ManhattanShipmentSearchCriteria criteria);
    }
}
