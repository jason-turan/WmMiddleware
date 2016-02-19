using Middleware.Jobs;
using Middleware.Wm.Aurora.Shipment.Repository;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly IAuroraShipmentRepository _auroraShipmentRepository;

        public AuroraShipmentJob(IAuroraShipmentRepository auroraShipmentRepository, IShipmentRepository shipmentRepository)
        {
            _auroraShipmentRepository = auroraShipmentRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
         //   var shipments = FindManhattanShipmentHeaders

           // _auroraShipmentRepository.SaveShipments(_auroraShipmentRepository.GetShipments());
        }
    }
}
