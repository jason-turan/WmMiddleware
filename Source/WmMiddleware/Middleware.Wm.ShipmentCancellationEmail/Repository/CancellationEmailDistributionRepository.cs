using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.ShipmentCancellationEmail.Models;

namespace Middleware.Wm.ShipmentCancellationEmail.Repository
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

        public IEnumerable<Middleware.Wm.ShipmentCancellationEmail.Models.ShipmentCancellationEmail> GetShipmentEmailCancellations()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<Middleware.Wm.ShipmentCancellationEmail.Models.ShipmentCancellationEmail>("sp_GetCancellationsForEmailNotification", commandType: CommandType.StoredProcedure);
            }
        }

        public string GetCompanyFromOrderNumber(string orderNumber)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrderNumber", orderNumber);

            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                return connection.ExecuteScalar<string>("sp_GetCompanyFromOrderNumber", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
