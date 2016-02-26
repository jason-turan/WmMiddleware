using System;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Aurora.Shipment.Models;
using System.Collections.Generic;
using Middleware.Log;
using Middleware.Wm.Configuration.Database;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public class DatabaseKioskOrderExportRepository : IDatabaseKioskOrderExportRepository
    {
        private readonly ILog _log;

        public DatabaseKioskOrderExportRepository(ILog log)
        {
            _log = log;
        }

        public void InsertDatabaseKioskOrderExport(IList<DatabaseKioskOrderExport> kioskOrderExports)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(kioskOrderExports);
            }
        }

        public void InsertDatabaseKioskOrderExportProcessing(KioskOrderExportProcessing kioskOrderExportProcessing)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(kioskOrderExportProcessing);
            }
        }

        public void InsertDatabaseKioskOrderDetailExport(IList<DatabaseKioskOrderDetailExport> kiosKioskOrderDetailExports)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(kiosKioskOrderDetailExports);
            }
        }

        public IList<DatabaseKioskOrderExport> GetDatabaseKioskOrderExports()
        {
            IList<DatabaseKioskOrderExport> databaseKioskOrderExports;
             
            using (var connection = DatabaseConnectionFactory.GetDwhExportConnection())
            {
                databaseKioskOrderExports = connection.Query<DatabaseKioskOrderExport>("SELECT * FROM [kiosk_orders]").ToList();
            }

            if (databaseKioskOrderExports.Count == 0)
            {
                _log.Info("No orders found in kiosk_orders from export table... will read directly from dw_orders stored procedure.");
                using (var connection = DatabaseConnectionFactory.GetDeckisKioskonnection())
                {
                    var now = DateTime.Now;
                    var parameters = new DynamicParameters();
                    parameters.Add("@start_date", new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(-45));
                    parameters.Add("@end_date", now.AddDays(1));
                    databaseKioskOrderExports = connection.Query<DatabaseKioskOrderExport>("dw_Orders", commandType: CommandType.StoredProcedure, param: parameters).ToList();
                }
            }

            return databaseKioskOrderExports;
        }

        public IList<DatabaseKioskOrderDetailExport> GetDatabaseKioskOrderDetailExports()
        {
            IList<DatabaseKioskOrderDetailExport> databaseKioskOrderDetailExports;

            using (var connection = DatabaseConnectionFactory.GetDwhExportConnection())
            {
                databaseKioskOrderDetailExports =  connection.Query<DatabaseKioskOrderDetailExport>("SELECT * FROM [dbo].[kiosk_order_details]").ToList();
            }

            if (databaseKioskOrderDetailExports.Count == 0)
            {
                _log.Info("No orders found in kiosk_orders_details from export table... will read directly from dw_OrderDetails stored procedure.");

                using (var connection = DatabaseConnectionFactory.GetDeckisKioskonnection())
                {
                    var now = DateTime.Now;
                    var parameters = new DynamicParameters();
                    parameters.Add("@start_date", new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(-45));
                    parameters.Add("@end_date", now.AddDays(1));
                    databaseKioskOrderDetailExports = connection.Query<DatabaseKioskOrderDetailExport>("dw_OrderDetails", commandType: CommandType.StoredProcedure, param: parameters).ToList();
                }
            }

            return databaseKioskOrderDetailExports;
        }
    }
}
