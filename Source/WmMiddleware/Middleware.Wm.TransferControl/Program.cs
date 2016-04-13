using Middleware.Jobs;
using Middleware.Wm.TransferControl.DependencyInjection;

namespace Middleware.Wm.TransferControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
