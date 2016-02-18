using System.Collections.Generic;
using System.Linq;
using Middleware.Wm.Shipment.Models;

namespace Middleware.Wm.Shipment.Repository
{
    public class ShipmentInventoryAdjustmentRepository : IShipmentInventoryAdjustmentRepository
    {

       private readonly IShipmentRepository _shipmentRepositoryRepository;

       public ShipmentInventoryAdjustmentRepository(IShipmentRepository shipmentRepositoryRepository)
       {
           _shipmentRepositoryRepository = shipmentRepositoryRepository;
       }

       public IEnumerable<ShipmentInventoryAdjustment> GetUnprocessedInventoryAdjustments()
       {
           var inventoryAdjustments = _shipmentRepositoryRepository.FindShipmentLineItems();

           return inventoryAdjustments.Select(inventoryAdjustment => new ShipmentInventoryAdjustment(inventoryAdjustment)).ToList();
       }
    }
}
