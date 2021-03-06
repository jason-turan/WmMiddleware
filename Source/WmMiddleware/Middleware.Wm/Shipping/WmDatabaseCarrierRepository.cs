﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Caching;
using Dapper;
using Middleware.Wm.Configuration.Database;

namespace Middleware.Wm.Shipping
{
    public class WmDatabaseCarrierRepository : ICarrierReadRepository
    {
        private readonly bool _useThirdPartyBilling;
        private readonly MemoryCache _cache = new MemoryCache("Middleware.Wm.Shipping.DatabaseCarrierRespository");

        public WmDatabaseCarrierRepository(bool useThirdPartyBilling)
        {
            _useThirdPartyBilling = useThirdPartyBilling;
        }

        public string GetOmsShipMethod(string code)
        {
            var serviceCode = GetCachedServiceCodes().FirstOrDefault(sc => sc.IsThirdPartyBilling == _useThirdPartyBilling && sc.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            return serviceCode == null ? null : serviceCode.OmsShipMethod;
        }

        public string GetCode(string omsShipMethod)
        {
            var serviceCode = GetCachedServiceCodes().OrderBy(sc => sc.Code).FirstOrDefault(sc => sc.IsThirdPartyBilling == _useThirdPartyBilling && string.Equals(sc.OmsShipMethod, omsShipMethod, StringComparison.InvariantCultureIgnoreCase));
            return serviceCode == null ? null : serviceCode.Code;
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

        private static IEnumerable<ServiceCode> GetServiceCodes()
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
            public bool IsThirdPartyBilling { get; set; }
        }
    }
}
