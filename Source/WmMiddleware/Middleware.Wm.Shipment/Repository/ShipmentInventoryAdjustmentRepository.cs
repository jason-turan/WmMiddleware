using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Manhattan.Shipment;
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

       public void InsertShipmentInventoryAdjustmentProcessing(IList<ShipmentInventoryAdjustment> shipmentInventoryAdjustments)
       {
           using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
           {
               var inventoryShipmentProcessingTable = new DataTable();

               inventoryShipmentProcessingTable.Columns.Add("ManhattanShipmentLineItemId");
               inventoryShipmentProcessingTable.Columns.Add("ManhattanDateCreated");
               inventoryShipmentProcessingTable.Columns.Add("ManhattanTimeCreated");

               foreach (var adj in shipmentInventoryAdjustments)
               {
                   inventoryShipmentProcessingTable.Rows.Add(adj.ManhattanShipmentLineItemId, adj.ManhattanDateCreated, adj.ManhattanTimeCreated);
               }

               var parameter = new
               {
                   InventoryShipmentProcessingTable = inventoryShipmentProcessingTable.AsTableValuedParameter("[dbo].[InventoryShipmentProcessingTable]")
               };

               connection.Open();
               connection.Execute("sp_InsertInventoryShipmentProcessing", parameter, commandType: CommandType.StoredProcedure);
           }
       }
    }
}
