using Middleware.Wm.Inventory;
using WmMiddleware.Configuration.Mainframe;

namespace WmMiddleware.Picking.Configuration
{
    public interface IPickConfiguration : IMainframeConfiguration
    {
        Address GetWarehouseAddress();
    }
}
