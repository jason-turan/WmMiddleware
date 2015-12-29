using System;
using WmMiddleware.Common.Extensions;

namespace WmMiddleware.Picking.Models
{
    internal partial class ManhattanPickTicketInstruction
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

        public DateTime CreateDate
        {
            get { return ManhattanExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToManhattanDate();
                TimeCreated = value.ToManhattanTime();
            }
        }
    }
}
