using System;
using System.Linq;
using System.Text;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.Picking
{
    public class PickJob : IUnitOfWork
    {
        private readonly ILog _logger;

        private IOrderReader SourceRepository { get; set; }
        private IOrderWriter DestinationRepository { get; set; }
        private readonly IOmsManhattanOrderMapRepository _omsManhattanOrderMapRepository;

        public PickJob(ILog logger, 
                       IOrderReader sourceRepository, 
                       IOrderWriter destinationRepository,
                       IOmsManhattanOrderMapRepository omsManhattanOrderMapRepository)
        {
            _logger = logger;
            DestinationRepository = destinationRepository;
            _omsManhattanOrderMapRepository = omsManhattanOrderMapRepository;
            SourceRepository = sourceRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var orders = SourceRepository.GetOrders().ToList();

            if (orders.Any())
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendLine("Processing " + orders.Count + " orders.");

                foreach (var order in orders)
                {
                    var map = new OmsManhattanOrderMap
                    {
                        Company = order.Company,
                        Created = DateTime.Now,
                        OmsOrderNumber = order.OrderNumber,
                        WmOrderNumber = order.ControlNumber
                    };

                    _omsManhattanOrderMapRepository.InsertOmsManhattanOrderMapRepository(map);

                    logBuilder.AppendLine(string.Format("Order Number: {0} <SKUs: {1}>", 
                                          order.OrderNumber, 
                                          string.Join(",", order.Items.Select(i => i.ItemSku))));
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
