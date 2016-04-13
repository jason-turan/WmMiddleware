using System;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Extensions;

namespace Middleware.Wm.Manhattan.Inventory
{
    public partial class ManhattanPickTicketInstruction
    {
        public ManhattanPickTicketInstruction()
        {
            
        }

        public ManhattanPickTicketInstruction(string specialInstructionType, string specialInstructionCode, string instruction, string batchControlNumber, string pickTicketControlNumber, int specialInstructionNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            PickticketControlNumber = pickTicketControlNumber;
            SpecialInstructionNumber = specialInstructionNumber;
            SpecialInstructionType = specialInstructionType;
            SpecialInstructionCode = specialInstructionCode;
            SpecialInstructionDescription = instruction;
        }

        [Write(false)]
        public DateTime CreateDate
        {
            get { return MainframeExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToMainframeDate();
                TimeCreated = value.ToMainframeTime();
            }
        }

        public override string ToString()
        {
            return SpecialInstructionDescription;
        }
    }
}
