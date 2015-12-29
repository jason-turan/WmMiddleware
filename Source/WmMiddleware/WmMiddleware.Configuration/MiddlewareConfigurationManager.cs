using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using Dapper;
using WmMiddleware.Configuration.Database;
using MiddleWare.Log;

namespace WmMiddleware.Configuration
{
    public class MiddlewareConfigurationManager : IConfigurationManager
    {
        readonly MemoryCache _cache = new MemoryCache("WmMiddleware.Common.Configuration.DatabaseConfigurationManager");

        private readonly ILog _log;

        public MiddlewareConfigurationManager(ILog log)
        {
            _log = log;
        }

        public T GetKey<T>(string key, T defaultValue = default(T))
        {
            var xmlValue = ConfigurationManager.AppSettings.Get(key);
            
            const string cacheKey = "GetKey_Key";
            var cachedConfiguration = _cache.GetCacheItem(cacheKey);
            Dictionary<string, string> configurationMappings;
            if (cachedConfiguration != null)
            {
                configurationMappings = (Dictionary<string, string>)cachedConfiguration.Value;
            }
            else
            {
                using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
                {
                    connection.Open();
                    var enviornmentSetting = Environment.GetEnvironmentVariable("WmMiddlewareEnvrionment", 
                                                                                EnvironmentVariableTarget.Machine);
                    var envrionmentArgument = new DynamicParameters();
                    envrionmentArgument.Add("@Environment",
                                            enviornmentSetting  ?? "DEV", 
                                            DbType.String);


                    if (enviornmentSetting == null)
                    {
                        _log.Warning("No environment variable [WmMiddlwareEnviornment] setting was found; will default to DEV settings.");    
                    }
                    
                    var result = connection.Query<dynamic>(@"SELECT ci.[Key], 
                                                                    ci.[Value] 
                                                             FROM [dbo].[ConfigurationItem] ci 
                                                             INNER JOIN [dbo].Environment e
                                                                ON e.EnvironmentId = ci.EnvironmentId
                                                             WHERE e.EnvironmentDescription = @Environment", envrionmentArgument);
                    
                    configurationMappings = result.ToDictionary(k => (string)k.Key, v => (string)v.Value);
                    _cache.Add(new CacheItem(cacheKey, configurationMappings), new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(5)) });
                }
            }

            string value;
            configurationMappings.TryGetValue(key, out value);

            if (value != null && xmlValue != null && value != xmlValue)
            {
                _log.Warning(key + 
                             " is set in both xml and database configuration with different values.  xml configuration will be used with value of " + 
                             xmlValue);
            }

            return (T)Convert.ChangeType(xmlValue ?? value, typeof (T));
        }
    }
}
