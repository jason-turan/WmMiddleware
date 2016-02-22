using System.Collections.Generic;
using System.Data;
using System.IO;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Aurora.PickTickets.Repositories;
using Middleware.Wm.Configuration;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.DataFiles;
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
        private readonly IAuroraPickTicketRepository _auroraPickTicketRepository;

        public PickTicketJob(ILog logger, 
                             IOrderWriter destinationRepository, 
                             IConfigurationManager configurationManager, 
                             IFileIo fileIo, 
                             IJobRepository jobRepository, 
                             ITransferControlRepository transferControlRepository, 
                             IManhattanOrderRepository manhattanOrderRepository,
                             IAuroraPickTicketRepository auroraPickTicketRepository)
            : base(logger, configurationManager, fileIo, jobRepository, transferControlRepository)
        {
            _destinationRepository = destinationRepository;
            _manhattanOrderRepository = manhattanOrderRepository;
            _auroraPickTicketRepository = auroraPickTicketRepository;
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

            var headers = _manhattanOrderRepository.GetManhattanPickTicketHeaders(headerFile.FileLocation);
            var details = _manhattanOrderRepository.GetManhattanPickTicketDetails(detailFile.FileLocation);
            var instructions = _manhattanOrderRepository.GetManhattanPickTicketInstructions(specialInstructionsFile.FileLocation);

            var orders = _manhattanOrderRepository.GetOrders(headers, details);

            _auroraPickTicketRepository.InsertAuroraPickTicketHeader(headers);
            _auroraPickTicketRepository.InsertAuroraPickTicketDetail(details);
            _auroraPickTicketRepository.InsertAuroraPickTicketInstruction(instructions);

            _destinationRepository.SaveOrders(orders);
        }
    }
}
