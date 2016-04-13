using System.Collections.Generic;
using Middleware.Wm.Aurora.Shipment.Models;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public interface IAuroraShipmentRepository
    {
    //    void SaveShipments(IList<Models.AuroraShipment> shipments);

    //    IList<Models.AuroraShipment> GetShipments();

        void InsertManhattanShipmentBncProcessing(ManhattanShipmentBncProcessing processing);

        void ProcessAuroraShipmentBnc(IList<ManhattanShipment> manhattanShipment);
    }
}
