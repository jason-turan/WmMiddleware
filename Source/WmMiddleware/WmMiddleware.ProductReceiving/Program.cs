using Middleware.Jobs;
using WmMiddleware.ProductReceiving.DependencyInjection;

namespace WmMiddleware.ProductReceiving
{
    public class Program
    {
        static void Main()
        {
            UnitOfWorkExecutionProxy<IProductReceivingJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration());
        }
    }
}
