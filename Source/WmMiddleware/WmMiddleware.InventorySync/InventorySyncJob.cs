using MiddleWare.Log;

namespace WmMiddleware.InventorySync
{
    public class InventorySyncJob : IInventorySyncJob
    {
        private readonly ILog _log;

        public InventorySyncJob(ILog log)
        {
            _log = log;
        }

        public void RunUnitOfWork()
        {
            _log.Info("I have ran");
        }
    }
}
