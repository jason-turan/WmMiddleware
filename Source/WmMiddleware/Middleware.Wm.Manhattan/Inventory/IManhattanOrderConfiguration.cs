using System.Collections.Generic;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.Manhattan.Inventory
{
    public interface IManhattanOrderConfiguration
    {
        string GetWarehouseNumber();
        string GetCompanyNumber();
        Address GetWarehouseAddress();
        long GetBatchControlNumber();

        IEnumerable<ManhattanPickTicketInstruction> GetPickTicketInstructions(Order order, string batchControlNumber, int instructionControlNumber);

        string GetHeaderFilePath(long controlNumber);
        string GetDetailFilePath(long controlNumber);
        string GetSpecialInstructionFilePath(long controlNumber);

        int GetJobId();
    }
}
