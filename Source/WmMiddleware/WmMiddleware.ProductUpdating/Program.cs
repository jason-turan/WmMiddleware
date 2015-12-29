using Middleware.Jobs;
using WmMiddleware.ProductUpdating.DependencyInjection;

namespace WmMiddleware.ProductUpdating
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IProductUpdatingJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
