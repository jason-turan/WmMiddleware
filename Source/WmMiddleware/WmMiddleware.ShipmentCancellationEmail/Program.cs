using Middleware.Jobs;
using WmMiddleware.ShipmentCancellationEmail.DependencyInjection;

namespace WmMiddleware.ShipmentCancellationEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IShipmentCancellationEmailJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
