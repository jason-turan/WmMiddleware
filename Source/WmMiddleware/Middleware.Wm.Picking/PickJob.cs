﻿using System.Linq;
using System.Text;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Picking
{
    public class PickJob : IUnitOfWork
    {
        private readonly ILog _logger;

        private IOrderReader SourceRepository { get; set; }
        private IOrderWriter DestinationRepository { get; set; }

        public PickJob(ILog logger, IOrderReader sourceRepository, IOrderWriter destinationRepository)
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
                logBuilder.AppendLine("Processing " + orders.Count + " orders.");

                foreach (var order in orders)
                {
                    logBuilder.AppendLine(string.Format("Order Number: {0} <SKUs: {1}>", order.OrderNumber, string.Join(",", order.Items.Select(i => i.ItemSku))));
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
