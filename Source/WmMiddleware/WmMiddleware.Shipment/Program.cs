using Middleware.Jobs;
using WmMiddleware.Shipment.DependencyInjection;

namespace WmMiddleware.Shipment
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IShipmentJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
