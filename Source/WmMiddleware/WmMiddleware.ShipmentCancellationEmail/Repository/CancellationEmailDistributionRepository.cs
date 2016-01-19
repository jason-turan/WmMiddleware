using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.ShipmentCancellationEmail.Models;

namespace WmMiddleware.ShipmentCancellationEmail.Repository
{
    public class CancellationEmailDistributionRepository : ICancellationEmailDistributionRepository
    {
        public ShipmentCancellationEmailDistribution GetShipmentCancellationEmailDistribution(string company)
        {
            const string sqlShipmentCancellationEmailDistribution = @"SELECT * 
                                                                      FROM ShipmentCancellationEmailDistribution
                                                                      WHERE Company = @Company";

            var parameters = new DynamicParameters();

            parameters.Add("@Company", company, DbType.String);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                return connection.Query<ShipmentCancellationEmailDistribution>(sqlShipmentCancellationEmailDistribution, parameters).SingleOrDefault();
            }
        }

        public IEnumerable<Models.ShipmentCancellationEmail> GetCancellations()
        {
            const string sqlUnprocessedShipmentCancellations = @"SELECT msh.OrderNumber, msli.PickticketLineNumber as LineNumber, msli.PackageBarcode as StockKeepingUnit
                                                                 FROM ManhattanShipmentHeader msh
	                                                                INNER JOIN ManhattanShipmentLineItem msli
                                                                 ON msh.PickticketControlNumber = msli.PickticketControlNumber
	                                                                LEFT JOIN [ManhattanShipmentLineItemCancellationProcessing] mslicp
                                                                 ON msli.ManhattanShipmentLineItemId = mslicp.ManhattanShipmentLineItemId
                                                                 WHERE shippedquantity = 0";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<Models.ShipmentCancellationEmail>(sqlUnprocessedShipmentCancellations);
            }
        }

        public string GetCompanyFromOrderNumber(string orderNumber)
        {
            string sql = @"SELECT company 
                           FROM nbxweb.dbo.gp_header (nolock) 
                           WHERE order_number = '" + orderNumber + "'";

            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                return connection.ExecuteScalar<string>(sql);
            }
        }
    }
}
