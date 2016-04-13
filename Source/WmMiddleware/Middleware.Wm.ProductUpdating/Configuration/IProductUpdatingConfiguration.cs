using System;
using Middleware.Wm.Configuration.Mainframe;

namespace Middleware.Wm.ProductUpdating.Configuration
{
    public interface IProductUpdatingConfiguration : IMainframeConfiguration
    {
        DateTime? GetLastSuccessfulRun();
        void SetLastSuccessfulRun(DateTime timeRun);
    }
}
