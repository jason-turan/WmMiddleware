using System.Collections.Generic;
using WmMiddleware.Shipment.Models.Generated;

namespace WmMiddleware.Shipment.Repository
{
    public interface IShipmentRepository
    {
        void InsertShipmentHeaders(IList<ShipmentHeader> shipmentHeader);
        void InsertShipmentLineItems(IList<ShipmentLineItem> shipmentLineItems);
        void InsertShipmentCartonHeaders(IList<ShipmentCartonHeader> shipmentCartonHeaders);
        void InsertShipmentCartonDetails(IList<ShipmentCartonDetail> shipmentCartonDetails);
    }
}
