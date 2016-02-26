using Middleware.Jobs;
using Middleware.Wm.ShipmentCancellationEmail.DependencyInjection;

namespace Middleware.Wm.ShipmentCancellationEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
