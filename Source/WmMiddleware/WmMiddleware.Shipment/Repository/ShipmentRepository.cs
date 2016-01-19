using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.Shipment.Models.Generated;

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
    }
}
