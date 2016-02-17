using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WmMiddleware.Configuration.Database
{
    public static class DatabaseConnectionFactory
    {
        public static IDbConnection GetWarehouseManagementConnection()
        {
            return GetConnection("WarehouseManagementConnection");
        }

        public static IDbConnection GetWarehouseManagementTransactionConnection()
        {
            return GetConnection("WarehouseManagementTransactionConnection");
        }

        public static IDbConnection GetDwhExportConnection()
        {
            return GetConnection("DwhExportConnection");
        }

        public static IDbConnection GetDeckisKioskonnection()
        {
            return GetConnection("DeckIsKioskConnection");
        }

        public static IDbConnection GetIntegrationManagementConnection()
        {
            return GetConnection("IntegrationManagementConnection");
        }

        public static IDbConnection GetNbxWebConnection()
        {
            return GetConnection("NbXWebConnection");
        }

        public static IDbConnection GetGpConnection()
        {
            return GetConnection("GpConnection");
        }

        private static IDbConnection GetConnection(string connectionName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName];

            if (connectionString == null || connectionString.ConnectionString == null)
            {
                var errorMessage = "Cannot find connection string key: [" + 
                                   connectionName +
                                   "]. Please verify it exists in configuration file.";

                throw new ConfigurationErrorsException(errorMessage);
            }

            return new SqlConnection(connectionString.ConnectionString);
        }
    }
}
