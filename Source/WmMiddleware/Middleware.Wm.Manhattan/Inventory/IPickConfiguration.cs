using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Manhattan.Inventory
{
    public interface IPickConfiguration : IMainframeConfiguration
    {
        Address GetWarehouseAddress();
    }
}
