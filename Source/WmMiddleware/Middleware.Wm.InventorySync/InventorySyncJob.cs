using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.InventorySync.Models;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Outbound;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Repository;
using Middleware.Wm.StlInventoryUpdate;
using Middleware.Wm.StlInventoryUpdate.Repository;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;
using WmMiddleware.InventorySync.Models.Generated;
using System.Net.Mail;

namespace Middleware.Wm.InventorySync
{
    public class InventorySyncJob : OutboundProcessor
    {
        private readonly ILog _log;
        private readonly IInventorySyncRepository _inventorySyncRepository;

        private readonly IStlInventoryRepository _stlInventoryRepository;
        private readonly IStlInventoryUpdateRepository _stlInventoryUpdateRepository;
        private readonly IShipmentInventoryAdjustmentRepository _shipmentInventoryAdjustmentRepository;
        private readonly IPixInventoryAdjustmentRepository _pixInventoryAdjustmentRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;
        private readonly IConfigurationManager _configurationManager;

        public InventorySyncJob(ILog log,
            IConfigurationManager configurationManager,
            IJobRepository jobRepository,
            ITransferControlRepository transferControlRepository,
            IInventorySyncRepository inventorySyncRepository,
            IFileIo fileIo,
            ITransferControlConfigurationManager transferControlConfigurationManager,
            IStlInventoryRepository stlInventoryRepository,
            IStlInventoryUpdateRepository stlInventoryUpdateRepository, 
            IShipmentInventoryAdjustmentRepository shipmentInventoryAdjustmentRepository,
            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository, 
            IPixInventoryAdjustmentRepository pixInventoryAdjustmentRepository)
            : base(log, configurationManager, fileIo, jobRepository, transferControlRepository, transferControlConfigurationManager)
        {
            _inventorySyncRepository = inventorySyncRepository;
            _stlInventoryRepository = stlInventoryRepository;
            _stlInventoryUpdateRepository = stlInventoryUpdateRepository;
            _shipmentInventoryAdjustmentRepository = shipmentInventoryAdjustmentRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _pixInventoryAdjustmentRepository = pixInventoryAdjustmentRepository;
            _log = log;
            _configurationManager = configurationManager;
        }

        protected override void ProcessFiles(ICollection<TransferControlFile> transferControlFiles)
        {
            if (transferControlFiles.Count != 1)
            {
                throw new ArgumentOutOfRangeException("transferControlFiles", "Expected one file, found " + transferControlFiles.Count);
            }

            //1) STL INVENTORY UPDATE - Clean PIX/Shipments before loading the sync file.
            var stlInventoryUpdateJob = new StlInventoryUpdateJob(_log,
                                                                  _stlInventoryUpdateRepository,
                                                                  _shipmentInventoryAdjustmentRepository,
                                                                  _perpetualInventoryTransferRepository,
                                                                  _pixInventoryAdjustmentRepository);

            stlInventoryUpdateJob.RunUnitOfWork("Stl Inventory Update");

            var transferControlFile = transferControlFiles.First();

            var pixRepository = new DataFileRepository<ManhattanInventorySync>();
            var inventorySync = pixRepository.Get(transferControlFile.FileLocation).ToList();

            //2) Load the I5 sync file into our RAW Table.
            _inventorySyncRepository.InsertInventorySync(inventorySync);

            if (inventorySync.Count > 0)
                _inventorySyncRepository.SetAsReceived(new InventorySyncProcessing
                {
                    TransactionNumber = inventorySync.First().TransactionNumber,
                    ReceivedDate = DateTime.Now,
                    ManhattanDateCreated = inventorySync.First().DateCreated,
                    ManhattanTimeCreated =  inventorySync.First().TimeCreated
                });

            LogInsert(inventorySync, transferControlFile);


            //3)VALIDATION - ABORT THE SYNC IF THE LAST APPLIED PIX/SHIPMENT HAS TIMESTAMP GREATER THAN OUR SYNC FILE'S (scenario would cause inaccurate inventory)
            var inventorySyncStatus = _inventorySyncRepository.GetInventorySyncStatus(inventorySync.First().TransactionNumber);
            if (!inventorySyncStatus.IsValid)
            {
                _log.Debug(string.Format("Inventory Sync {0} is Stale - {1}", inventorySync.First().TransactionNumber, inventorySyncStatus.Message));
                EmailAuditSummary(null, inventorySync.First().TransactionNumber);
            }
            else
            {
                //4) Load the Sync data into Stl Inventory Table. 
                var latestManhattanInventorySync = _stlInventoryRepository.GetLatestManhattanInventorySync().ToList();

                if (latestManhattanInventorySync.Count > 0)
                {
                    using (var transactionScope = Scope.CreateTransactionScope())
                    {
                        _stlInventoryRepository.InsertStlInventory(latestManhattanInventorySync);

                        _log.Debug("Inserted " + latestManhattanInventorySync.Count() + " records from latest InventorySync data");

                        _inventorySyncRepository.SetAsProcessed(new InventorySyncProcessing
                        {
                            TransactionNumber = latestManhattanInventorySync.First().ManhattanInventorySyncTransactionNumber,
                            ProcessedDate = latestManhattanInventorySync.First().InventoryDate
                        });

                        transactionScope.Complete();
                    }

                    var logBuilder = new StringBuilder();
                    logBuilder.AppendLine("---AUDIT REPORT---");

                    var auditEntries = _stlInventoryRepository.GetStlInventorySyncAudit().ToList();
                    if (auditEntries.Count > 0)
                    {
                        logBuilder.AppendLine("STATUS | SKU | QUANTITY");

                        foreach (var entry in auditEntries)
                        {
                            logBuilder.AppendLine(string.Format("{0} | {1} | {2}", entry.Status, entry.Upc, entry.Quantity));
                        }
                    }
                    else
                    {
                        logBuilder.AppendLine("SYNC MATCHES CURRENT INVENTORY");
                    }
                    _log.Debug(logBuilder.ToString());

                    EmailAuditSummary(auditEntries, latestManhattanInventorySync.First().ManhattanInventorySyncTransactionNumber);
                }
                else
                {
                    _log.Debug("No sync data for StlInventory!!!");
                }
            }

        }

        private void EmailAuditSummary(List<StlInventorySyncAudit> auditEntries, int transationNumber)
        {
            var sbEmail = new StringBuilder();
            const string htmlHead = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=us-ascii\"><style> table,th,td { border: solid 1px black; padding: 3px; margin:0px } table{padding:0px} th { font-weight: bold; background-color: black; color: white; } th,td,p { font-family:Calibri;font-size:x-small; } b{ font-family:Calibri;} table.invtable { width: 300px; } table.inttable { width: 500px; } .alertTxt { background-color: #FF0000;  } .passTxt { background-color: #82FA58;  } td{ background-color: white;} </style>";

            sbEmail.AppendLine(htmlHead);
            sbEmail.AppendLine(string.Format("<u><b>Inventory Sync Transaction Number: {0}</b></u><br/><br/>", transationNumber));
            if (auditEntries == null)
            {
                sbEmail.AppendLine("Inventroy sync has been labeled STALE and will not be loaded. Please review Wm Middleware logs for more details.");
            }
            else if (auditEntries.Count == 0)
            {
                sbEmail.AppendLine("Sync matches existing inventory set!");
            }
            else if (auditEntries.Count > 0)
            {
                sbEmail.AppendLine(string.Format("<li>New SKUs: <b>{0}</b></li>", auditEntries.Count(x => x.Status == "NEW")));
                sbEmail.AppendLine(string.Format("<li>Deleted SKUs: <b>{0}</b></li>", auditEntries.Count(x => x.Status == "DELETED")));
                sbEmail.AppendLine(string.Format("<li>SKUs with Quantity Discrepancies: <b>{0}</b></li>", auditEntries.Count(x => x.Status == "ADJ")));
                if (auditEntries.Count(x => x.Status == "ADJ") > 0)
                    sbEmail.AppendLine(string.Format("<li>Total Discrepancy Quantity: <b>{0}</b></li>", auditEntries.Where(x => x.Status == "ADJ").ToList().Sum(q => q.Quantity)));
            }

            var smptServer = _configurationManager.GetKey<string>(ConfigurationKey.SmptServer);

            var message = new MailMessage("noreply@newbalance.com", _configurationManager.GetKey<string>(ConfigurationKey.InventorySyncAuditDistributionList))
            {
                IsBodyHtml = true,
                Subject = "WmMiddleware - Inventory Sync Audit",
                Body = sbEmail.ToString()
            };

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }

    }
}
