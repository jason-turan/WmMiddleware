using Ninject;
using Quartz;
using Quartz.Spi;

namespace Middleware.Scheduler.WindowService.DependencyInjection
{
    public class NinjectQuartzFactory : IJobFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectQuartzFactory(IKernel ninjectKernel)
        {
            _ninjectKernel = ninjectKernel;
        }

        public IJob NewJob(TriggerFiredBundle bundle, 
                           IScheduler scheduler)
        {
            return (IJob)_ninjectKernel.Get(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
