using System.IO;
using Dapper;
using MiddleWare.Log;
using WmMiddleware.Configuration.Database;

namespace WmMiddleware.Configuration.Mainframe
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

        public string GetPath(string filePrefix, long batchControlNumber, string configurationKeyPrefix = null)
        {
            var outputLocation = GetKey<string>(configurationKeyPrefix == null ? 
                                                ConfigurationKey.TransferControlInboundFileDirectory : 
                                                configurationKeyPrefix + ConfigurationKey.TransferControlInboundFileDirectory);

            return Path.Combine(outputLocation, string.Format("{0}{1:D8}", filePrefix, batchControlNumber));
        }
    }
}
