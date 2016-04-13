using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.DataFiles;
using Middleware.Wm.Outbound;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.Pix
{
    public class PixJob : OutboundProcessor
    {
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public PixJob(ILog log,
            IConfigurationManager configurationManager,
            IJobRepository jobRepository,
            ITransferControlRepository transferControlRepository,
            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository,
            IFileIo fileIo,
            ITransferControlConfigurationManager transferControlConfigurationManager)
            : base(log, configurationManager, fileIo, jobRepository, transferControlRepository, transferControlConfigurationManager)
        {
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
        }

        protected override void ProcessFiles(ICollection<TransferControlFile> transferControlFiles)
        {
            if (transferControlFiles.Count != 1)
            {
                throw new ArgumentOutOfRangeException("transferControlFiles", "Expected one file, found " + transferControlFiles.Count);
            }

            var file = transferControlFiles.First();
            var pixRepository = new DataFileRepository<ManhattanPerpetualInventoryTransfer>();
            var pixList = pixRepository.Get(file.FileLocation).ToList();
            
            _perpetualInventoryTransferRepository.InsertPerpetualInventoryTransfer(pixList);
            LogInsert(pixList, file);
        }
    }
}
