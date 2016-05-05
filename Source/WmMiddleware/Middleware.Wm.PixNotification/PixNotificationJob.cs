using Middleware.Jobs;
using Middleware.Log;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Pix.Models;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Service.Contracts;
using Middleware.Wm.Service.Contracts.Models;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.PixNotification
{
    public class PixNotificationJob : IUnitOfWork
    {
        private IIventoryServiceApi _apiAccess;
        private ILog _log;
        private IPerpetualInventoryTransferRepository _repository;

        public PixNotificationJob(
            ILog log,
            IPerpetualInventoryTransferRepository repository,
            IIventoryServiceApi apiAccess)
        {
            _repository = repository;
            _apiAccess = apiAccess;
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _log.Info("Running " + jobKey);

            NotifyInventoryAdjustments();
            NotifyReceivedPurchaseOrders();
        }

        private void NotifyInventoryAdjustments()
        {
            _log.Info("Searching for inventory adjustments");
            var criteria = new PerpetualInventoryTransactionCriteria()
            {
                ProcessType = ProcessType.InventoryAdjustmentNotification,
                TransactionType = TransactionType.InventoryAdjustment
            };

            IEnumerable<ManhattanPerpetualInventoryTransfer> items = _repository.FindPerpetualInventoryTransfers(criteria);
            var nonPoStockedAdjustments = items.Where(item => String.IsNullOrWhiteSpace(item.Ponumber));
            var poStockedAdjustments = items.Except(nonPoStockedAdjustments).ToList();
            if (nonPoStockedAdjustments.Any())
            {
                NotifyPhysicalInventoryChanged(nonPoStockedAdjustments);                
            }
            if (poStockedAdjustments.Any())
            {
                NotifyStockedPurchaseOrders(poStockedAdjustments);
            }
        }

        private void NotifyPhysicalInventoryChanged(IEnumerable<ManhattanPerpetualInventoryTransfer> nonPoStockedAdjustments)
        {
            var physicalInventoryChanges = 
                nonPoStockedAdjustments
                    .GroupBy(item => item.TransactionReasonCode)
                    .Select(grp =>
                                {
                                    AdjustmentType? reasonCode = TryMapReasonToAdjustmentType(grp.Key);
                                    List<ProductQuantity> productQuantities = SumPixItems(grp);
                                    var adj = new PhysicalAdjustment(reasonCode, productQuantities);
                                    return adj;
                                }).ToList();
            _apiAccess.PhysicalInventoryChanged(physicalInventoryChanges);
            MarkNotificationRecordsAsProcessed(nonPoStockedAdjustments, ProcessType.InventoryAdjustmentNotification);
        }

        private AdjustmentType? TryMapReasonToAdjustmentType(string reasonCode)
        {
            switch (reasonCode)
            {
                case null:
                    return null;
                case "01":
                    return AdjustmentType.CycleCount;
                case "14":
                    return AdjustmentType.InventoryAdjustment;
                case "RC":
                    throw new NotImplementedException();
                case "SB":
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException($"Unrecognized reasoncode:{reasonCode}");
            }

        }

        private void NotifyStockedPurchaseOrders(List<ManhattanPerpetualInventoryTransfer> purchaseOrderReceiptNotificationRecords)
        { 
            var poReceiptGroup = purchaseOrderReceiptNotificationRecords 
                .GroupBy(po => po.Ponumber)
                .ToList();

            foreach (var poReceiptRecordGroup in poReceiptGroup)
            {
                _log.Info(String.Format("Processing Po Receipt {0}", poReceiptRecordGroup.Key)); 
                var productQuantities = SumPixItems(poReceiptRecordGroup.ToList());
                var stockedEvent = new PurchaseOrderStockedEvent(
                        poReceiptRecordGroup.First().Ponumber,
                        poReceiptRecordGroup.Max(poGroup =>
                            MainframeExtensions.ParseDateTime(poGroup.DateCreated, poGroup.TimeCreated)),
                        productQuantities); 
                _apiAccess.PurchaseOrderStocked(stockedEvent);
                MarkNotificationRecordsAsProcessed(poReceiptRecordGroup.ToList(), ProcessType.InventoryAdjustmentNotification);
            }
        }

        private List<ProductQuantity> SumPixItems(IEnumerable<ManhattanPerpetualInventoryTransfer> items)
        {
            var productQuantites = items
                    .Where(ia => !String.IsNullOrWhiteSpace(ia.PackageBarcode))
                    .GroupBy(ia => ia.PackageBarcode)
                    .Select(grp =>
                        new ProductQuantity(
                            grp.Key,
                            grp.Sum(item => GetQuantity(item)))).ToList();
            return productQuantites;
        }

        private void NotifyReceivedPurchaseOrders()
        {
            _log.Info("Searching for received purchase orders");
            var criteria = new PerpetualInventoryTransactionCriteria()
            {
                ProcessType = ProcessType.PurchaseOrderReceiptNotification,
                TransactionType = TransactionType.QuantityAdjust
            };

            var poReceiptRecords = _repository.FindPerpetualInventoryTransfers(criteria);
            var adjustmentsToIgnore = poReceiptRecords.Where(adj => String.IsNullOrWhiteSpace(adj.Ponumber)).ToList();

            MarkNotificationRecordsAsProcessed(adjustmentsToIgnore, ProcessType.PurchaseOrderReceiptNotification);

            var recordsWithPos = poReceiptRecords.Except(adjustmentsToIgnore).ToList();
            var distinctPos = recordsWithPos.Select(item => item.Ponumber).Distinct().ToList();

            foreach (var poNumber in distinctPos)
            {
                var receiptRecord = recordsWithPos.First(r => r.Ponumber == poNumber);
                var inventoryAdjustmentsForPo = _repository.FindPerpetualInventoryTransfers(
                    new PerpetualInventoryTransactionCriteria()
                    {
                        ProcessType = ProcessType.PurchaseOrderReceiptNotification,
                        PurchaseOrderNumber = poNumber,
                        TransactionType = TransactionType.InventoryAdjustment
                    });

                var firstPoInventoryAdjustment = recordsWithPos
                    .Where(r => r.Ponumber == poNumber)
                    .OrderBy(r => MainframeExtensions.ParseDateTime(r.DateCreated, r.TimeCreated))
                    .First();
                var receiptList = SumPixItems(inventoryAdjustmentsForPo);
                var receipt = new PurchaseOrderReceiptEvent(
                    firstPoInventoryAdjustment.Ponumber,
                    MainframeExtensions.ParseDateTime(firstPoInventoryAdjustment.DateCreated, firstPoInventoryAdjustment.TimeCreated),
                    receiptList
                    );
                try
                {
                    _apiAccess.PurchaseOrderReceived(receipt);
                }
                catch (Exception ex)
                {
                    _log.Exception("Failed to notify service of PO Receipt", ex);
                }
                var toMarkComplete = inventoryAdjustmentsForPo.Concat(new[] { receiptRecord }).ToList();
                MarkNotificationRecordsAsProcessed(toMarkComplete, ProcessType.PurchaseOrderReceiptNotification);
            }
        }

        private int GetQuantity(ManhattanPerpetualInventoryTransfer r)
        {
            var modifier = r.InventoryAdjustmntType == "S" ? -1 : 1;
            return (int)r.InventoryAdjustmentQuantity * modifier;
        }

        //private void NotifyServiceAndMarkComplete(IEnumerable<ManhattanPerpetualInventoryTransfer> recordsToProcess, Action notifyAction)
        //{
        //    try
        //    {
        //        notifyAction();
        //    }
        //    catch (Exception ex)
        //    {
        //        var ids = String.Join(",", recordsToProcess.Select(r => r.ManhattanPerpetualInventoryTransferId));
        //        _log.Exception(String.Format("Failed to notify service for pix ids {0}.", ids), ex);
        //        throw;
        //    }
        //    MarkRecordsAsProcessed(recordsToProcess);

        //}

        private void MarkNotificationRecordsAsProcessed(
            IEnumerable<ManhattanPerpetualInventoryTransfer> recordsToProcess,
            string processType)
        {
            foreach (var record in recordsToProcess)
            {
                try
                {
                    if (processType == ProcessType.PurchaseOrderReceiptNotification)
                    {
                        _repository.InsertPixPurchaseOrderReceiptNotificationProcessing(record.ManhattanPerpetualInventoryTransferId);
                    }
                    else if (processType == ProcessType.InventoryAdjustmentNotification)
                    {
                        _repository.InsertPixInventoryAdjustmentNotificationProcessing(record.ManhattanPerpetualInventoryTransferId);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unexpected processType {processType}");
                    }
                }
                catch (Exception ex)
                {
                    var message = $"Failed to insert notification processed record {record.ManhattanPerpetualInventoryTransferId}";
                    _log.Exception(message, ex);
                    throw;
                }
            }
        }
    }
}
