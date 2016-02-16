using System;
using WmMiddleware.Configuration.Mainframe;

namespace WmMiddleware.ProductUpdating.Configuration
{
    public interface IProductUpdatingConfiguration : IMainframeConfiguration
    {
        DateTime? GetLastSuccessfulRun();
        void SetLastSuccessfulRun(DateTime timeRun);
    }
}
