using Middleware.Jobs;
using Middleware.Wm.ProductUpdating.DependencyInjection;

namespace Middleware.Wm.ProductUpdating
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
