using System;
using System.Globalization;
using Dapper.Contrib.Extensions;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using WmMiddleware.Common.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.InventorySync.Models.Generated
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    [Table("ManhattanInventorySync")]
    public partial class ManhattanInventorySync : IGeneratedFlatFile
    {
        [Key]
        public int ManhattanInventorySyncId { get; set; }

        private int _processedDate;
        [FixedLengthField(1, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int ProcessedDate
        {
            get { return _processedDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _processedDate = value;
            }
        }

        private int _processedTime;
        [FixedLengthField(2, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int ProcessedTime
        {
            get { return _processedTime; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _processedTime = value;
            }
        }

        private int _dateCreated;
        [FixedLengthField(3, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _dateCreated = value;
            }
        }

        private int _timeCreated;
        [FixedLengthField(4, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private int _transactionNumber;
        [FixedLengthField(5, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int TransactionNumber
        {
            get { return _transactionNumber; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _transactionNumber = value;
            }
        }

        private int _sequenceNumber;
        [FixedLengthField(6, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _sequenceNumber = value;
            }
        }

        private string _warehouse;
        [FixedLengthField(7, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        private string _company;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Company
        {
            get { return _company; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _company = value;
            }
        }

        private string _division;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
            }
        }

        private string _seasonYear;
        [FixedLengthField(10, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SeasonYear
        {
            get { return _seasonYear; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _seasonYear = value;
            }
        }

        private string _style;
        [FixedLengthField(11, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string Style
        {
            get { return _style; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _style = value;
            }
        }

        private string _color;
        [FixedLengthField(12, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Color
        {
            get { return _color; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _color = value;
            }
        }

        private string _secDimension;
        [FixedLengthField(13, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string SecDimension
        {
            get { return _secDimension; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _secDimension = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(14, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute1
        {
            get { return _skuAttribute1; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute1 = value;
            }
        }

        private string _skuAttribute2;
        [FixedLengthField(15, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute2
        {
            get { return _skuAttribute2; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute2 = value;
            }
        }

        private string _skuAttribute3;
        [FixedLengthField(16, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute3
        {
            get { return _skuAttribute3; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute3 = value;
            }
        }

        private string _skuAttribute4;
        [FixedLengthField(17, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute4
        {
            get { return _skuAttribute4; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute4 = value;
            }
        }

        private string _skuAttribute5;
        [FixedLengthField(18, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute5
        {
            get { return _skuAttribute5; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute5 = value;
            }
        }

        private string _hostInventoryBucket;
        [FixedLengthField(19, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                         ")]
        public string HostInventoryBucket
        {
            get { return _hostInventoryBucket; }
            set
            {
                if (value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _hostInventoryBucket = value;
            }
        }

        private long _warehouseQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(20, 15, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000000000")]
        public long WarehouseQuantity_Backing
        {
            get { return _warehouseQuantity; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _warehouseQuantity = value;
            }
        }
        public decimal WarehouseQuantity
        {
            get { return WarehouseQuantity_Backing / 10000.0m; }
            set { WarehouseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _inventoryAdjustmntType;
        [FixedLengthField(21, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InventoryAdjustmntType
        {
            get { return _inventoryAdjustmntType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryAdjustmntType = value;
            }
        }

        private string _miscellaneousChar1;
        [FixedLengthField(22, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousChar1
        {
            get { return _miscellaneousChar1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar1 = value;
            }
        }

        private string _miscellaneousChar2;
        [FixedLengthField(23, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousChar2
        {
            get { return _miscellaneousChar2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar2 = value;
            }
        }

        private string _miscellaneousChar3;
        [FixedLengthField(24, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousChar3
        {
            get { return _miscellaneousChar3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar3 = value;
            }
        }

        private long _miscellaneousNumber1;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(25, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNumber1_Backing
        {
            get { return _miscellaneousNumber1; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber1 = value;
            }
        }
        public decimal MiscellaneousNumber1
        {
            get { return MiscellaneousNumber1_Backing / 100000.0m; }
            set { MiscellaneousNumber1_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber2;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(26, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNumber2_Backing
        {
            get { return _miscellaneousNumber2; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber2 = value;
            }
        }
        public decimal MiscellaneousNumber2
        {
            get { return MiscellaneousNumber2_Backing / 100000.0m; }
            set { MiscellaneousNumber2_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber3;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(27, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNumber3_Backing
        {
            get { return _miscellaneousNumber3; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber3 = value;
            }
        }
        public decimal MiscellaneousNumber3
        {
            get { return MiscellaneousNumber3_Backing / 100000.0m; }
            set { MiscellaneousNumber3_Backing = (int)(value * 100000.0m); }
        }

        private string _recordExpansionField;
        [FixedLengthField(28, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(29, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        [Write(false)] // dapper attribute specifying not to write this property to the database
        public int TotalFileLength { get { return 271; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
