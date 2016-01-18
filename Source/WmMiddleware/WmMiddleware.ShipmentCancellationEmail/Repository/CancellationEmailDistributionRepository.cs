using System.Data;
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

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.ExecuteScalar<ShipmentCancellationEmailDistribution>(sqlShipmentCancellationEmailDistribution, parameters);
            }
        }
    }
}
