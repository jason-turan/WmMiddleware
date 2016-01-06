using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using Middleware.Jobs.Models;
using WmMiddleware.Common.DataFiles;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.Shipment.Models.Generated;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Shipment
{
    public class ShipmentJob : IShipmentJob
    {
        private readonly ILog _log;
        private readonly ITransferControlRepository _transferControlRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IFileIo _fileIo;
        private readonly IConfigurationManager _configurationManager;

        public ShipmentJob(ILog log, 
                           ITransferControlRepository transferControlRepository, 
                           IJobRepository jobRepository,
                           IShipmentRepository shipmentRepository,
                           IFileIo fileIo,
                           IConfigurationManager configurationManager)
        {
            _log = log;
            _fileIo = fileIo;
            _transferControlRepository = transferControlRepository;
            _jobRepository = jobRepository;
            _shipmentRepository = shipmentRepository;
            _configurationManager = configurationManager;
        }

        public void RunUnitOfWork(string args)
        {
            bool allSucceeded = true;

            var shipmentHeaderRespository = new DataFileRepository<ShipmentHeader>();
            var shipmentDetailRespository = new DataFileRepository<ShipmentLineItem>();
            var cartonHeaderRespository = new DataFileRepository<ShipmentCartonHeader>();
            var cartonDetailRespository = new DataFileRepository<ShipmentCartonDetail>();

            var job = _jobRepository.GetJob(JobKey.ShipmentJob);

            var toProcess = _transferControlRepository.FindTransferControls(new TransferControlSearchCriteria
            {
                Processed = false,
                JobId = job.JobId,
                JobType = JobType.Outbound
            }).ToList();

            _log.Info("Found " + toProcess.Count() + " outbound shipment batches to process" );

            foreach (var transferControl in toProcess)
            {
                    try
                    {
                        using (var transactionScope = new TransactionScope())
                        {
                            foreach (var file in transferControl.Files)
                            {
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

                            transferControl.ProcessedDate = DateTime.Now;
                            _transferControlRepository.UpdateTransferControl(transferControl);

                            transactionScope.Complete();
                        }

                        MoveFilesToProcessed(transferControl.Files);
                        _log.Info("Outbound batch " + transferControl.BatchControlNumber + " completed.");
                    }
                    catch (Exception exception)
                    {
                        _log.Exception("Fatal exception processing batch " + transferControl.BatchControlNumber, exception);
                        allSucceeded = false;
                    }

                    if (!allSucceeded)
                    {
                        throw new Exception("At least one shipment batch has failed.");
                    }
            }
        }

        private void MoveFilesToProcessed(IEnumerable<TransferControlFile> files)
        {
            var processedPath =
                _configurationManager.GetKey<string>(ConfigurationKey.TransferControlOutboundFileProcessedDirectory);

            foreach (var transferControlFile in files)
            {
                var fileInfo = new FileInfo(transferControlFile.FileLocation);
                _fileIo.Move(fileInfo, new FileInfo(Path.Combine(processedPath, fileInfo.Name)));
            }
        }

        private void LogInsert(IEnumerable<IGeneratedFlatFile> cartonHeader, TransferControlFile file)
        {
            _log.Debug("Inserted " + cartonHeader.Count() + " records from file " + file.FileLocation);
        }
    }
}
