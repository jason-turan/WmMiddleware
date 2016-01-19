using Middleware.Jobs;
using WmMiddleware.Shipment.DependencyInjection;

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
