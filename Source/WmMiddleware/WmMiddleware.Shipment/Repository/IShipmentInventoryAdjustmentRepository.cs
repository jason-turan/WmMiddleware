using System.Collections.Generic;
using WmMiddleware.Shipment.Models;

namespace WmMiddleware.Shipment.Repository
{
    public interface IShipmentInventoryAdjustmentRepository
    {
        IEnumerable<ShipmentInventoryAdjustment> GetUnprocessedInventoryAdjustments();
    }
}
