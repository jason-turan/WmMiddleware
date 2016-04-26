using Microsoft.Azure.WebJobs;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Domain.OrderManagement;
using Middleware.Wm.Service.Inventory.Repository;
using Middleware.Wm.Service.Inventory.WebJob.Models;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    public class TransferProductQueueHandler
    {
        private IQueue _queue;
        private IWebsiteInventoryRepository _websiteInventoryRepository;

        public TransferProductQueueHandler(IQueue queue, IWebsiteInventoryRepository websiteInventoryRepository)
        {
            _queue = queue;
            _websiteInventoryRepository = websiteInventoryRepository;
        }


        public Task CreateTransfer_IncrementOwnership(
            [QueueTrigger(QueueNames.CreateTransferIncrementOwnership)] TransferProductData message)
        {
            return Task.Run(() =>
            {
                _websiteInventoryRepository.UpdateAvailableInventory(message.GainingStoreId, message.ProductsTransferred);
                //_queue.QueueWorkItem("next", message);
            });
        }
    }
}
