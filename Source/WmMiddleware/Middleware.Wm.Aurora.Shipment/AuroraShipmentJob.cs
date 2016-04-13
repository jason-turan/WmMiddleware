using System.Linq;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Aurora.Shipment.Models;
using Middleware.Wm.Aurora.Shipment.Repository;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly IAuroraShipmentRepository _auroraShipmentRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly ILog _log;

        public AuroraShipmentJob(ILog log,
                                 IAuroraShipmentRepository auroraShipmentRepository, 
                                 IShipmentRepository shipmentRepository,
                                 IOrderHistoryRepository orderHistoryRepository)
        {
            _auroraShipmentRepository = auroraShipmentRepository;
            _shipmentRepository = shipmentRepository;
            _orderHistoryRepository = orderHistoryRepository;
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var shipments = _shipmentRepository.FindManhattanShipmentHeaders(new ManhattanShipmentSearchCriteria
            {
                ShipTo = ManhattanShipmentSearchCriteria.BrickAndClickShipTo,
                UnprocessedForAuroraShipmentGeneralLedger = false,
                UnprocessedForAuroraShipment = true
            });

            if (shipments.Count > 0)
            {
                _orderHistoryRepository.Save(shipments.SelectMany(s => s.LineItems.Select(i => new OrderHistory(s.Header.OrderNumber, s.Header.BatchControlNumber, i.PackageBarcode, "Shipment sent to Aurora.", "Aurora Shipment Job"))));
                _auroraShipmentRepository.ProcessAuroraShipmentBnc(shipments);

                foreach (var manhattanShipment in shipments)
                {
                    _auroraShipmentRepository.InsertManhattanShipmentBncProcessing(new ManhattanShipmentBncProcessing
                    {
                        BatchControlNumber = manhattanShipment.OriginalBatchControlNumber,
                        PickticketControlNumber = manhattanShipment.Header.PickticketControlNumber
                    });
                }
            }
            else
            {
                _log.Info("No shipments to process");
            }
        }
    }
}
