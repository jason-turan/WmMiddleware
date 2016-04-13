using Middleware.Jobs;
using Middleware.Wm.Aurora.Shipment.DependencyInjection;

namespace Middleware.Wm.Aurora.Shipment
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
