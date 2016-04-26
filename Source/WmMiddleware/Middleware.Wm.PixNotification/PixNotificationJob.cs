using Middleware.Jobs;
using Middleware.Log;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Pix.Models;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Service.Contracts;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var purchaseOrderReceiptNotificationRecords = _repository.FindPerpetualInventoryTransfers(
               new PerpetualInventoryTransactionCriteria()
               {
                   ProcessType = ProcessType.PixNotification,
                   TransactionType = TransactionType.QuantityAdjust,
                   TransactionCode = TransactionCode.PurchaseOrder
               }); 

            foreach (var poReceiptRecordGroup in purchaseOrderReceiptNotificationRecords.GroupBy(po => po.Ponumber))
            {
                var criteria = new PerpetualInventoryTransactionCriteria()
                {
                    ProcessType = ProcessType.PixNotification,
                    PurchaseOrderNumber = poReceiptRecordGroup.Key,
                    TransactionType = TransactionType.InventoryAdjustment
                };
                var inventoryAdjustmentsForPo = _repository.FindPerpetualInventoryTransfers(criteria);
                var productQuantities = inventoryAdjustmentsForPo
                    .GroupBy(ia => ia.PackageBarcode)
                    .Select(grp =>
                        new ProductQuantity(
                            grp.Key,
                            grp.Sum(item => GetQuantity(item)))).ToList();

                var poReceipt = new PurchaseOrderReceiptEvent(
                        poReceiptRecordGroup.First().Ponumber,
                        poReceiptRecordGroup.Max(poGroup =>
                        MainframeExtensions.ParseDateTime(poGroup.DateCreated, poGroup.TimeCreated)),
                        productQuantities);
                var toMarkComplete = poReceiptRecordGroup.Concat(inventoryAdjustmentsForPo).ToList();
                NotifyServiceAndMarkComplete(toMarkComplete, () =>
                {
                    _apiAccess.ReceivedOnLocation(poReceipt);
                });                
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
                    throw;
                }
            }
        }
    }
}
