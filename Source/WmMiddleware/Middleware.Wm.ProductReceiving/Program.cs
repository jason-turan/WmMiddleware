using Middleware.Jobs;
using Middleware.Wm.ProductReceiving.DependencyInjection;

namespace Middleware.Wm.ProductReceiving
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
