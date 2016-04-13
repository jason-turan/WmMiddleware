using Middleware.Jobs;
using Middleware.Wm.StlInventoryUpdate.DependencyInjection;

namespace Middleware.Wm.StlInventoryUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IStlInventoryUpdateJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
