using Middleware.Wm.Service.Inventory.Domain.Extensions;
using Middleware.Wm.Service.Inventory.Domain.Logging;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using System;
using System.Linq;

namespace Middleware.Wm.Service.Inventory.Domain.QueueProcessors
{
    public class ReceivedOnLocationNotifyRibaQueueProcessor : IQueueProcessor<PurchaseOrderReceiptEvent>
    {
        public IRibaSystem _ribaSystem;
        public IPurchaseOrderRepository _repository;
        private ILogger _logger;

        public ReceivedOnLocationNotifyRibaQueueProcessor(
            IRibaSystem system,
            IPurchaseOrderRepository repository,
            ILogger logger)
        {
            _ribaSystem = system;
            _repository = repository;
            _logger = logger;
        }

        public void Execute(PurchaseOrderReceiptEvent model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            if (String.IsNullOrWhiteSpace(model.PurchaseOrderNumber))
            {
                throw new InvalidOperationException("Cannot process event with empty purchase order number");
            }
            var po = _repository.GetPurchaseOrder(model.PurchaseOrderNumber);
            if (po == null)
            {
                throw new InvalidOperationException("Purchase Order Number {0} not found".FormatWith(model.PurchaseOrderNumber));
            }

            var skus = model.ReceiptList.Select(receipt =>
            {
                var matchingItemInPo = po.ProductsStocked.FirstOrDefault(ps => ps.Upc.EqualsIgnoreCase(receipt.UPC));

                if (matchingItemInPo == null)
                {
                    var warningMessage = String.Format("Received receipt for product that is not in PO. PO Number:{0} UPC:{1}", model.PurchaseOrderNumber, receipt.UPC);
                    _logger.DumpWarning<ReceivedOnLocationNotifyRibaQueueProcessor>(warningMessage, new object[] { model, po });
                }

                return new Sku()
                {
                    UPCNo = receipt.UPC,
                    UnitsReceived = matchingItemInPo.Quantity
                };
            }).ToList();
            var poReceipt = new PurchaseOrderReceipt()
            {
                PONo = model.PurchaseOrderNumber,
                ReceiveDate = model.ReceiptDateTime,
                Skus = skus,
                LocationCode = po.StoreId,
                TransactionType = TransactionType.PurchaseOrderReceipt
            };
            _ribaSystem.SendPurchaseOrderReceipt(poReceipt);
        }
    }
}
