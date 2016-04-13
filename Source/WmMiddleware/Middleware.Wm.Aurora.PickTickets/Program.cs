using Middleware.Jobs;
using Middleware.Wm.Aurora.PickTickets.DependencyInjection;

namespace Middleware.Wm.Aurora.PickTickets
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
