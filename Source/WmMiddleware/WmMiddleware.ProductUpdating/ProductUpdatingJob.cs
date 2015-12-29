using System;
using System.Linq;
using System.Text;
using MiddleWare.Log;
using WmMiddleware.ProductUpdating.Configuration;
using WmMiddleware.ProductUpdating.Repositories;

namespace WmMiddleware.ProductUpdating
{
    public class ProductUpdatingJob : IProductUpdatingJob
    {
        private readonly ILog  _logger;
        private readonly IProductReader _source;
        private readonly IProductWriter _destination;
        private readonly IProductUpdatingConfiguration _configuration;

        public ProductUpdatingJob(ILog logger, IProductReader source, IProductWriter destination, IProductUpdatingConfiguration configuration)
        {
            _logger = logger;
            _source = source;
            _destination = destination;
            _configuration = configuration;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var products = _source.GetProducts(_configuration.GetLastSuccessfulRun()).ToList();
            var productsReceivedAtDateTime = DateTime.Now;
            if (products.Any())
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendLine("Processing products.");

                foreach (var product in products)
                {
                    logBuilder.AppendLine(product.ToString());
                }

                _logger.Debug(logBuilder.ToString());

                _destination.SaveProducts(products);
                _configuration.SetLastSuccessfulRun(productsReceivedAtDateTime);
            }
            else
            {
                _logger.Debug("No notifications to run");
            }
        }
    }
}
