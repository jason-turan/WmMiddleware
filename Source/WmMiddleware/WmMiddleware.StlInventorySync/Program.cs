using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Jobs;
using WmMiddleware.StlInventorySync.DependencyInjection;

namespace WmMiddleware.StlInventorySync
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkExecutionProxy<IStlInventorySyncJob>.ExecuteUnitOfWork(new NinjectModuleConfiguration(), args);
        }
    }
}
