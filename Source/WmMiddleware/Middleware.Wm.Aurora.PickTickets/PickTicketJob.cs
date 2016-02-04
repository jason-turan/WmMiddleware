using System.Collections.Generic;
using System.IO;
using Middleware.Jobs.Repositories;
using Middleware.WarehouseManagement.Aurora.PickTickets.Repositories;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Inventory.Manhattan;
using Middleware.Wm.Locations;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace Middleware.WarehouseManagement.Aurora.PickTickets
{
    public class PickTicketJob : OutboundProcessor
    {
        private readonly IManhattanOrderRepository _manhattanOrderRepository;
        private IPickWriter DestinationRepository { get; set; }

        public PickTicketJob(ILog logger, IPickWriter destinationRepository, IConfigurationManager configurationManager, IFileIo fileIo, IJobRepository jobRepository, ITransferControlRepository transferControlRepository, IManhattanOrderRepository manhattanOrderRepository)
            : base(logger, configurationManager, fileIo, jobRepository, transferControlRepository)
        {
            _manhattanOrderRepository = manhattanOrderRepository;
            DestinationRepository = destinationRepository;
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

            DestinationRepository.SaveOrders(orders);
        }
    }
}
