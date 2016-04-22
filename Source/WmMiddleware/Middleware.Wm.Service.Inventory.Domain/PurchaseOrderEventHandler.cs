using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using Middleware.Wm.Service.Inventory.Domain.Logging;
using Middleware.Wm.Service.Inventory.Domain.Models;
using Middleware.Wm.Service.Inventory.Domain.Extensions;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public class PurchaseOrderEventHandler : IPurchaseOrderEventHandler
    {
        private ILogger _logger;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IQueue _queue;

        public PurchaseOrderEventHandler(
            IQueue queue,
            IPurchaseOrderRepository repository,
            ILogger logger)
        {
            _queue = queue;
            _purchaseOrderRepository = repository;
            _logger = logger;
        }


        public void InventoryStocked(List<ProductQuantity> stockedQuantities)
        {
            throw new NotImplementedException();
        }

        public void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            _logger.DumpInfo<PurchaseOrderEventHandler>(purchaseOrderReceiptEvent);
            var po = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderReceiptEvent.PurchaseOrderNumber);
            if (po != null)
            {
                _queue.QueueWorkItem(QueueNames.ReceivedOnLocationNotifyRiba, purchaseOrderReceiptEvent);
            }
            else
            {
                throw new InvalidOperationException("Po number {0} not found".FormatWith(purchaseOrderReceiptEvent.PurchaseOrderNumber));
            }
        }
    }
}