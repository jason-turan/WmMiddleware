using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using Ninject;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Domain.QueueProcessors;
using Middleware.Wm.Service.Contracts.Models;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    public class PurchaseOrderQueueHandlers
    {
        private StockedAdjustInventoryQueueProcessor _adjustInventoryQueueProcessor;
        private ReceivedOnLocationNotifyRibaQueueProcessor _ribaQueueProcessor;

        public PurchaseOrderQueueHandlers(
            ReceivedOnLocationNotifyRibaQueueProcessor ribaQueueProcessor,
            StockedAdjustInventoryQueueProcessor adjustInventoryQueueProcessor)
        {
            _ribaQueueProcessor = ribaQueueProcessor;
            _adjustInventoryQueueProcessor = adjustInventoryQueueProcessor;
        }


        public Task ReceivedOnLocation_NotifyRiba(
            [QueueTrigger(QueueNames.ReceivedOnLocationNotifyRiba)] PurchaseOrderReceiptEvent message)
        {
            return Task.Run(() =>
            {
                _ribaQueueProcessor.Execute(message);
            });
        }


        public Task Stocked_AdjustInventory(
            [QueueTrigger(QueueNames.StockedAdjustInventory)] PurchaseOrderStockedEvent message)
        {
            return Task.Run(() =>
            {
                _adjustInventoryQueueProcessor.Execute(message);
            });
        }

    }
}
