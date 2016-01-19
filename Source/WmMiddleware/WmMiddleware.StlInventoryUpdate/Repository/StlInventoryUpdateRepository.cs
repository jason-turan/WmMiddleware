using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.StlInventoryUpdate.Models;

namespace WmMiddleware.StlInventoryUpdate.Repository
{
    public class StlInventoryUpdateRepository : IStlInventoryUpdateRepository
    {

        public IEnumerable<Models.StlInventoryUpdate> GetStlInventoryPix()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                return connection.Query<Models.StlInventoryUpdate>("sp_GetStlInventoryPix");
            }
        }

        public IEnumerable<Models.StlInventoryUpdate> GetStlInventoryShipments()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                return connection.Query<Models.StlInventoryUpdate>("sp_GetStlInventoryShipments");
            }
        }

        public void UpdateStlInventory(IList<Models.StlInventoryUpdate> stlInventoryList)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var stlInventoryUpdateTable = new DataTable();

                stlInventoryUpdateTable.Columns.Add("Upc");
                stlInventoryUpdateTable.Columns.Add("Style");
                stlInventoryUpdateTable.Columns.Add("Size");
                stlInventoryUpdateTable.Columns.Add("Attr");
                stlInventoryUpdateTable.Columns.Add("Qty");
                foreach (var stlInv in stlInventoryList)
                {
                    stlInventoryUpdateTable.Rows.Add(stlInv.Upc, stlInv.Style, stlInv.Size, stlInv.Attr, stlInv.Qty);
                }

                var parameter = new
                {
                    StlInventoryUpdateTable = stlInventoryUpdateTable.AsTableValuedParameter("[dbo].[StlInventoryUpdateTable]")
                };

                connection.Open();
                connection.Execute("sp_UpdateSTLInventory", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public void SetPixAsProcessed(IList<Models.StlInventoryUpdate> stlInvenotryList)
        {
            const string insertInventoryProcessing = @"INSERT INTO [dbo].[InventoryPixProcessing]
                                                            ([ManhattanPerpetualInventoryTransferId]
                                                            ,[ProcessedDate])
                                                            VALUES
                                                            (@ProcessingId
                                                            ,@InvDate)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertInventoryProcessing, stlInvenotryList);
            }
        }
               
        public void SetShipmentsAsProcessed(IList<Models.StlInventoryUpdate> stlInvenotryList)
        {
            const string insertInventoryProcessing = @"INSERT INTO [dbo].[InventoryShipmentProcessing]
                                                            ([ManhattanShipmentLineItemId]
                                                            ,[ProcessedDate])
                                                            VALUES
                                                            (@ProcessingId
                                                            ,@InvDate)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertInventoryProcessing, stlInvenotryList);
            }
        }
    
    }
}
