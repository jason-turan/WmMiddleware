namespace Middleware.Wm.Service.Inventory.Domain.QueueProcessors
{
    public interface IQueueProcessor<T>
    {
        void Execute(T model);
    }
}