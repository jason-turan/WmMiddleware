using Middleware.Jobs;
using Middleware.Wm.ProductReceivingng.DependencyInjection;

namespace Middleware.Wm.ProductReceivingng
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
