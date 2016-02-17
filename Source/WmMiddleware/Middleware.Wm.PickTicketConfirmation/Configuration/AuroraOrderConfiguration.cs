using System.Collections.Generic;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.DataFiles;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Inventory;
using WmMiddleware.Configuration;
using WmMiddleware.Picking.Configuration;

namespace Middleware.Wm.PickTicketConfirmation.Configuration
{
    internal class AuroraOrderConfiguration : IMainframeOrderConfiguration
    {
        private readonly IPickConfiguration _configurationManager;
        private readonly IJobRepository _jobRepository;

        public AuroraOrderConfiguration(IPickConfiguration configurationManager, IJobRepository jobRepository)
        {
            _configurationManager = configurationManager;
            _jobRepository = jobRepository;
        }

        public string GetWarehouseNumber()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.WarehouseNumber);
        }

        public string GetCompanyNumber()
        {
            return _configurationManager.GetKey<string>(ConfigurationKey.CompanyNumber);
        }

        public Address GetWarehouseAddress()
        {
            return _configurationManager.GetWarehouseAddress();
        }

        public long GetBatchControlNumber()
        {
            return _configurationManager.GetBatchControlNumber();
        }

        public string GetShipTo()
        {
            return "CDX";
        }

        public IEnumerable<ManhattanPickTicketInstruction> GetPickTicketInstructions(Order order, string batchControlNumber, int instructionControlNumber)
        {
            yield break;
        }

        public string GetHeaderFilePath(long controlNumber)
        {
            return _configurationManager.GetPath(ManhattanDataFileType.PickHeader, controlNumber, "Aurora_");
        }

        public string GetDetailFilePath(long controlNumber)
        {
            return _configurationManager.GetPath(ManhattanDataFileType.PickDetail, controlNumber, "Aurora_");
        }

        public string GetSpecialInstructionFilePath(long controlNumber)
        {
            return _configurationManager.GetPath(ManhattanDataFileType.PickSpecialInstructions, controlNumber, "Aurora_");
        }

        public int GetJobId()
        {
            return _jobRepository.GetJob(JobKey.AuroraPickConfirmationJob).JobId;
        }
    }
}
