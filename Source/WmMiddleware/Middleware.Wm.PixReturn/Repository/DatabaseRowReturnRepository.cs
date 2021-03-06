﻿using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.PixReturn.Models;

namespace Middleware.Wm.PixReturn.Repository
{
    public class DatabaseRowReturnRepository : IDatabaseRowReturnRepository
    {
        public void InsertRowReturn(DatabaseRowReturn databaseRowReturn)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Insert(databaseRowReturn);
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
