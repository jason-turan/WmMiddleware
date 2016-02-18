using Middleware.Jobs;
using Middleware.Wm.PixReturn.DependencyInjection;

namespace Middleware.Wm.PixReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IUnitOfWork>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
