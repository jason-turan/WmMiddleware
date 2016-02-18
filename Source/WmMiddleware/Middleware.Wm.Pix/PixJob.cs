﻿using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Outbound;
using Middleware.Wm.Pix.Repository;
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
                      IFileIo fileIo)
            : base(log, configurationManager, fileIo, jobRepository, transferControlRepository)
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
            var pix = pixRepository.Get(file.FileLocation).ToList();
            _perpetualInventoryTransferRepository.InsertPerpetualInventoryTransfer(pix);
            LogInsert(pix, file);
        }
    }
}
