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

            var parameters = new DynamicParameters();

            parameters.Add("@Company", company, DbType.String);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                return connection.Query<ShipmentCancellationEmailDistribution>("sp_GetShipmentCancellationEmailDistribution", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<Models.ShipmentCancellationEmail> GetShipmentEmailCancellations()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<Models.ShipmentCancellationEmail>("sp_GetCancellationsForEmailNotification", commandType: CommandType.StoredProcedure);
            }
        }

        public string GetCompanyFromOrderNumber(string orderNumber)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrderNumber", orderNumber);

            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                return connection.ExecuteScalar<string>("sp_GetCancellationsForEmailNotification", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
