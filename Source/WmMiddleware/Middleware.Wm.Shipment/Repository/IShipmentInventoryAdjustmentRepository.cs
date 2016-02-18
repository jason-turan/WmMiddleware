using System.Collections.Generic;
using Middleware.Wm.Shipment.Models;

namespace Middleware.Wm.Shipment.Repository
{
    public interface IShipmentInventoryAdjustmentRepository
    {
        IEnumerable<ShipmentInventoryAdjustment> GetUnprocessedInventoryAdjustments();
    }
}
