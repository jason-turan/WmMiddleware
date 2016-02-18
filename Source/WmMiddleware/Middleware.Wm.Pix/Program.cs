using Middleware.Jobs;
using Middleware.Wm.Pix.DependencyInjection;

namespace WmMiddleware.Pix
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
