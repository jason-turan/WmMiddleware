using System;
using System.Linq;
using System.Text;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;

namespace Middleware.Wm.Picking
{
    public class PickJob : IUnitOfWork
    {
        private readonly ILog _logger;
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        private IOrderReader SourceRepository { get; set; }
        private IOrderWriter DestinationRepository { get; set; }
        private readonly IOmsManhattanOrderMapRepository _omsManhattanOrderMapRepository;

        public PickJob(ILog logger, 
                       IOrderReader sourceRepository, 
                       IOrderWriter destinationRepository,
                       IOmsManhattanOrderMapRepository omsManhattanOrderMapRepository,
                       IOrderHistoryRepository orderHistoryRepository)
        {
            _logger = logger;
            _orderHistoryRepository = orderHistoryRepository;
            DestinationRepository = destinationRepository;
            _omsManhattanOrderMapRepository = omsManhattanOrderMapRepository;
            SourceRepository = sourceRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var orders = SourceRepository.GetOrders().ToList();

            if (orders.Any())
            {
                _logger.Debug("Processing " + orders.Count + " orders.");
                _orderHistoryRepository.Save(orders.SelectMany(o => o.CreateHistories("Order picked.", "Pick Job")));
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
                }

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
