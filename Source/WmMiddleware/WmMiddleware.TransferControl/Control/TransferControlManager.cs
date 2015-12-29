using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Control
{
    public class TransferControlManager : ITransferControlManager
    {
        private readonly ITransferControlRepository _transferControlRepository;

        public TransferControlManager(ITransferControlRepository transferControlRepository)
        {
            _transferControlRepository = transferControlRepository;
        }

        public void SaveTransferControl(string controlNumber, IList<string> files, int jobId)
        {
            _transferControlRepository.InsertTransferControl(new Models.TransferControl
            {
                BatchControlNumber = controlNumber.ToString(CultureInfo.InvariantCulture),
                Files = files.Select(file => new TransferControlFile { FileLocation = file }).ToList(),
                ReceivedDate = DateTime.Now,
                JobId = jobId
            });
        }
    }
}
