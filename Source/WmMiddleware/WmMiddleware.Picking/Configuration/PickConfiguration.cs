using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Manhattan;
using MiddleWare.Log;
using WmMiddleware.Picking.Models;

namespace WmMiddleware.Picking.Configuration
{
    public class PickConfiguration : ManhattanConfiguration, IPickConfiguration
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
