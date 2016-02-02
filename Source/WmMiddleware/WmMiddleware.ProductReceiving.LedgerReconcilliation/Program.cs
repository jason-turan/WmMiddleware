using Middleware.Jobs;
using WmMiddleware.GeneralLedgerReconcilliation.DependencyInjection;

namespace WmMiddleware.GeneralLedgerReconcilliation
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
