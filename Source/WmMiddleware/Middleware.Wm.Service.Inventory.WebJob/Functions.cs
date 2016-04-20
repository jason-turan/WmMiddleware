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
    public class Functions
    {
        public static void ReceivedOnLocation_NotifyRiba(
            [QueueTrigger(QueueNames.ReceivedOnLocationNotifyRiba)] PurchaseOrder message,
            IKernel kernel)
        {
            var qp = kernel.Get<ReceivedOnLocationNotifyRibaQueueProcessor>();
            qp.Execute(message);
        }
    }
}
