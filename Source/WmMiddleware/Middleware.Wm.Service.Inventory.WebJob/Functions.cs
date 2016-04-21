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

namespace Middleware.Wm.Service.Inventory.WebJob
{
    public class QueueHandlers
    {
        private IKernel _kernel;

        public QueueHandlers(IKernel kernel)
        {
            _kernel = kernel;
        }


        public Task ReceivedOnLocation_NotifyRiba(
            [QueueTrigger(QueueNames.ReceivedOnLocationNotifyRiba)] PurchaseOrder message)
        {
            return Task.Run(() =>
            {
                var qp = _kernel.Get<ReceivedOnLocationNotifyRibaQueueProcessor>();
                qp.Execute(message);
            });
        }
    }
}
