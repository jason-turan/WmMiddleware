using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.Shipment.Models.Generated;

namespace WmMiddleware.Shipment.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        public void InsertShipmentHeaders(IList<ShipmentHeader> shipmentHeaders)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentHeaders);
            }
        }

        public void InsertShipmentLineItems(IList<ShipmentLineItem> shipmentLineItems)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentLineItems);
            }
        }

        public void InsertShipmentCartonHeaders(IList<ShipmentCartonHeader> shipmentCartonHeaders)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentCartonHeaders);
            }
        }

        public void InsertShipmentCartonDetails(IList<ShipmentCartonDetail> shipmentCartonDetails)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(shipmentCartonDetails);
            }
        }
    }
}
