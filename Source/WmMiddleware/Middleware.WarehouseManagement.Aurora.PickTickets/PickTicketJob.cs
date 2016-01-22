using System.Linq;
using System.Text;
using Middleware.Jobs;
using Middleware.WarehouseManagement.Aurora.PickTickets.Repositories;
using MiddleWare.Log;

namespace Middleware.WarehouseManagement.Aurora.PickTickets
{
    public class PickTicketJob : IUnitOfWork
    {
        private readonly ILog _logger;

        private IPickReader SourceRepository { get; set; }
        private IPickWriter DestinationRepository { get; set; }

        public PickTicketJob(ILog logger, IPickReader sourceRepository, IPickWriter destinationRepository)
        {
            _logger = logger;
            DestinationRepository = destinationRepository;
            SourceRepository = sourceRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var orders = SourceRepository.GetOrders().ToList();

            if (orders.Any())
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendLine("Processing orders.");

                foreach (var order in orders)
                {
                    //logBuilder.AppendLine(string.Format("Order Number: {0} <SKUs: {1}>", order.OrderNumber, string.Join(",", order.Items.Select(i => i.ItemSku))));
                }

                _logger.Debug(logBuilder.ToString());

                DestinationRepository.SaveOrders(orders);

                SourceRepository.SetAsProcessed(orders);
            }
            else
            {
                _logger.Debug("No orders to run");
            }
        }
    }
}
