using Middleware.Jobs;
using WmMiddleware.StlInventorySync.DependencyInjection;

namespace WmMiddleware.StlInventorySync
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
