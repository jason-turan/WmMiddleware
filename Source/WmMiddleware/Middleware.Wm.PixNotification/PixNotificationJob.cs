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

            NotifyReceivedPurchaseOrders();
            NotifyStockedPurchaseOrders();
        }

        private void NotifyStockedPurchaseOrders()
        {
            _log.Info("Searching for completed purchase orders");
            var purchaseOrderReceiptNotificationRecords = _repository.FindPerpetualInventoryTransfers(
               new PerpetualInventoryTransactionCriteria()
               {
                   ProcessType = ProcessType.PixNotification,
                   TransactionType = TransactionType.QuantityAdjust,
                   TransactionCode = TransactionCode.PurchaseOrder
               });

            var poReceiptGroup = purchaseOrderReceiptNotificationRecords
                .Where(por => !String.IsNullOrWhiteSpace(por.Ponumber))
                .GroupBy(po => po.Ponumber)
                .ToList();

            foreach (var poReceiptRecordGroup in poReceiptGroup)
            {
                _log.Info(String.Format("Processing Po Receipt {0}", poReceiptRecordGroup.Key));
                var criteria = new PerpetualInventoryTransactionCriteria()
                {
                    ProcessType = ProcessType.PixNotification,
                    PurchaseOrderNumber = poReceiptRecordGroup.Key,
                    TransactionType = TransactionType.InventoryAdjustment
                };
                var inventoryAdjustmentsForPo = _repository.FindPerpetualInventoryTransfers(criteria);
                _log.Info(String.Format(
                            "Found {0} adjustments for Po Receipt {1}",
                            inventoryAdjustmentsForPo.Count(),
                            poReceiptRecordGroup.Key));

                var productQuantities = inventoryAdjustmentsForPo
                    .Where(ia => !String.IsNullOrWhiteSpace(ia.PackageBarcode))
                    .GroupBy(ia => ia.PackageBarcode)
                    .Select(grp =>
                        new ProductQuantity(
                            grp.Key,
                            grp.Sum(item => GetQuantity(item)))).ToList();

                var poReceipt = new PurchaseOrderStockedEvent(
                        poReceiptRecordGroup.First().Ponumber,
                        poReceiptRecordGroup.Max(poGroup =>
                        MainframeExtensions.ParseDateTime(poGroup.DateCreated, poGroup.TimeCreated)),
                        productQuantities);
                var toMarkComplete = poReceiptRecordGroup.Concat(inventoryAdjustmentsForPo).ToList();
                NotifyServiceAndMarkComplete(toMarkComplete, () =>
                {
                    _apiAccess.PurchaseOrderStocked(poReceipt);
                });
            }
        }

        private void NotifyReceivedPurchaseOrders()
        {
            var criteria = new PerpetualInventoryTransactionCriteria()
            {
                ProcessType = ProcessType.PixNotification,
                TransactionType = TransactionType.NonAllocatable
            };
            var nonAllocatableInventoryAdjustments = _repository.FindPerpetualInventoryTransfers(criteria);
            var adjustmentsToIgnore = nonAllocatableInventoryAdjustments.Where(adj => String.IsNullOrWhiteSpace(adj.Ponumber)).ToList();
            MarkRecordsAsProcessed(adjustmentsToIgnore);

            var recordsWithPos = nonAllocatableInventoryAdjustments.Except(adjustmentsToIgnore).ToList();
            var distinctPos = recordsWithPos.Select(item => item.Ponumber).Distinct().ToList();

            foreach (var poNumber in distinctPos)
            {
                var hasBeenNotified = _repository.HasPurchaseOrderBeenNotified(poNumber);
                if (!hasBeenNotified)
                {
                    var firstPoInventoryAdjustment = recordsWithPos
                        .Where(r => r.Ponumber == poNumber)
                        .OrderBy(r => MainframeExtensions.ParseDateTime(r.DateCreated, r.TimeCreated))
                        .First();
                    var receipt = new PurchaseOrderReceiptEvent(
                        firstPoInventoryAdjustment.Ponumber,
                        MainframeExtensions.ParseDateTime(firstPoInventoryAdjustment.DateCreated, firstPoInventoryAdjustment.TimeCreated));
                    try
                    {
                        _apiAccess.PurchaseOrderReceived(receipt);
                    }
                    catch (Exception ex)
                    {
                        _log.Exception("Failed to notify service of PO Receipt", ex);
                    }
                    _repository.InsertPurchaseOrderNotified(poNumber);
                }
            }
        }

        private int GetQuantity(ManhattanPerpetualInventoryTransfer r)
        {
            var modifier = r.InventoryAdjustmntType == "S" ? -1 : 1;
            return (int)r.InventoryAdjustmentQuantity * modifier;
        }

        private void NotifyServiceAndMarkComplete(IEnumerable<ManhattanPerpetualInventoryTransfer> recordsToProcess, Action notifyAction)
        {
            try
            {
                notifyAction();
            }
            catch (Exception ex)
            {
                var ids = String.Join(",", recordsToProcess.Select(r => r.ManhattanPerpetualInventoryTransferId));
                _log.Exception(String.Format("Failed to notify service for pix ids {0}.", ids), ex);
                throw;
            }
            MarkRecordsAsProcessed(recordsToProcess);

        }

        private void MarkRecordsAsProcessed(IEnumerable<ManhattanPerpetualInventoryTransfer> recordsToProcess)
        {
            foreach (var record in recordsToProcess)
            {
                try
                {
                    _repository.InsertManhattanPerpetualInventoryNotificationProcessing(record.ManhattanPerpetualInventoryTransferId);
                }
                catch (Exception ex)
                {
                    var message = String.Format("Failed to insert notification processed record {0}", record.ManhattanPerpetualInventoryTransferId);
                    _log.Exception(message, ex);
                }
            }
        }
    }
}
