using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Aurora.Shipment.Repository;

namespace Middleware.Wm.Aurora.Shipment
{
    public class AuroraShipmentJob : IUnitOfWork
    {
        private readonly ILog _log;
        
        private readonly IDatabaseKioskOrderExportRepository _databaseKioskOrderExportRepository;

        public AuroraShipmentJob(ILog log, IDatabaseKioskOrderExportRepository databaseKioskOrderExportRepository)
        {
            _log = log;
            _databaseKioskOrderExportRepository = databaseKioskOrderExportRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var orders = _databaseKioskOrderExportRepository.GetDatabaseKioskOrderExports();
            var orderDetails = _databaseKioskOrderExportRepository.GetDatabaseKioskOrderDetailExports();

            _databaseKioskOrderExportRepository.InsertDatabaseKioskOrderExport(orders);
            _databaseKioskOrderExportRepository.InsertDatabaseKioskOrderDetailExport(orderDetails);
        }
    }
}
