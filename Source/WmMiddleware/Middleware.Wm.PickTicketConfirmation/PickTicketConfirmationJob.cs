using System;
using System.Linq;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Aurora.PickTickets.Repositories;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.PickTicketConfirmation.Models;
using Middleware.Wm.PickTicketConfirmation.Repositories;
using Middleware.Wm.Shipping;

namespace Middleware.Wm.PickTicketConfirmation
{
    public class PickTicketConfirmationJob : IUnitOfWork
    {
        private readonly ILog _logger;

        private IOrderReader SourceRepository { get; set; }
        private IOrderWriter DestinationRepository { get; set; }
        private readonly IPickTicketProcessingRepository _pickTicketProcessingRepository;
        private readonly IAuroraPickTicketRepository _auroraPickTicketRepository;
        private readonly IOmsManhattanOrderMapRepository _omsManhattanOrderMapRepository;
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;

        public PickTicketConfirmationJob(ILog logger, 
                                         IOrderReader sourceRepository, 
                                         IOrderWriter destinationRepository,
                                         IPickTicketProcessingRepository pickTicketProcessingRepository,
                                         IAuroraPickTicketRepository auroraPickTicketRepository,
                                         IOmsManhattanOrderMapRepository omsManhattanOrderMapRepository,
                                         IOrderHistoryRepository orderHistoryRepository,
                                         ICarrierReadRepository carrierReadRepository)
        {
            _logger = logger;
            SourceRepository = sourceRepository;
            DestinationRepository = destinationRepository;
            _pickTicketProcessingRepository = pickTicketProcessingRepository;
            _auroraPickTicketRepository = auroraPickTicketRepository;
            _omsManhattanOrderMapRepository = omsManhattanOrderMapRepository;
            _orderHistoryRepository = orderHistoryRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var orders = SourceRepository.GetOrders().ToList();
                                                                                                                                                                                                                                                                                 
            if (orders.Any())
            {
                _logger.Debug("Processing " + orders.Count + " orders.");
                foreach (var order in orders)
                {
                    var map = new OmsManhattanOrderMap
                    {
                        Company = order.Company,
                        Created = DateTime.Now,
                        OmsOrderNumber = order.ControlNumber,
                        WmOrderNumber = order.OrderNumber
                    };

                    _omsManhattanOrderMapRepository.InsertOmsManhattanOrderMapRepository(map);
                    
                    _orderHistoryRepository.Save(order.CreateHistories("Processing pickticket confirmation.", "Aurora Pick Confirmation Job"));

                    SetAuroraPickTicketInformation(order);
                }

                DestinationRepository.SaveOrders(orders);

                var processed = orders.Select(s => new PickTicketConfirmationOrderProcessing { ControlNumber = s.ControlNumber, OrderNumber = s.OrderNumber, ProcessedDate = DateTime.Now }).ToList();
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
            
            if (auroraPickTicket.Header == null)
            {
                _logger.Warning("Cannot find aurora pick ticket for order number " + order.OrderNumber);    
            }
            else
            {
                order.ArAccountNumber = auroraPickTicket.Header.ArAccountNumber;
                order.CustomerPurchaseOrderNumber = auroraPickTicket.Header.CustomerPurchaseOrderNumber;
                order.OrderType = OrderType.BrickAndClick;
                order.LineItems = auroraPickTicket.Details.ToDictionary(d => d.PackageBarcode, d => d.PickticketLineNumber);
                order.ShippingMethod = _carrierReadRepository.GetOmsShipMethod(auroraPickTicket.Header.ShipVia);    
            }
        }
    }
}
