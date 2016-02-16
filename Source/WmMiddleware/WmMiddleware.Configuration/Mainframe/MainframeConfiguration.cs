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

        public string GetPath(string filePrefix, long batchControlNumber)
        {
            var outputLocation = GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory);
            return Path.Combine(outputLocation, string.Format("{0}{1:D8}", filePrefix, batchControlNumber));
        }
    }
}
