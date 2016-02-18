using Middleware.Jobs;
using Middleware.Wm.Shipment.DependencyInjection;

namespace WmMiddleware.Shipment
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
