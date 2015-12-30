using System.Data;
using System.Data.SqlClient;

namespace WmMiddleware.Configuration.Database
{
    public static class DatabaseConnectionFactory
    {
        public static IDbConnection GetWarehouseManagementConnection()
        {
            return GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WarehouseManagementConnection"].ConnectionString);
        }

        public static IDbConnection GetIntegrationManagementConnection()
        {
            return GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["IntegrationManagementConnection"].ConnectionString);
        }

        public static IDbConnection GetNbxWebConnection()
        {
            return GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NbXWebConnection"].ConnectionString);
        }

        private static IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
