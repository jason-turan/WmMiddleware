using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Shipment.Models;

namespace Middleware.Wm.Manhattan.Shipment
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

        public IList<ManhattanShipment> FindManhattanShipmentHeaders(ManhattanShipmentSearchCriteria criteria)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShipTo", criteria.ShipTo, DbType.String);

                connection.Open();
                
                var headers = connection.Query<ManhattanShipmentHeader>("sp_FindManhattanShipmentHeader", 
                                                                        parameters, 
                                                                        commandType: CommandType.StoredProcedure);

                var manhattanShipments = new List<ManhattanShipment>();
                
                foreach (var manhattanShipmentHeader in headers)
                {
                    var manhattanShipment = new ManhattanShipment {Header = manhattanShipmentHeader};
                    var lineItemParameters = new DynamicParameters();
                    lineItemParameters.Add("@PickTicketControlNumber", manhattanShipmentHeader.PickticketControlNumber);
                    lineItemParameters.Add("@BatchControlNumber", manhattanShipmentHeader.BatchControlNumber);

                    manhattanShipment.LineItems = connection.Query<ManhattanShipmentLineItem>("sp_GetManhattanShipmentLineItem", 
                                                                                              lineItemParameters, 
                                                                                              commandType: CommandType.StoredProcedure).ToList();

                    manhattanShipments.Add(manhattanShipment);
                }

                return manhattanShipments;
            }
        }
    }
}
