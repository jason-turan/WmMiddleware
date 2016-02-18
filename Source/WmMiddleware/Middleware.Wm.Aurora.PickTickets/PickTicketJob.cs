﻿using System.Collections.Generic;
using System.IO;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Configuration;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;
using MiddleWare.Log;
using Middleware.Wm.Outbound;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;

namespace Middleware.Wm.Aurora.PickTickets
{
    public class PickTicketJob : OutboundProcessor
    {
        private readonly IOrderWriter _destinationRepository;
        private readonly IManhattanOrderRepository _manhattanOrderRepository;

        public PickTicketJob(ILog logger, IOrderWriter destinationRepository, IConfigurationManager configurationManager, IFileIo fileIo, IJobRepository jobRepository, ITransferControlRepository transferControlRepository, IManhattanOrderRepository manhattanOrderRepository)
            : base(logger, configurationManager, fileIo, jobRepository, transferControlRepository)
        {
            _destinationRepository = destinationRepository;
            _manhattanOrderRepository = manhattanOrderRepository;
        }

        protected override void ProcessFiles(ICollection<TransferControlFile> transferControlFiles)
        {
            TransferControlFile headerFile = null;
            TransferControlFile detailFile = null;
            TransferControlFile specialInstructionsFile = null;

            foreach (var file in transferControlFiles)
            {
                var filename = Path.GetFileName(file.FileLocation);
                if (filename == null)
                {
                    throw new InvalidDataException("File location does not have a filename");
                }

                switch (filename.Substring(0, 2).ToUpperInvariant())
                {
                    case ManhattanDataFileType.PickHeader:
                        headerFile = file;
                        break;
                    case ManhattanDataFileType.PickDetail:
                        detailFile = file;
                        break;
                    case ManhattanDataFileType.PickSpecialInstructions:
                        specialInstructionsFile = file;
                        break;
                }
            }

            if (headerFile == null || detailFile == null || specialInstructionsFile == null)
            {
                throw new InvalidDataException("File list does not contain a header, detail, and instruction file.");
            }

            var orders = _manhattanOrderRepository.GetOrders(headerFile.FileLocation, detailFile.FileLocation, null);

            _destinationRepository.SaveOrders(orders);
        }
    }
}
