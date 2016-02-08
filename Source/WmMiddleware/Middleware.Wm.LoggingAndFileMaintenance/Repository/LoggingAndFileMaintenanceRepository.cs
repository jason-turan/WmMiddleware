using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;

namespace Middleware.Wm.LoggingAndFileMaintenance.Repository
{
    public class LoggingAndFileMaintenanceRepository : ILoggingAndFileMaintenanceRepository
    {
        public Models.LoggingAndFileMaintenance GetLoggingAndFileMaintenance()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                var result = connection.Query<Models.LoggingAndFileMaintenance>("SELECT * FROM LoggingAndFileMaintenance").FirstOrDefault();
                return result;
            }
        }
    }
}
