using Middleware.Wm.Inventory;
using WmMiddleware.Configuration;
using MiddleWare.Log;
using WmMiddleware.Configuration.Mainframe;

namespace WmMiddleware.Picking.Configuration
{
    public class PickConfiguration : MainframeConfiguration, IPickConfiguration
    {
        public PickConfiguration(ILog log) : base(log)
        {
        }

        public Address GetWarehouseAddress()
        {
            return new Address
            {
                Line1 = GetKey<string>(ConfigurationKey.WarehouseAddressLine1),
                City = GetKey<string>(ConfigurationKey.WarehouseAddressCity),
                State = GetKey<string>(ConfigurationKey.WarehouseAddressState),
                Zip = GetKey<string>(ConfigurationKey.WarehouseAddressZipCode),
                Country = GetKey<string>(ConfigurationKey.WarehouseAddressCountry)
            };
        }
    }
}
