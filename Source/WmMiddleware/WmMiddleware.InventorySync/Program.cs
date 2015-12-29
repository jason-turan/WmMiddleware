using WmMiddleware.InventorySync.DependencyInjection;
using Middleware.Jobs;

namespace WmMiddleware.InventorySync
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IInventorySyncJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration());
        }
    }
}
