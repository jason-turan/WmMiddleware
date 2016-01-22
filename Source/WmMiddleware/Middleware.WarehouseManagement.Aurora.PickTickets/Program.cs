using Middleware.Jobs;
using Middleware.WarehouseManagement.Aurora.PickTickets.DependencyInjection;

namespace Middleware.WarehouseManagement.Aurora.PickTickets
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
