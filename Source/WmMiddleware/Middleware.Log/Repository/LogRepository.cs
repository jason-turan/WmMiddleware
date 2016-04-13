using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Middleware.Log.Repository
{
    public class LogRepository : ILogRepository
    {
        public int DeleteLogByDate(DateTime deleteOlderThanDate)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WarehouseManagementConnection"].ConnectionString))
            {
                connection.Open();

                return connection.Execute("DELETE FROM Log WHERE Date < '" +
                                          deleteOlderThanDate.Date +
                                          "'");
            }
        }
    }
}
