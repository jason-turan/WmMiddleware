using System;
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
                shipment.OriginalBatchControlNumber = shipment.Header.BatchControlNumber;

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
