using System.Collections.Generic;
using WmMiddleware.Shipment.Models.Generated;

namespace WmMiddleware.Shipment.Repository
{
    public interface IShipmentRepository
    {
        void InsertShipmentHeaders(IList<ManhattanShipmentHeader> shipmentHeader);
        void InsertShipmentLineItems(IList<ManhattanShipmentLineItem> shipmentLineItems);
        void InsertShipmentCartonHeaders(IList<ManhattanShipmentCartonHeader> shipmentCartonHeaders);
        void InsertShipmentCartonDetails(IList<ManhattanShipmentCartonDetail> shipmentCartonDetails);
    }
}
