using Middleware.Jobs;
using WmMiddleware.Picking.DependencyInjection;

namespace WmMiddleware.Picking
{
    public class Program
    {
        static void Main()
        {
            UnitOfWorkExecutionProxy<IPickJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration());
        }
    }
}
