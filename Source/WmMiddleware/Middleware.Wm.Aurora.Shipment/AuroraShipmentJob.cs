using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Aurora.Shipment.Models;
using Middleware.Wm.Aurora.Shipment.Repository;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.Shipment.Models;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly IAuroraShipmentRepository _auroraShipmentRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ILog _log;

        public AuroraShipmentJob(ILog log,
                                 IAuroraShipmentRepository auroraShipmentRepository, 
                                 IShipmentRepository shipmentRepository)
        {
            _auroraShipmentRepository = auroraShipmentRepository;
            _shipmentRepository = shipmentRepository;
            _log = log;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var shipments = _shipmentRepository.FindManhattanShipmentHeaders(new ManhattanShipmentSearchCriteria
            {
                ShipTo = ManhattanShipmentSearchCriteria.BrickAndClickShipTo
            });

            if (shipments.Count > 0)
            {
                _auroraShipmentRepository.ProcessAuroraShipmentBnc(shipments);

                foreach (var manhattanShipment in shipments)
                {
                    _auroraShipmentRepository.InsertManhattanShipmentBncProcessing(new ManhattanShipmentBncProcessing
                    {
                        BatchControlNumber = manhattanShipment.Header.BatchControlNumber,
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
