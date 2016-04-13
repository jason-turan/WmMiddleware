using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;

namespace Middleware.Wm.TransferControl.Control
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
