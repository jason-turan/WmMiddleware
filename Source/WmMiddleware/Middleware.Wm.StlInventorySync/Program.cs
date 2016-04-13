using Middleware.Jobs;
using Middleware.Wm.StlInventorySync.DependencyInjection;

namespace Middleware.Wm.StlInventorySync
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
