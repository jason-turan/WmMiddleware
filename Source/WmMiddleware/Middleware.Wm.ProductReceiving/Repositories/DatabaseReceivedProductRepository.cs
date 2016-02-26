using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.ProductReceiving.Models;

namespace Middleware.Wm.ProductReceiving.Repositories
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

        public IEnumerable<IReceivedProduct> GetPurchaseReturns()
        {
            using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
            {
                connection.Open();
                return GroupReturns(connection.Query<DatabasePurchaseReturn>("sp_GetReturnReasonsFromROW")).ToList();
            }
        }

        public void SetAsProcessed(IEnumerable<IReceivedProduct> products)
        {
            var productList = products.ToList();
            SetAsProcessed(productList.OfType<AutomatedShippingNotification>());
            SetAsProcessed(productList.OfType<PurchaseOrder>());
            SetAsProcessed(productList.OfType<PurchaseReturn>());
        }

        private static void SetAsProcessed(IEnumerable<PurchaseReturn> purchaseReturns)
        {
            foreach (var purchaseReturn in purchaseReturns)
            {
                foreach (var lineItem in purchaseReturn.Items)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@rowId", lineItem.ExternalId);
                    parameters.Add("@ProcessedDate", DateTime.Now);

                    using (var connection = DatabaseConnectionFactory.GetNbxWebConnection())
                    {
                        connection.Execute("sp_InsertReturnReasonFromROWProcessing", 
                                            parameters, 
                                            commandType: CommandType.StoredProcedure);
                    }   
                }
            }
        }

        private static void SetAsProcessed(IEnumerable<AutomatedShippingNotification> products)
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

        private static void SetAsProcessed(IEnumerable<PurchaseOrder> products)
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

        private static IEnumerable<PurchaseReturn> GroupReturns(IEnumerable<DatabasePurchaseReturn> purchaseReturns)
        {
            var groupedTickets = purchaseReturns.GroupBy(pr => pr.order_number).ToList();
            foreach (var group in groupedTickets)
            {
                var purchaseReturn = group.First().ToPurchaseReturn();
        
                foreach (var item in group.GroupBy(po => po.UPC))
                {
                    var lineItem = item.First().ToLineItem();
                    purchaseReturn.Items.Add(lineItem);
                    lineItem.TotalQuantity = item.Count();
                    purchaseReturn.QuantityOrdered = purchaseReturn.QuantityOrdered + lineItem.TotalQuantity;
                }

                yield return purchaseReturn;
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
                foreach (var item in group.GroupBy(a => new {a.SKU, a.ParentMUID}))
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
