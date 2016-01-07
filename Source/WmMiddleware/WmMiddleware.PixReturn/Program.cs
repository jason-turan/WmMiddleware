using Middleware.Jobs;
using WmMiddleware.PixReturn.DependencyInjection;

namespace WmMiddleware.PixReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IPixReturnJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
