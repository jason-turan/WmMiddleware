using System.IO;
using System.Linq;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.Shipment.Models.Generated;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Shipment
{
    public class ShipmentJob : OutboundProcessor, IShipmentJob
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentJob(ILog log,
            ITransferControlRepository transferControlRepository,
            IJobRepository jobRepository,
            IShipmentRepository shipmentRepository,
            IFileIo fileIo,
            IConfigurationManager configurationManager)
            : base(log,
                configurationManager,
                fileIo,
                jobRepository,
                transferControlRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        protected override void ProcessFilesForBatch(TransferControlFile file)
        {
            var shipmentHeaderRespository = new DataFileRepository<ShipmentHeader>();
            var shipmentDetailRespository = new DataFileRepository<ShipmentLineItem>();
            var cartonHeaderRespository = new DataFileRepository<ShipmentCartonHeader>();
            var cartonDetailRespository = new DataFileRepository<ShipmentCartonDetail>();

            var fileInfo = new FileInfo(file.FileLocation);
            var fileType = fileInfo.Name.Substring(0, 2);

            switch (fileType)
            {
                case ManhattanDataFileType.ShipmentHeader:
                    var shipmentHeader = shipmentHeaderRespository.Get(fileInfo.FullName).ToList();
                    _shipmentRepository.InsertShipmentHeaders(shipmentHeader);
                    LogInsert(shipmentHeader, file);
                    break;
                case ManhattanDataFileType.ShipmentDetail:
                    var shipmentDetail = shipmentDetailRespository.Get(fileInfo.FullName).ToList();
                    _shipmentRepository.InsertShipmentLineItems(shipmentDetail);
                    LogInsert(shipmentDetail, file);
                    break;
                case ManhattanDataFileType.CartonHeader:
                    var cartonHeader = cartonHeaderRespository.Get(fileInfo.FullName).ToList();
                    _shipmentRepository.InsertShipmentCartonHeaders(cartonHeader);
                    LogInsert(cartonHeader, file);
                    break;
                case ManhattanDataFileType.CartonDetail:
                    var cartonDetail = cartonDetailRespository.Get(fileInfo.FullName).ToList();
                    _shipmentRepository.InsertShipmentCartonDetails(cartonDetail);
                    LogInsert(cartonDetail, file);
                    break;
            }
        }
    }
}
