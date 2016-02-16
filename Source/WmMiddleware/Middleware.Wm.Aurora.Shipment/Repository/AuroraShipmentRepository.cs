using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Manhattan.Shipment;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Mainframe;
using WmMiddleware.TransferControl.Control;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public class AuroraShipmentRepository : IAuroraShipmentRepository
    {
        private readonly ILog _log;
        private readonly DataFileRepository<ManhattanShipmentLineItem> _headerFileRepository = new DataFileRepository<ManhattanShipmentLineItem>();
        private readonly DataFileRepository<ManhattanShipmentHeader> _detailFileRepository = new DataFileRepository<ManhattanShipmentHeader>();
        private readonly ITransferControlManager _transferControlManager;
        private readonly IMainframeConfiguration _configuration;
        private readonly IJobRepository _jobRepository;

        public AuroraShipmentRepository(ILog log,
                                        ITransferControlManager transferControlManager,
                                        IMainframeConfiguration configuration,
                                        IJobRepository jobRepository)
        {
            _log = log;
            _transferControlManager = transferControlManager;
            _configuration = configuration;
            _jobRepository = jobRepository;
        }

        public void SaveShipments(IList<Models.AuroraShipment> shipments)
        {
            if (!shipments.Any())
            {
                _log.Debug("No shipments to send to Aurora");
                return;
            }

            _log.Debug("Will process " + shipments.Count + " records");

            var headers = new List<ManhattanShipmentHeader>();
            var lineItems = new List<ManhattanShipmentLineItem>();
            
            // get a control number
            var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
            var controlNumber = _configuration.GetBatchControlNumber();
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

            foreach (var shipment in shipments)
            {
                
            }

            var headerFilePath = @"fake";
            var detailFilePath = @"fake";

            _transferControlManager.SaveTransferControl(batchControlNumber,
                                                        new List<string> { headerFilePath, detailFilePath },
                                                        _jobRepository.GetJob(JobKey.AuroraShipmentJob).JobId);
        }
    }
}
