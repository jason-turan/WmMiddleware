using Middleware.Jobs;
using WmMiddleware.Pix.DependencyInjection;

namespace WmMiddleware.Pix
{
    public class Program
    {
        static void Main()
        {
            UnitOfWorkExecutionProxy<IPixJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration());
        }
    }
}
