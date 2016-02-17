using Middleware.Jobs;
using WmMiddleware.Picking.DependencyInjection;

namespace WmMiddleware.Picking
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
