using System.Collections.Generic;
using Middleware.Wm.Shipment.Models;

namespace WmMiddleware.Shipment.Repository
{
    public interface IShipmentInventoryAdjustmentRepository
    {
        IEnumerable<ShipmentInventoryAdjustment> GetUnprocessedInventoryAdjustments();
    }
}
