using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Caching;
using Dapper;
using WmMiddleware.Configuration.Database;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Repositories
{
    public class DatabaseCarrierRespository : ICarrierReadRepository
    {
        private readonly MemoryCache _cache = new MemoryCache("Middleware.WarehouseManagement.Aurora.PickTickets.Repositories.DatabaseCarrierRespository");

        public string GetOmsShipMethod(string code)
        {
            var serviceCode = GetCachedServiceCodes().FirstOrDefault(sc => sc.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            return serviceCode == null ? null : serviceCode.OmsShipMethod;
        }

        private IEnumerable<ServiceCode> GetCachedServiceCodes()
        {
            const string cacheKey = "GetServiceCodes_Key";
            var cachedConfiguration = _cache.GetCacheItem(cacheKey);
            var serviceCodes = cachedConfiguration != null
                ? (List<ServiceCode>) cachedConfiguration.Value
                : GetServiceCodes().ToList();

            return serviceCodes;
        }

        private IEnumerable<ServiceCode> GetServiceCodes()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                return connection.Query<ServiceCode>("SELECT * FROM CarrierServiceCodes");
            }
        }

        [SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class ServiceCode
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public string OmsShipMethod { get; set; }
        }
    }
}
