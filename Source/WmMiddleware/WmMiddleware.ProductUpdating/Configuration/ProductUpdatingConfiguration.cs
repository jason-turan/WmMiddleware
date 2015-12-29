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
        private const string ConfigFileName = "ProductUpdatingValues.config";

        public ProductUpdatingConfiguration(ILog log) : base(log)
        {
            _log = log;
        }

        public DateTime GetLastSuccessfulRun()
        {
            var result = new DateTime();
            try
            {
                if (File.Exists(ConfigFileName))
                {
                    DateTime.TryParse(File.ReadAllText(ConfigFileName), out result);
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
                File.WriteAllText(ConfigFileName, timeRun.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                _log.Exception(ex);
            }
        }
    }
}
