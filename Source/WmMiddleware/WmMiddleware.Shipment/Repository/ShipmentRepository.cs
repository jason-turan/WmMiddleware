using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Manhattan.Shipment;
using WmMiddleware.Configuration.Database;
using WmMiddleware.Shipment.Models;

namespace WmMiddleware.Shipment.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        public void InsertShipmentHeaders(IList<ManhattanShipmentHeader> shipmentHeaders)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentHeaders);
            }
        }

        public void InsertShipmentLineItems(IList<ManhattanShipmentLineItem> shipmentLineItems)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentLineItems);
            }
        }

        public void InsertShipmentCartonHeaders(IList<ManhattanShipmentCartonHeader> shipmentCartonHeaders)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentCartonHeaders);
            }
        }

        public void InsertShipmentCartonDetails(IList<ManhattanShipmentCartonDetail> shipmentCartonDetails)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentCartonDetails);
            }
        }

        public IEnumerable<ManhattanShipmentLineItem> FindShipmentLineItems()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<ManhattanShipmentLineItem>("sp_FindManhattanShipmentLineItems", commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertShipmentInventoryAdjustmentProcessing(IList<ShipmentInventoryAdjustment> shipmentInventoryAdjustments)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var inventoryShipmentProcessingTable = new DataTable();

                inventoryShipmentProcessingTable.Columns.Add("ManhattanShipmentLineItemId");
                foreach (var adj in shipmentInventoryAdjustments)
                {
                    inventoryShipmentProcessingTable.Rows.Add(adj.ManhattanShipmentLineItemId);
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
