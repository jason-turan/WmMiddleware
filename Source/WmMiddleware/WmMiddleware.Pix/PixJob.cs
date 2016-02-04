﻿using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs.Repositories;
using Middleware.Wm.DataFiles;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.Pix.Models.Generated;
using WmMiddleware.Pix.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Pix
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
