using System;
using System.Globalization;
using System.IO;
using WmMiddleware.Configuration.Manhattan;
using MiddleWare.Log;

namespace WmMiddleware.ProductUpdating.Configuration
{
    public class ProductUpdatingConfiguration : ManhattanConfiguration, IProductUpdatingConfiguration
    {
        private readonly ILog _log;
        private static readonly string ConfigFileName = AppDomain.CurrentDomain.BaseDirectory + "ProductUpdatingValues.config";

        public ProductUpdatingConfiguration(ILog log) : base(log)
        {
            _log = log;
        }

        public DateTime? GetLastSuccessfulRun()
        {
            DateTime? result = null;
            try
            {
                if (File.Exists(ConfigFileName))
                {
                    _log.Debug("Found configuration file " + ConfigFileName);
                    
                    DateTime parseResult;
                    DateTime.TryParse(File.ReadAllText(ConfigFileName), out parseResult);
                    result = parseResult;
                }
            }
            catch (Exception ex)
            {
                _log.Exception(ex);
            }

            return result;
        }

        public void SetLastSuccessfulRun(DateTime timeRun)
        {
            try
            {
                _log.Debug("Setting last successful run by writing " + timeRun + " to configuration file: " + ConfigFileName);
                File.WriteAllText(ConfigFileName, timeRun.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                _log.Exception(ex);
            }
        }
    }
}
