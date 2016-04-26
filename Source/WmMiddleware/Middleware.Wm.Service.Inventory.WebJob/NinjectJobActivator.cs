using Microsoft.Azure.WebJobs.Host;
using Ninject;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    internal class NinjectJobActivator : IJobActivator
    {
        private StandardKernel _kernel;

        public NinjectJobActivator(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public T CreateInstance<T>()
        {
            return _kernel.TryGet<T>();
        }
    }
}