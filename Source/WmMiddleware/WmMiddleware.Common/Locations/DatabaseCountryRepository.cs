using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using Dapper;
using WmMiddleware.Common.Annotations;
using WmMiddleware.Configuration.Database;

namespace WmMiddleware.Common.Locations
{
    public class DatabaseCountryRepository : ICountryReader
    {
        readonly MemoryCache _cache = new MemoryCache("WmMiddleware.Common.Locations.DatabaseCountryRepository");

        public int GetCountryCode(string countryAbbreviation)
        {
            var country = GetCountryCodesInternal().FirstOrDefault(cc => cc.Abbreviation.Equals(countryAbbreviation, StringComparison.InvariantCultureIgnoreCase));
            if (country == null)
            {
                throw new ArgumentOutOfRangeException("countryAbbreviation", string.Format("No country found with abbreviation '{0}'", countryAbbreviation));
            }

            return country.Code;
        }

        public string GetCountryAbbreviation(int countryCode)
        {
            if (countryCode == 0)
            {
                return null;
            }

            var country = GetCountryCodesInternal().FirstOrDefault(cc => cc.Code == countryCode);
            if (country == null)
            {
                throw new ArgumentOutOfRangeException("countryCode", string.Format("No country found with code '{0}'", countryCode));
            }

            return country.Abbreviation;
        }

        private IEnumerable<CountryCode> GetCountryCodesInternal()
        {
            const string cacheKey = "GetCountryCodesInternal_Key";
            var cachedConfiguration = _cache.GetCacheItem(cacheKey);
            ICollection<CountryCode> countryCodes;
            if (cachedConfiguration != null)
            {
                countryCodes = (ICollection<CountryCode>)cachedConfiguration.Value;
            }
            else
            {
                using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
                {
                    connection.Open();
                    countryCodes = connection.Query<CountryCode>("SELECT * FROM CountryCodes").ToList();
                    _cache.Add(new CacheItem(cacheKey, countryCodes), new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(5)) });
                }
            }
            return countryCodes;
        }

        private class CountryCode
        {
            [UsedImplicitly]
            public string Abbreviation { get; set; }
            [UsedImplicitly]
            public string Name { get; set; }
            [UsedImplicitly]
            public int Code { get; set; }
        }
    }
}
