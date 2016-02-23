using System;
using System.Linq;
using System.Text;
using Middleware.Jobs;
using Middleware.Wm.Aurora.PickTickets.Repositories;
using Middleware.Wm.Inventory;
using MiddleWare.Log;
using Middleware.Wm.PickTicketConfirmation.Models;
using Middleware.Wm.PickTicketConfirmation.Repositories;

namespace Middleware.Wm.PickTicketConfirmation
{
    public class PickTicketConfirmationJob : IUnitOfWork
    {
        private readonly ILog _logger;

        private IOrderReader SourceRepository { get; set; }
        private IOrderWriter DestinationRepository { get; set; }
        private readonly IPickTicketProcessingRepository _pickTicketProcessingRepository;
        private readonly IAuroraPickTicketRepository _auroraPickTicketRepository;

        public PickTicketConfirmationJob(ILog logger, 
                                         IOrderReader sourceRepository, 
                                         IOrderWriter destinationRepository,
                                         IPickTicketProcessingRepository pickTicketProcessingRepository,
                                         IAuroraPickTicketRepository auroraPickTicketRepository)
        {
            _logger = logger;
            SourceRepository = sourceRepository;
            DestinationRepository = destinationRepository;
            _pickTicketProcessingRepository = pickTicketProcessingRepository;
            _auroraPickTicketRepository = auroraPickTicketRepository;
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
                    logBuilder.AppendLine(string.Format("Order Number: {0} <SKUs: {1}>", 
                                                        order.OrderNumber, 
                                                        string.Join(",", order.Items.Select(i => i.ItemSku))));

                    SetAuroraPickTicketInformation(order);
                }

                _logger.Debug(logBuilder.ToString());

                DestinationRepository.SaveOrders(orders);
              //  SourceRepository.SetAsProcessed(orders);

                var processed = orders.Select(s => new PickTicketConfirmationOrderProcessing {ControlNumber = s.ControlNumber, OrderNumber = s.OrderNumber, ProcessedDate = DateTime.Now}).ToList();
                _pickTicketProcessingRepository.InsertPickTicketProcessing(processed);
            }
            else
            {
                _logger.Debug("No orders to run");
            }
        }

        private void SetAuroraPickTicketInformation(Order order)
        {
            var auroraPickTicket = _auroraPickTicketRepository.GetAuroraPickTicket(order.OrderNumber);
            order.ArAccountNumber = auroraPickTicket.Header.ArAccountNumber;
            order.CustomerPurchaseOrderNumber = auroraPickTicket.Header.CustomerPurchaseOrderNumber;
            order.OrderType = OrderType.BrickAndClick;
            order.LineItems = auroraPickTicket.Details.ToDictionary(d => d.PackageBarcode, d => d.PickticketLineNumber);
        }
    }
}
