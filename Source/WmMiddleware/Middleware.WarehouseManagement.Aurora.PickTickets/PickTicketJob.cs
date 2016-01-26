using System.Collections.Generic;
using System.IO;
using System.Linq;
using Middleware.Jobs.Repositories;
using Middleware.WarehouseManagement.Aurora.PickTickets.Models;
using Middleware.WarehouseManagement.Aurora.PickTickets.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace Middleware.WarehouseManagement.Aurora.PickTickets
{
    public class PickTicketJob : OutboundProcessor
    {
        private IPickWriter DestinationRepository { get; set; }

        private readonly DataFileRepository<ManhattanPickTicketHeader> _headerRepository = new DataFileRepository<ManhattanPickTicketHeader>();
        private readonly DataFileRepository<ManhattanPickTicketDetail> _detailRepository = new DataFileRepository<ManhattanPickTicketDetail>();

        public PickTicketJob(ILog logger, IPickWriter destinationRepository, IConfigurationManager configurationManager, IFileIo fileIo, IJobRepository jobRepository, ITransferControlRepository transferControlRepository)
            : base(logger, configurationManager, fileIo, jobRepository, transferControlRepository)
        {
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

            var headers = _headerRepository.Get(headerFile.FileLocation);
            var details = _detailRepository.Get(detailFile.FileLocation);

            var orders = headers.ToDictionary(h => h.PickticketControlNumber, h => h.ToOrder());

            foreach (var detail in details)
            {
                var lineItem = detail.ToLineItem();
                orders[detail.PickticketControlNumber].Items.Add(lineItem);
            }

            DestinationRepository.SaveOrders(orders.Values);
        }
    }
}
