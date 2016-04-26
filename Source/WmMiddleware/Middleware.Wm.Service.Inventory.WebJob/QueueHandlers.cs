using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
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
            [QueueTrigger(QueueNames.ReceivedOnLocationNotifyRiba)] PurchaseOrderReceiptEvent message)
        {
            return Task.Run(() =>
            {
                var qp = _kernel.Get<ReceivedOnLocationNotifyRibaQueueProcessor>();
                qp.Execute(message);
            });
        }
    }
}
