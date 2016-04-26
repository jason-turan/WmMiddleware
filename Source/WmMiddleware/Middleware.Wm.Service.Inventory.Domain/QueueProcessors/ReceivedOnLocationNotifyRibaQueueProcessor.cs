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
            var poReceipt = new PurchaseOrderReceipt()
            {
                PONo = model.PurchaseOrderNumber,
                ReceiveDate = model.ReceiptDateTime,
                TransactionType = TransactionType.PurchaseOrderReceipt
            };
            _ribaSystem.SendPurchaseOrderReceipt(poReceipt);
        }
    }
}
