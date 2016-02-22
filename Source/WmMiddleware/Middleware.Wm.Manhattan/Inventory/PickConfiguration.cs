using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Manhattan.Inventory
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
