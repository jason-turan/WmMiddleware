using Middleware.Jobs;
using WmMiddleware.Pix.DependencyInjection;

namespace WmMiddleware.Pix
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IPixJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
