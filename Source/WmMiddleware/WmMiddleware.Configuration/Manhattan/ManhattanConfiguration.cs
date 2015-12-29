using System.IO;
using Dapper;
using WmMiddleware.Configuration.Database;
using MiddleWare.Log;

namespace WmMiddleware.Configuration.Manhattan
{
    public class ManhattanConfiguration : MiddlewareConfigurationManager, IManhattanConfiguration
    {
        public ManhattanConfiguration(ILog log) : base(log)
        {
        }

        public long GetBatchControlNumber(BatchControlNumberType type)
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
