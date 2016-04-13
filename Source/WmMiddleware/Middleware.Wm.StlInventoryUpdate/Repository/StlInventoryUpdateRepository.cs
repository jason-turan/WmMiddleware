using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.StlInventoryUpdate.Models;

namespace Middleware.Wm.StlInventoryUpdate.Repository
{
    public class StlInventoryUpdateRepository : IStlInventoryUpdateRepository
    {

        public void UpdateStlInventory(IList<StlInventoryItem> stlInventoryList)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                var stlInventoryUpdateTable = new DataTable();

                stlInventoryUpdateTable.Columns.Add("Upc");
                stlInventoryUpdateTable.Columns.Add("Style");
                stlInventoryUpdateTable.Columns.Add("Size");
                stlInventoryUpdateTable.Columns.Add("Attribute");
                stlInventoryUpdateTable.Columns.Add("Quantity");
                foreach (var stlInv in stlInventoryList)
                {
                    stlInventoryUpdateTable.Rows.Add(stlInv.Upc, stlInv.Style, stlInv.Size, stlInv.Attribute, stlInv.Quantity);
                }

                var parameter = new
                {
                    StlInventoryUpdateTable = stlInventoryUpdateTable.AsTableValuedParameter("[dbo].[StlInventoryUpdateTable]"),
                    InventoryDate = DateTime.Now
                };

                connection.Open();
                connection.Execute("sp_UpdateSTLInventory", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    
    }
}
