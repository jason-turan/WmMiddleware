using Middleware.Jobs;
using Middleware.Wm.LoggingAndFileMaintenance.DependencyInjection;

namespace Middleware.Wm.LoggingAndFileMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
