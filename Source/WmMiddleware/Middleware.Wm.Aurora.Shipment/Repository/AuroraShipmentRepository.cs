﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using Dapper;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Aurora.Shipment.Models;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.TransferControl.Control;

namespace Middleware.Wm.Aurora.Shipment.Repository
{
    public class AuroraShipmentRepository : IAuroraShipmentRepository
    {
        private const string ShippedCompany = "10";

        private readonly ILog _log;
        private readonly DataFileRepository<ManhattanShipmentLineItem> _detailFileRepository = new DataFileRepository<ManhattanShipmentLineItem>();
        private readonly DataFileRepository<ManhattanShipmentHeader> _headerFileRepository = new DataFileRepository<ManhattanShipmentHeader>();
        private readonly DataFileRepository<ManhattanShipmentCartonHeader> _cartonHeaderFileRepository = new DataFileRepository<ManhattanShipmentCartonHeader>();
        private readonly DataFileRepository<ManhattanShipmentCartonDetail> _cartonDetailFileRepository = new DataFileRepository<ManhattanShipmentCartonDetail>();

        private readonly ITransferControlManager _transferControlManager;
        private readonly IMainframeConfiguration _configuration;
        private readonly IJobRepository _jobRepository;
        private readonly IDatabaseKioskOrderExportRepository _databaseKioskOrderExportRepository;

        public AuroraShipmentRepository(ILog log,
                                        ITransferControlManager transferControlManager,
                                        IMainframeConfiguration configuration,
                                        IJobRepository jobRepository,
                                        IDatabaseKioskOrderExportRepository databaseKioskOrderExportRepository)
        {
            _log = log;
            _transferControlManager = transferControlManager;
            _configuration = configuration;
            _jobRepository = jobRepository;
            _databaseKioskOrderExportRepository = databaseKioskOrderExportRepository;
        }

        //public IList<AuroraShipment> GetShipments()
        //{
        //    var auroraShipments = new List<AuroraShipment>();

        //    // get data from kiosk exports / direct stored proc
        //    var shipments = _databaseKioskOrderExportRepository.GetDatabaseKioskOrderExports();
        //    var shipmentDetails = _databaseKioskOrderExportRepository.GetDatabaseKioskOrderDetailExports();

        //    // pump data to transaction table for transaction and debugging/troubleshooting
        //    _databaseKioskOrderExportRepository.InsertDatabaseKioskOrderExport(shipments);
        //    _databaseKioskOrderExportRepository.InsertDatabaseKioskOrderDetailExport(shipmentDetails);

        //    foreach (var databaseKioskOrderExport in shipments)
        //    {
        //        var auroraShipment = new AuroraShipment
        //        {
        //            OrderNumber = databaseKioskOrderExport.order_number,
        //            Details =  new List<AuroraShipmentDetail>()
        //        };

        //        foreach (var databaseKioskOrderDetailExport in shipmentDetails.Where(sd => sd.order_number == auroraShipment.OrderNumber))
        //        {
        //            auroraShipment.Details.Add(new AuroraShipmentDetail
        //            {
        //                Sku = databaseKioskOrderDetailExport.upc_number
        //            });
        //        }

        //        auroraShipments.Add(auroraShipment);
        //    }

        //    return auroraShipments;
        //}

        //public void SaveShipments(IList<AuroraShipment> shipments)
        //{
        //    if (!shipments.Any())
        //    {
        //        _log.Debug("No shipments to send to Aurora");
        //        return;
        //    }

        //    _log.Debug("Will process " + shipments.Count + " records");

        //    var headers = new List<ManhattanShipmentHeader>();
        //    var lineItems = new List<ManhattanShipmentLineItem>();
            
        //    // get a control number
        //    var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
        //    var controlNumber = _configuration.GetBatchControlNumber();
        //    var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

        //    var now = DateTime.Now;
        //    var createdDate = now.ToMainframeDate();
        //    var createdTime = now.ToMainframeTime();

        //    foreach (var shipment in shipments)
        //    {
        //        try
        //        {
        //            headers.Add(new ManhattanShipmentHeader
        //            {
        //                OrderNumber = shipment.OrderNumber,
        //                DateCreated = createdDate,
        //                TimeCreated = createdTime,
        //                Company = _configuration.GetKey<string>(ConfigurationKey.CompanyNumber),
        //                Warehouse = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber),
        //                Division = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber),
        //                PickticketControlNumber = shipment.OrderNumber,
        //                Pickticketnumber = shipment.OrderNumber,
        //                Soldto = "NBUS",
        //            });

        //            foreach (var detail in shipment.Details)
        //            {
        //                lineItems.Add(new ManhattanShipmentLineItem
        //                {
        //                    CustomerSku = detail.Sku
        //                });
        //            }
        //        }
        //        catch (Exception)
        //        {
                    
        //            throw;
        //        }

        //    }

        //    var headerFilePath = _configuration.GetPath(ManhattanDataFileType.ShipmentHeader, controlNumber);
        //    var detailFilePath = _configuration.GetPath(ManhattanDataFileType.ShipmentDetail, controlNumber);
            
        //    _headerFileRepository.Save(headers, headerFilePath);
        //    _detailFileRepository.Save(lineItems, detailFilePath);

        //    _transferControlManager.SaveTransferControl(batchControlNumber,
        //                                                new List<string> { headerFilePath, detailFilePath },
        //                                                _jobRepository.GetJob(JobKey.AuroraShipmentJob).JobId);
        //}

        public void InsertManhattanShipmentBncProcessing(ManhattanShipmentBncProcessing processing)
        {
            const string insertSql = @"INSERT INTO ManhattanShipmentBncProcessing(PickticketControlNumber, BatchControlNumber, ProcessedDate)
                                       VALUES(@PickticketControlNumber, @BatchControlNumber, @ProcessedDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@ProcessedDate", DateTime.Now, DbType.DateTime);
            parameters.Add("@PickticketControlNumber", processing.PickticketControlNumber, DbType.String);
            parameters.Add("@BatchControlNumber", processing.BatchControlNumber, DbType.String);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Execute(insertSql, parameters);
            }
        }

        public void ProcessAuroraShipmentBnc(IList<ManhattanShipment> manhattanShipment)
        {
            var controlNumber = _configuration.GetBatchControlNumber();
            var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");


            foreach (var shipment in manhattanShipment)
            {
                shipment.Header.BatchControlNumber = batchControlNumber;
                shipment.Header.Company = ShippedCompany;

                foreach (var detail in shipment.LineItems)
                {
                    detail.BatchControlNumber = batchControlNumber;
                    detail.ShippedCompany = ShippedCompany;
                }

                foreach (var carton in shipment.ManhattanShipmentCartonHeader)
                {
                    carton.BatchControlNumber = batchControlNumber;
                    carton.Company = ShippedCompany;
                }

                foreach (var cartonDetail in shipment.ManhattanShipmentCartonDetails)
                {
                    cartonDetail.BatchControlNumber = batchControlNumber;
                    cartonDetail.Company = ShippedCompany;
                }
            }

            // aurora needs the warehouse number inserted in filename path at position 3 and 4
            var headerPath = _configuration.GetPath(ManhattanDataFileType.ShipmentHeader, controlNumber, warehouseNumber, "Aurora_");
            var detailsPath = _configuration.GetPath(ManhattanDataFileType.ShipmentDetail, controlNumber, warehouseNumber, "Aurora_");
            var cartonPath = _configuration.GetPath(ManhattanDataFileType.CartonHeader, controlNumber, warehouseNumber, "Aurora_");
            var cartonDetailsrPath = _configuration.GetPath(ManhattanDataFileType.CartonDetail, controlNumber, warehouseNumber, "Aurora_");

            _headerFileRepository.Save(manhattanShipment.Select(s => s.Header), headerPath);
            _detailFileRepository.Save(manhattanShipment.SelectMany(d => d.LineItems), detailsPath);
            _cartonHeaderFileRepository.Save(manhattanShipment.SelectMany(d => d.ManhattanShipmentCartonHeader), cartonPath);
            _cartonDetailFileRepository.Save(manhattanShipment.SelectMany(d => d.ManhattanShipmentCartonDetails), cartonDetailsrPath);

            _transferControlManager.SaveTransferControl(batchControlNumber,
                                                        new List<string>
                                                        {
                                                            headerPath, 
                                                            detailsPath, 
                                                            cartonPath, 
                                                            cartonDetailsrPath
                                                        },
                                                        _jobRepository.GetJob(JobKey.AuroraShipmentJob).JobId);
        }
    }
}
