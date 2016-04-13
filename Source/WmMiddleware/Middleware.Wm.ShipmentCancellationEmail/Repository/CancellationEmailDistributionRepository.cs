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

        public IEnumerable<Models.ShipmentCancellationEmail> GetShipmentEmailCancellations()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                return connection.Query<Models.ShipmentCancellationEmail>("sp_GetCancellationsForEmailNotification", commandType: CommandType.StoredProcedure);
            }
        }

        public void SetAsProcessed(IEnumerable<Models.ShipmentCancellationEmail> emails)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var orderNumberTable = new DataTable();
                orderNumberTable.Columns.Add("IDInterfaceShipmentConfirmationHeader");
                foreach (var email in emails)
                {
                    orderNumberTable.Rows.Add(email.OrderNumber);
                }

                var parameter = new
                {
                    OrderNumberTable = orderNumberTable.AsTableValuedParameter("[dbo].[OrderNumberTable]"),
                    Status = "READ"
                };

                connection.Open();
                connection.Execute("[sp_UpdateShipmentEmailStatus]", parameter, commandType: CommandType.StoredProcedure);
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
