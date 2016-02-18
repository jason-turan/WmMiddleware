using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Picking.Configuration
{
    public interface IPickConfiguration : IMainframeConfiguration
    {
        Address GetWarehouseAddress();
    }
}
