using Middleware.Wm.Service.Inventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace Middleware.Wm.Service.Inventory.Factories
{
    public class QueueFactory : IQueueFactory
    {
        public CloudQueue GetQueueReference(string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ToString());
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);
            return queue;
        }
    }
}