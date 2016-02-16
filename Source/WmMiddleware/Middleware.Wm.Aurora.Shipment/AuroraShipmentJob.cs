using Middleware.Jobs;
using Middleware.Wm.Aurora.Shipment.Repository;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly IAuroraShipmentRepository _auroraShipmentRepository;

        public AuroraShipmentJob(IAuroraShipmentRepository auroraShipmentRepository)
        {
            _auroraShipmentRepository = auroraShipmentRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            _auroraShipmentRepository.SaveShipments(_auroraShipmentRepository.GetShipments());
        }
    }
}
