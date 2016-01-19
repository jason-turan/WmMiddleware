using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Jobs;
using WmMiddleware.StlInventoryUpdate.DependencyInjection;

namespace WmMiddleware.StlInventoryUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IStlInventoryUpdateJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
