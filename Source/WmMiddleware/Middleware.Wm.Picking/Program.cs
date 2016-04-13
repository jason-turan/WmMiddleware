using Middleware.Jobs;
using Middleware.Wm.Picking.DependencyInjection;

namespace Middleware.Wm.Picking
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
