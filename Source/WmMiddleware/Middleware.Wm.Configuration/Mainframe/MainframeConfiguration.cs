using System.IO;
using Dapper;
using MiddleWare.Log;
using Middleware.Wm.Configuration.Database;

namespace Middleware.Wm.Configuration.Mainframe
{
    public class MainframeConfiguration : MiddlewareConfigurationManager, IMainframeConfiguration
    {
        public MainframeConfiguration(ILog log) : base(log)
        {
        }

        public long GetBatchControlNumber()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                return connection.ExecuteScalar<long>("sp_GetBatchControlNumber");
            }
        }

        public string GetPath(string filePrefix, long batchControlNumber, string warehouseNumber, string configurationKeyPrefix)
        {
            var outputLocation = GetKey<string>(configurationKeyPrefix + ConfigurationKey.TransferControlInboundFileDirectory);
            return Path.Combine(outputLocation, string.Format("{0}{1}{2:D6}", filePrefix, warehouseNumber, batchControlNumber));
        }

        public string GetPath(string filePrefix, long batchControlNumber)
        {
            var outputLocation = GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);

            return Path.Combine(outputLocation, string.Format("{0}{1:D8}", filePrefix, batchControlNumber));
        }
    }
}
