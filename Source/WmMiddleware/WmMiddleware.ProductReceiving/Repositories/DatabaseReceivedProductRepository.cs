using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;
using WmMiddleware.ProductReceiving.Models;

namespace WmMiddleware.ProductReceiving.Repositories
{
    public class DatabaseReceivedProductRepository : IReceivedProductReader
    {
        public IEnumerable<IReceivedProduct> GetPurchaseOrders()
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return GroupProducts(connection.Query<DatabasePurchaseOrder>("sp_GetNewPurchaseOrders")).ToList();
            }
        }

        public IEnumerable<IReceivedProduct> GetAutomatedShippingNotifications()
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return GroupProducts(connection.Query<DatabaseAutomatedShippingNotification>("sp_GetNewShippingNotifications")).ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<IReceivedProduct> products)
        {
            var productList = products.ToList();
            SetAsProcessed(productList.OfType<AutomatedShippingNotification>());
            SetAsProcessed(productList.OfType<PurchaseOrder>());
        }

        private void SetAsProcessed(IEnumerable<AutomatedShippingNotification> products)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                var shippingNotificationTable = new DataTable();
                shippingNotificationTable.Columns.Add("IDInterfaceShipmentConfirmationHeader");
                foreach (var product in products)
                {
                    shippingNotificationTable.Rows.Add(product.IdInterfaceShipmentConfirmationHeader);
                }

                var parameter = new
                {
                    ShippingNotificationTable = shippingNotificationTable.AsTableValuedParameter("[dbo].[ShippingNotificationTable]"),
                    Status = "READ"
                };

                connection.Open();
                connection.Execute("sp_UpdateShippingNotificationStatus", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        private void SetAsProcessed(IEnumerable<PurchaseOrder> products)
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                var poTable = new DataTable();
                poTable.Columns.Add("PONumber");
                foreach (var product in products)
                {
                    poTable.Rows.Add(product.ExternalUid);
                }

                var parameter = new
                {
                    PurchaseOrderTable = poTable.AsTableValuedParameter("[dbo].[PurchaseOrderTable]"),
                    Status = "CADRE"
                };

                connection.Open();
                connection.Execute("sp_UpdatePurchaseOrderStatus", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        private static IEnumerable<PurchaseOrder> GroupProducts(IEnumerable<DatabasePurchaseOrder> purchaseOrders)
        {
            var groupedTickets = purchaseOrders.GroupBy(po => po.ExternalUID);
            foreach (var group in groupedTickets)
            {
                var purchaseOrder = group.First().ToPurchaseOrder();
                foreach (var item in group.GroupBy(po => po.SKU))
                {
                    var lineItem = item.First().ToLineItem();
                    lineItem.QuantityOrdered = item.Sum(i => i.QtyOrd);
                    purchaseOrder.Items.Add(lineItem);
                }
                yield return purchaseOrder;
            }
        }

        private static IEnumerable<AutomatedShippingNotification> GroupProducts(IEnumerable<DatabaseAutomatedShippingNotification> automatedShippingNotifications)
        {
            var groupedNotifications = automatedShippingNotifications.GroupBy(asn => asn.ExternalUID);
            foreach (var group in groupedNotifications)
            {
                var asn = group.First().ToAutomatedShippingNotification();
                foreach (var item in group.GroupBy(a => a.SKU))
                {
                    var asnItem = item.First().ToAutomatedShippingNotificationItem();
                    asnItem.CartonQuantity = item.Sum(i => i.CartonQTY);
                    asnItem.EachQuantity = item.Sum(i => i.EachQty);
                    asnItem.PalletQuantity = item.Sum(i => i.PalletQTY);
                    asn.Items.Add(asnItem);
                }
                yield return asn;
            }
        }
    }
}
