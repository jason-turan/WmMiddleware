using System.IO;
using System.Linq;
using WmMiddleware.Common.DataFiles;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Shipment.Models;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Shipment
{
    public class ShipmentJob : IShipmentJob
    {
        private readonly ILog _log;

        private readonly ITransferControlRepository _transferControlRepository;

        private readonly IJobRepository _jobRepository;

        public ShipmentJob(ILog log, ITransferControlRepository transferControlRepository, IJobRepository jobRepository)
        {
            _log = log;
            _transferControlRepository = transferControlRepository;
            _jobRepository = jobRepository;
        }

        public void RunUnitOfWork()
        {
            var shipmentHeaderRespository = new DataFileRepository<ShipmentHeader>();
            var shipmentDetailRespository = new DataFileRepository<ShipmentLineItem>();
            var cartonHeaderRespository = new DataFileRepository<CartonHeader>();
            var cartonDetailRespository = new DataFileRepository<CartonDetail>();

            var job = _jobRepository.GetJob(JobKey.ShipmentJob);

            var toProcess = _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria()
            {
                Processed = false,
                JobId = job.JobId
            }).ToList();

            _log.Info("Found " + toProcess.Count() + " outbound shipment batches to process" );

            foreach (var transferControl in toProcess)
            {
                foreach (var file in transferControl.Files)
                {
                    var fileInfo = new FileInfo(file.FileLocation);
                    var fileType = fileInfo.Name.Substring(0, 2);
          
                    switch (fileType)
                    {
                        case ManhattanDataFileType.ShipmentHeader:
                            var shipmentHeader = shipmentHeaderRespository.Get(fileInfo.FullName);
                            break;
                        case ManhattanDataFileType.ShipmentDetail:
                            var shipmentDetail = shipmentDetailRespository.Get(fileInfo.FullName);
                            break;
                        case ManhattanDataFileType.CartonHeader:
                            var cartonHeader = cartonHeaderRespository.Get(fileInfo.FullName);
                            break;
                        case ManhattanDataFileType.CartonDetail:
                            var cartonDetil = cartonDetailRespository.Get(fileInfo.FullName);
                            break;
                    }
                }


            }
        }
    }
}
