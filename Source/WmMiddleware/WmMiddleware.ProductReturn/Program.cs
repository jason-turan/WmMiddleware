using Middleware.Jobs;
using WmMiddleware.ProductReturn.DependencyInjection;

namespace WmMiddleware.ProductReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IProductReturnJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
