using Middleware.Alerts.DependencyInjection;
using Middleware.Jobs;

namespace Middleware.Alerts
{
    class Program 
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IAlertJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration());
        }
    }
}
