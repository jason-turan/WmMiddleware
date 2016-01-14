using System.Linq;
using System.Text;
using MiddleWare.Log;
using WmMiddleware.ProductReceiving.Repositories;

namespace WmMiddleware.ProductReceiving
{
    public class ProductReceivingJob : IProductReceivingJob
    {
        private readonly ILog  _logger;
        private readonly IReceivedProductReader _source;
        private readonly IReceivedProductWriter _destination;

        public ProductReceivingJob(ILog logger, IReceivedProductReader source, IReceivedProductWriter destination)
        {
            _logger = logger;
            _source = source;
            _destination = destination;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _logger.Debug("Getting products received");
            var productReceivedNotifications = _source.GetAutomatedShippingNotifications().Concat
                                               (_source.GetPurchaseOrders()).Concat
                                               (_source.GetPurchaseReturns()).ToList();

            if (productReceivedNotifications.Any())
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendLine("Processing notifications.");

                foreach (var productReceivedNotification in productReceivedNotifications)
                {
                    logBuilder.AppendLine(productReceivedNotification.ToString());
                }

                _logger.Debug(logBuilder.ToString());

                _destination.Save(productReceivedNotifications);
                
                _source.SetAsProcessed(productReceivedNotifications);

                _logger.Debug("Processing complete.");
            }
            else
            {
                _logger.Debug("No notifications to run");
            }
        }
    }
}
