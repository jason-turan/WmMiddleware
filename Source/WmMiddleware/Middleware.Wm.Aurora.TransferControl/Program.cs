using Middleware.Jobs;
using Middleware.WM.Aurora.TransferControl.DependencyInjection;

namespace Middleware.WM.Aurora.TransferControl
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
