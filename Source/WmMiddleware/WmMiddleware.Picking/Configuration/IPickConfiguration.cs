using Middleware.Wm.Inventory;
using WmMiddleware.Configuration.Manhattan;

namespace WmMiddleware.Picking.Configuration
{
    public interface IPickConfiguration : IManhattanConfiguration
    {
        Address GetWarehouseAddress();
    }
}
