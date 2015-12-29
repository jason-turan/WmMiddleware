using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.InventorySync.Models.Generated
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class InventorySync
    {
        private string _processedFlag;
        [FixedLengthField(1, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ProcessedFlag
        {
            get { return _processedFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _processedFlag = value;
            }
        }

        private int _processedDate;
        [FixedLengthField(2, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ProcessedDate
        {
            get { return _processedDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _processedDate = value;
            }
        }

        private int _processedTime;
        [FixedLengthField(3, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int ProcessedTime
        {
            get { return _processedTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _processedTime = value;
            }
        }

        private int _dateCreated;
        [FixedLengthField(4, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _dateCreated = value;
            }
        }

        private int _timeCreated;
        [FixedLengthField(5, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private int _transactionNumber;
        [FixedLengthField(6, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int TransactionNumber
        {
            get { return _transactionNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _transactionNumber = value;
            }
        }

        private int _sequenceNumber;
        [FixedLengthField(7, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _sequenceNumber = value;
            }
        }

        private string _warehouse;
        [FixedLengthField(8, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        private string _company;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Company
        {
            get { return _company; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _company = value;
            }
        }

        private string _division;
        [FixedLengthField(10, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
            }
        }

        private string _season;
        [FixedLengthField(11, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string Season
        {
            get { return _season; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _season = value;
            }
        }

        private string _seasonYear;
        [FixedLengthField(12, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SeasonYear
        {
            get { return _seasonYear; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _seasonYear = value;
            }
        }

        private string _style;
        [FixedLengthField(13, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string Style
        {
            get { return _style; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _style = value;
            }
        }

        private string _styleSuffix;
        [FixedLengthField(14, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string StyleSuffix
        {
            get { return _styleSuffix; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _styleSuffix = value;
            }
        }

        private string _color;
        [FixedLengthField(15, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Color
        {
            get { return _color; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _color = value;
            }
        }

        private string _colorSuffix;
        [FixedLengthField(16, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ColorSuffix
        {
            get { return _colorSuffix; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _colorSuffix = value;
            }
        }

        private string _secDimension;
        [FixedLengthField(17, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string SecDimension
        {
            get { return _secDimension; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _secDimension = value;
            }
        }

        private string _quality;
        [FixedLengthField(18, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Quality
        {
            get { return _quality; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _quality = value;
            }
        }

        private string _sizeRngeCode;
        [FixedLengthField(19, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SizeRngeCode
        {
            get { return _sizeRngeCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _sizeRngeCode = value;
            }
        }

        private int _sizeRelPosnInTable;
        [FixedLengthField(20, 2, PaddingChar = '0', Padding = Padding.Left, NullValue="00")]
        public int SizeRelPosnInTable
        {
            get { return _sizeRelPosnInTable; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _sizeRelPosnInTable = value;
            }
        }

        private string _sizeDescription;
        [FixedLengthField(21, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SizeDescription
        {
            get { return _sizeDescription; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _sizeDescription = value;
            }
        }

        private string _inventoryType;
        [FixedLengthField(22, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string InventoryType
        {
            get { return _inventoryType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryType = value;
            }
        }

        private string _productStatus;
        [FixedLengthField(23, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductStatus
        {
            get { return _productStatus; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productStatus = value;
            }
        }

        private string _skuLotnumber;
        [FixedLengthField(24, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SkuLotnumber
        {
            get { return _skuLotnumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _skuLotnumber = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(25, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute1
        {
            get { return _skuAttribute1; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute1 = value;
            }
        }

        private string _skuAttribute2;
        [FixedLengthField(26, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute2
        {
            get { return _skuAttribute2; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute2 = value;
            }
        }

        private string _skuAttribute3;
        [FixedLengthField(27, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute3
        {
            get { return _skuAttribute3; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute3 = value;
            }
        }

        private string _skuAttribute4;
        [FixedLengthField(28, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute4
        {
            get { return _skuAttribute4; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute4 = value;
            }
        }

        private string _skuAttribute5;
        [FixedLengthField(29, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute5
        {
            get { return _skuAttribute5; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute5 = value;
            }
        }

        private string _countryOfOrigin;
        [FixedLengthField(30, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _countryOfOrigin = value;
            }
        }

        private string _hostInventoryBucket;
        [FixedLengthField(31, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue="                         ")]
        public string HostInventoryBucket
        {
            get { return _hostInventoryBucket; }
            set
            {
                if(value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _hostInventoryBucket = value;
            }
        }

        private long _warehouseQuantity;
        [FixedLengthField(32, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long WarehouseQuantity_Backing
        {
            get { return _warehouseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _warehouseQuantity = value;
            }
        }
        public decimal WarehouseQuantity
        {
            get { return WarehouseQuantity_Backing / 10000.0m; }
            set { WarehouseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _inventoryAdjustmntType;
        [FixedLengthField(33, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string InventoryAdjustmntType
        {
            get { return _inventoryAdjustmntType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryAdjustmntType = value;
            }
        }

        private long _erpQuantity;
        [FixedLengthField(34, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long ErpQuantity_Backing
        {
            get { return _erpQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _erpQuantity = value;
            }
        }
        public decimal ErpQuantity
        {
            get { return ErpQuantity_Backing / 10000.0m; }
            set { ErpQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _adjustmentFlag;
        [FixedLengthField(35, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AdjustmentFlag
        {
            get { return _adjustmentFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _adjustmentFlag = value;
            }
        }

        private string _reasonCode;
        [FixedLengthField(36, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode
        {
            get { return _reasonCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode = value;
            }
        }

        private string _reasonCodeShortDescription;
        [FixedLengthField(37, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ReasonCodeShortDescription
        {
            get { return _reasonCodeShortDescription; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reasonCodeShortDescription = value;
            }
        }

        private string _unitOfMeasure;
        [FixedLengthField(38, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _unitOfMeasure = value;
            }
        }

        private string _miscellaneousChar1;
        [FixedLengthField(39, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousChar1
        {
            get { return _miscellaneousChar1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar1 = value;
            }
        }

        private string _miscellaneousChar2;
        [FixedLengthField(40, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousChar2
        {
            get { return _miscellaneousChar2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar2 = value;
            }
        }

        private string _miscellaneousChar3;
        [FixedLengthField(41, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousChar3
        {
            get { return _miscellaneousChar3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousChar3 = value;
            }
        }

        private long _miscellaneousNumber1;
        [FixedLengthField(42, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber1_Backing
        {
            get { return _miscellaneousNumber1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber1 = value;
            }
        }
        public decimal MiscellaneousNumber1
        {
            get { return MiscellaneousNumber1_Backing / 100000.0m; }
            set { MiscellaneousNumber1_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber2;
        [FixedLengthField(43, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber2_Backing
        {
            get { return _miscellaneousNumber2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber2 = value;
            }
        }
        public decimal MiscellaneousNumber2
        {
            get { return MiscellaneousNumber2_Backing / 100000.0m; }
            set { MiscellaneousNumber2_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber3;
        [FixedLengthField(44, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber3_Backing
        {
            get { return _miscellaneousNumber3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber3 = value;
            }
        }
        public decimal MiscellaneousNumber3
        {
            get { return MiscellaneousNumber3_Backing / 100000.0m; }
            set { MiscellaneousNumber3_Backing = (int)(value * 100000.0m); }
        }

        private string _recordExpansionField;
        [FixedLengthField(45, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(46, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _programId;
        [FixedLengthField(47, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ProgramId
        {
            get { return _programId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _programId = value;
            }
        }

public int TotalFileLength { get { return 380; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
