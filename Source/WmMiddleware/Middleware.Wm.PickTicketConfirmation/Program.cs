using Middleware.Jobs;
using Middleware.Wm.PickTicketConfirmation.DependencyInjection;

namespace Middleware.Wm.PickTicketConfirmation
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
