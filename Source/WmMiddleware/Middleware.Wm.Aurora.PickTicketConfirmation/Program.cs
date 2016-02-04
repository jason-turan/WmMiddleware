using Middleware.Jobs;
using Middleware.Wm.Aurora.PickTicketConfirmation.DependencyInjection;

namespace Middleware.Wm.Aurora.PickTicketConfirmation
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
