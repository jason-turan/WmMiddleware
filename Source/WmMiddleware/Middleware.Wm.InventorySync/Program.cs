using Middleware.Jobs;
using Middleware.Wm.InventorySync.DependencyInjection;

namespace Middleware.Wm.InventorySync
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
