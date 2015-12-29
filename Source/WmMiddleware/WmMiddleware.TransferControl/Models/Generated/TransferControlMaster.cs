using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using WmMiddleware.Common.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.TransferControl.Models.Generated
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class TransferControlMaster : IGeneratedFlatFile
    {
        // Used by New Balance
        // Server ID, Always "I00" for NB Host transactions
        private string _transferType;
        [FixedLengthField(1, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string TransferType
        {
            get { return _transferType; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transferType = value;
            }
        }

        private int _priority;
        [FixedLengthField(2, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int Priority_Backing
        {
            get { return _priority; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _priority = value;
            }
        }
        public decimal Priority
        {
            get { return Priority_Backing / 100.0m; }
            set { Priority_Backing = (int)(value * 100.0m); }
        }

        // Used by New Balance
        // Destination library name on the WM system
        private string _library;
        [FixedLengthField(3, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Library
        {
            get { return _library; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _library = value;
            }
        }

        // Used by New Balance
        // Name of the flat file transmitted to WM - Prefix is the 2 position interface file ID (ex. I1 = Pick Header, I2 = Pick Details, I3 = Pick Instructions, I5 = Style Master)
        private string _filename;
        [FixedLengthField(4, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Filename
        {
            get { return _filename; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _filename = value;
            }
        }

        // Used by New Balance
        // Same as XBDBNM above
        private string _member;
        [FixedLengthField(5, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Member
        {
            get { return _member; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _member = value;
            }
        }

        private string _ifsFileNameWithPath;
        [FixedLengthField(6, 150, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                                                                                                                                      ")]
        public string IfsFileNameWithPath
        {
            get { return _ifsFileNameWithPath; }
            set
            {
                if (value != default(string) && value.Length > 150) throw new ArgumentOutOfRangeException("value");
                _ifsFileNameWithPath = value;
            }
        }

        // Used by New Balance
        // Unique transaction batch control number (prefix is the warehouse number)
        private string _batchControlNumber;
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private string _transferMesg;
        [FixedLengthField(8, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                                  ")]
        public string TransferMesg
        {
            get { return _transferMesg; }
            set
            {
                if (value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _transferMesg = value;
            }
        }

        private int _beginDate;
        [FixedLengthField(9, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int BeginDate
        {
            get { return _beginDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _beginDate = value;
            }
        }

        private int _beginTime;
        [FixedLengthField(10, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int BeginTime
        {
            get { return _beginTime; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _beginTime = value;
            }
        }

        private int _endDate;
        [FixedLengthField(11, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int EndDate
        {
            get { return _endDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _endDate = value;
            }
        }

        private int _endTime;
        [FixedLengthField(12, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int EndTime
        {
            get { return _endTime; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _endTime = value;
            }
        }

        // Used by New Balance
        // Always "10", which is 'open' to WM
        private string _statusFlag;
        [FixedLengthField(13, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string StatusFlag
        {
            get { return _statusFlag; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _statusFlag = value;
            }
        }

        private string _transmissionStat;
        [FixedLengthField(14, 80, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                                                                ")]
        public string TransmissionStat
        {
            get { return _transmissionStat; }
            set
            {
                if (value != default(string) && value.Length > 80) throw new ArgumentOutOfRangeException("value");
                _transmissionStat = value;
            }
        }

        private string _deleteXbctrlRecords;
        [FixedLengthField(15, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string DeleteXbctrlRecords
        {
            get { return _deleteXbctrlRecords; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deleteXbctrlRecords = value;
            }
        }

        private int _ifsFileLength;
        [FixedLengthField(16, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int IfsFileLength
        {
            get { return _ifsFileLength; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _ifsFileLength = value;
            }
        }

        private long _uniqueIdentifier;
        [FixedLengthField(17, 10, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000")]
        public long UniqueIdentifier
        {
            get { return _uniqueIdentifier; }
            set
            {
                if (value != default(long) && value.ToString(CultureInfo.InvariantCulture).Length > 10) throw new ArgumentOutOfRangeException("value");
                _uniqueIdentifier = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(18, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(19, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        // Used by New Balance
        // Date created
        private int _dateCreated;
        [FixedLengthField(20, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _dateCreated = value;
            }
        }

        // Used by New Balance
        // time created
        private int _timeCreated;
        [FixedLengthField(21, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private int _dateLastModified;
        [FixedLengthField(22, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int DateLastModified
        {
            get { return _dateLastModified; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _dateLastModified = value;
            }
        }

        private int _timeLastModified;
        [FixedLengthField(23, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int TimeLastModified
        {
            get { return _timeLastModified; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeLastModified = value;
            }
        }

        // Used by New Balance
        // Program ID
        private string _userId;
        [FixedLengthField(24, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _userId = value;
            }
        }

        public int TotalFileLength { get { return 484; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
