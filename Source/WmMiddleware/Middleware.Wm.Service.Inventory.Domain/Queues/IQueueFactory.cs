using Microsoft.WindowsAzure.Storage.Queue;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IQueueFactory
    {
        CloudQueue GetQueueReference(string queueName);
    }
}