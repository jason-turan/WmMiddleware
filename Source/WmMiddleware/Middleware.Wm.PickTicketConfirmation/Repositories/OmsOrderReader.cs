using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Inventory;
using Middleware.Wm.PickTicketConfirmation.Models;

namespace Middleware.Wm.PickTicketConfirmation.Repositories
{
    public class OmsOrderReader : IOrderReader
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var connection = DatabaseConnectionFactory.GetGpConnection())
            {
                connection.Open();
                return GroupOrders(connection.Query<OmsOrderResult>("usp_GetBNCOrders")).ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<Order> orders)
        {
            using (var connection = DatabaseConnectionFactory.GetGpConnection())
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
                connection.Execute("[sp_UpdateBNCOrderStatus]", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        private static IEnumerable<Order> GroupOrders(IEnumerable<OmsOrderResult> orderResults)
        {
            var groupedTickets = orderResults.GroupBy(t => t.order_number);
            foreach (var group in groupedTickets)
            {
                var order = group.First().ToOrder();
                foreach (var item in group.Select(i => i.ToLineItem()))
                {
                    order.Items.Add(item);
                }
                yield return order;
            }
        }
    }
}
