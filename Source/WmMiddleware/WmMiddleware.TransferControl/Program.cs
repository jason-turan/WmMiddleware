using Middleware.Jobs;
using WmMiddleware.TransferControl.DependencyInjection;

namespace WmMiddleware.TransferControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<ITransferControlJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
