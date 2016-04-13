using Middleware.Jobs;
using Middleware.Wm.GeneralLedgerReconcilliation.DependencyInjection;

namespace Middleware.Wm.GeneralLedgerReconcilliation
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
