﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Jobs.Repositories;
using Middleware.Wm.DataFiles;
using MiddleWare.Log;
using Middleware.Wm.Manhattan.Shipment;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Shipment
{
    public class ShipmentJob : OutboundProcessor
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

        protected override void ProcessFiles(ICollection<TransferControlFile> transferControlFiles)
        {
            foreach (var file in transferControlFiles)
            {
                ProcessFile(file);
            }
        }

        private void ProcessFile(TransferControlFile file)
        {
            var shipmentHeaderRespository = new DataFileRepository<ManhattanShipmentHeader>();
            var shipmentDetailRespository = new DataFileRepository<ManhattanShipmentLineItem>();
            var cartonHeaderRespository = new DataFileRepository<ManhattanShipmentCartonHeader>();
            var cartonDetailRespository = new DataFileRepository<ManhattanShipmentCartonDetail>();

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
