using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public class Queue : IQueue
    {
        private IQueueFactory _factory;

        public Queue(IQueueFactory factory)
        {
            _factory = factory;
        }

        public void QueueWorkItem(string queueName, object entity)
        {
            var queue = _factory.GetQueueReference(queueName);
            var queueMessage = new CloudQueueMessage(JsonConvert.SerializeObject(entity));
            queue.AddMessage(queueMessage);
        }
    }
}
