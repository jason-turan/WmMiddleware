using System;
using WmMiddleware.Configuration.Manhattan;

namespace WmMiddleware.ProductUpdating.Configuration
{
    public interface IProductUpdatingConfiguration : IManhattanConfiguration
    {
        DateTime GetLastSuccessfulRun();
        void SetLastSuccessfulRun(DateTime timeRun);
    }
}
