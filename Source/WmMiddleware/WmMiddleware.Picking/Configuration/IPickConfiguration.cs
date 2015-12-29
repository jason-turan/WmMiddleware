using WmMiddleware.Configuration.Manhattan;
using WmMiddleware.Picking.Models;

namespace WmMiddleware.Picking.Configuration
{
    public interface IPickConfiguration : IManhattanConfiguration
    {
        Address GetWarehouseAddress();
    }
}
