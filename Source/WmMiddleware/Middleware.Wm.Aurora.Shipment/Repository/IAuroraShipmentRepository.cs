using System.Collections.Generic;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public interface IAuroraShipmentRepository
    {
        void SaveShipments(IList<Models.AuroraShipment> shipments);
    }
}
