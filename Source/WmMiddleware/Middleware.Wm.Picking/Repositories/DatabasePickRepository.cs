using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Inventory;
using Middleware.Wm.Picking.Models;

namespace Middleware.Wm.Picking.Repositories
{
    public class DatabasePickRepository : IOrderReader
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return GroupOrders(connection.Query<DatabasePickTicket>("sp_GetNewOrders")).ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<Order> orders)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                var orderTable = new DataTable();
                orderTable.Columns.Add("OrderNumber");
                foreach (var order in orders)
                {
                    orderTable.Rows.Add(order.OrderNumber);
                }

                var parameter = new
                {
                    OrderNumberTable = orderTable.AsTableValuedParameter("[dbo].[OrderNumberTable]"),
                    Status = "READ"
                };

                connection.Open();
                connection.Execute("sp_UpdateOrderStatus", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        private static IEnumerable<Order> GroupOrders(IEnumerable<DatabasePickTicket> pickTickets)
        {
            var groupedTickets = pickTickets.GroupBy(t => t.HeaderId);
            foreach (var group in groupedTickets)
            {
                var order = group.First().ToOrder();
                foreach (var item in group.Select(i => i.ToLineItem()))
                {
                    order.Items.Add(item);
                }
                PopulateSpecialInstructions(order);
                yield return order;
            }
        }

        private static void PopulateSpecialInstructions(Order order)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                var table = new DataTable();
                table.Columns.Add("SKU", typeof(string));
                foreach (var sku in order.Items.Select(i => i.ItemSku))
                {
                    table.Rows.Add(sku);
                }

                var skuParameter = new SqlParameter("@SKUs", table);

                connection.Open();
                foreach (var instruction in connection.Query<string>("sp_GetSpecialInstructions", skuParameter))
                {
                    order.SpecialInstructions.Add(instruction);
                }
            }
        }
    }
}
