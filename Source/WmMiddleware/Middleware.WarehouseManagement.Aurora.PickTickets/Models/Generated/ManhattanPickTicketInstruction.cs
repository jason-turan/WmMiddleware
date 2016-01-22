using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Middleware.WarehouseManagement.Aurora.PickTickets.Models
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class ManhattanPickTicketInstruction
    {
        private int _errorSequence;
        [FixedLengthField(1, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ErrorSequence
        {
            get { return _errorSequence; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _errorSequence = value;
            }
        }

        // Used by New Balance
        // Unique transaction batch control number (prefix is the warehouse number)
        private string _batchControlNumber;
        [FixedLengthField(2, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        // Used by New Balance
        // date created
        private int _dateCreated;
        [FixedLengthField(3, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _dateCreated = value;
            }
        }

        // Used by New Balance
        // time created
        private int _timeCreated;
        [FixedLengthField(4, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private string _userId;
        [FixedLengthField(5, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _userId = value;
            }
        }

        // Used by New Balance
        // pick ticket
        private string _pickticketControlNumber;
        [FixedLengthField(6, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string PickticketControlNumber
        {
            get { return _pickticketControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _pickticketControlNumber = value;
            }
        }

        private int _pickticketLineNumber;
        [FixedLengthField(7, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int PickticketLineNumber
        {
            get { return _pickticketLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _pickticketLineNumber = value;
            }
        }

        // Used by New Balance
        // unique number for the pick ticket
        private int _specialInstructionNumber;
        [FixedLengthField(8, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int SpecialInstructionNumber
        {
            get { return _specialInstructionNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _specialInstructionNumber = value;
            }
        }

        // Used by New Balance
        // VA = VAS, "BL" = Bill of Lading, "SI" = Shipper Info, "TP" = Third Party Billing Address, "MA" = Mark for address or DC association address - if PHSTOR is filled place in Mark For address and ignore DC address if exists - else check for DC association, if exists put in DC association address
        private string _specialInstructionType;
        [FixedLengthField(9, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionType
        {
            get { return _specialInstructionType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionType = value;
            }
        }

        // Used by New Balance
        // "VA" Type: "VA" code is VAS, "OR" code is order external text and 'call CS for back orders', "SH" code is shipping instructions, "ST" code is VAS at Style level.  "BL" Type with a blank "  " code is Bill of Lading data.  "SI" Type with a blank "  " code is Shipper Info.  "TP" Type with "TP" code is Third Party Billing Address.  "MA" Type with "MA" code is Mark For address or DC Association address.   
        private string _specialInstructionCode;
        [FixedLengthField(10, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode
        {
            get { return _specialInstructionCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode = value;
            }
        }

        // Used by New Balance
        // Description
        private string _specialInstructionDescription;
        [FixedLengthField(11, 100, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                                                                    ")]
        public string SpecialInstructionDescription
        {
            get { return _specialInstructionDescription; }
            set
            {
                if(value != default(string) && value.Length > 100) throw new ArgumentOutOfRangeException("value");
                _specialInstructionDescription = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(12, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(13, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

public int TotalFileLength { get { return 227; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
