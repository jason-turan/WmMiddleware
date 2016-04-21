using System;
using Middleware.Wm.Service.Inventory.Models;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IQueue
    {
        void QueueWorkItem(string queueName, object entity);
    } 

}