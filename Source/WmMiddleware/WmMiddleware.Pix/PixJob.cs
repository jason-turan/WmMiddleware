using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.ManhattanOutboundData;
using WmMiddleware.Pix.Models.Generated;
using WmMiddleware.Pix.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Pix
{
    public class PixJob : OutboundProcessor, IUnitOfWork
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

        protected override void ProcessFile(TransferControlFile file)
        {
            var pixRepository = new DataFileRepository<ManhattanPerpetualInventoryTransfer>();
            var pix = pixRepository.Get(file.FileLocation).ToList();
            _perpetualInventoryTransferRepository.InsertPerpetualInventoryTransfer(pix);
            LogInsert(pix, file);
        }
    }
}
