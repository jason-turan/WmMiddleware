using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using Middleware.Wm.Service.Inventory.Domain.Logging; 
using Middleware.Wm.Service.Contracts.Models;

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

        public void PurchaseOrderStocked(PurchaseOrderStockedEvent purchaseOrderStocked)
        {
            _logger.DumpInfo<PurchaseOrderEventHandler>(purchaseOrderStocked);
            _queue.QueueWorkItem(QueueNames.StockedAdjustInventory, purchaseOrderStocked);
        }

        public void PurchaseOrderReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            _logger.DumpInfo<PurchaseOrderEventHandler>(purchaseOrderReceiptEvent);
            _queue.QueueWorkItem(QueueNames.ReceivedOnLocationNotifyRiba, purchaseOrderReceiptEvent);             
        }
    }
}