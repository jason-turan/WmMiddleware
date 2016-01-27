using System.Collections.Generic;
using System.Data;
using Dapper;
using WmMiddleware.Configuration.Database;

namespace WmMiddleware.StlInventoryUpdate.Repository
{
    public class StlInventoryUpdateRepository : IStlInventoryUpdateRepository
    {

        public void UpdateStlInventory(IList<Models.StlInventoryItem> stlInventoryList)
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
                    StlInventoryUpdateTable = stlInventoryUpdateTable.AsTableValuedParameter("[dbo].[StlInventoryUpdateTable]")
                };

                connection.Open();
                connection.Execute("sp_UpdateSTLInventory", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    
    }
}
