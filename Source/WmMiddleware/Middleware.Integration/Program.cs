using Middleware.Integration.DependencyInjection;
using Middleware.Jobs;

namespace Middleware.Integration
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IntegrationJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
