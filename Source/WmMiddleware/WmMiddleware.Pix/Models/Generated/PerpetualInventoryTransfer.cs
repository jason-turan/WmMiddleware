using System;
using System.Globalization;
using Dapper.Contrib.Extensions;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using WmMiddleware.Common.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.Pix.Models.Generated
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    [Table("PerpetualInventoryTransfer")]
    public partial class PerpetualInventoryTransfer : IGeneratedFlatFile
    {
        [Key]
        public int PerpetualInventoryTransferId { get; set; }

        private string _processedFlag;
        [FixedLengthField(1, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ProcessedFlag
        {
            get { return _processedFlag; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _processedFlag = value;
            }
        }

        private int _processedDate;
        [FixedLengthField(2, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
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
        [FixedLengthField(3, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
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
        [FixedLengthField(4, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
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
        [FixedLengthField(5, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private string _transactionType;
        [FixedLengthField(6, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string TransactionType
        {
            get { return _transactionType; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transactionType = value;
            }
        }

        private string _transactionCode;
        [FixedLengthField(7, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string TransactionCode
        {
            get { return _transactionCode; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transactionCode = value;
            }
        }

        private int _transactionNumber;
        [FixedLengthField(8, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
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
        [FixedLengthField(9, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _sequenceNumber = value;
            }
        }

        private string _casenumber;
        [FixedLengthField(10, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Casenumber
        {
            get { return _casenumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _casenumber = value;
            }
        }

        private string _company;
        [FixedLengthField(11, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
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
        [FixedLengthField(12, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
            }
        }

        private string _season;
        [FixedLengthField(13, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string Season
        {
            get { return _season; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _season = value;
            }
        }

        private string _seasonYear;
        [FixedLengthField(14, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
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
        [FixedLengthField(15, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string Style
        {
            get { return _style; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _style = value;
            }
        }

        private string _styleSuffix;
        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string StyleSuffix
        {
            get { return _styleSuffix; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _styleSuffix = value;
            }
        }

        private string _color;
        [FixedLengthField(17, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Color
        {
            get { return _color; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _color = value;
            }
        }

        private string _colorSuffix;
        [FixedLengthField(18, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ColorSuffix
        {
            get { return _colorSuffix; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _colorSuffix = value;
            }
        }

        private string _secDimension;
        [FixedLengthField(19, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string SecDimension
        {
            get { return _secDimension; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _secDimension = value;
            }
        }

        private string _quality;
        [FixedLengthField(20, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string Quality
        {
            get { return _quality; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _quality = value;
            }
        }

        private string _sizeRngeCode;
        [FixedLengthField(21, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string SizeRngeCode
        {
            get { return _sizeRngeCode; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _sizeRngeCode = value;
            }
        }

        private int _sizeRelPosnInTable;
        [FixedLengthField(22, 2, PaddingChar = '0', Padding = Padding.Left, NullValue = "00")]
        public int SizeRelPosnInTable
        {
            get { return _sizeRelPosnInTable; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _sizeRelPosnInTable = value;
            }
        }

        private string _inventoryType;
        [FixedLengthField(23, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InventoryType
        {
            get { return _inventoryType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryType = value;
            }
        }

        private string _productStatus;
        [FixedLengthField(24, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string ProductStatus
        {
            get { return _productStatus; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productStatus = value;
            }
        }

        private string _skuBatchnumber;
        [FixedLengthField(25, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string SkuBatchnumber
        {
            get { return _skuBatchnumber; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _skuBatchnumber = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(26, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
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
        [FixedLengthField(27, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
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
        [FixedLengthField(28, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
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
        [FixedLengthField(29, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
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
        [FixedLengthField(30, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SkuAttribute5
        {
            get { return _skuAttribute5; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute5 = value;
            }
        }

        private string _packageBarcode;
        [FixedLengthField(31, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string PackageBarcode
        {
            get { return _packageBarcode; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _packageBarcode = value;
            }
        }

        private string _area;
        [FixedLengthField(32, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Area
        {
            get { return _area; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _area = value;
            }
        }

        private string _zone;
        [FixedLengthField(33, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Zone
        {
            get { return _zone; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _zone = value;
            }
        }

        private string _aisle;
        [FixedLengthField(34, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Aisle
        {
            get { return _aisle; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _aisle = value;
            }
        }

        private string _bay;
        [FixedLengthField(35, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Bay
        {
            get { return _bay; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _bay = value;
            }
        }

        private string _level;
        [FixedLengthField(36, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Level
        {
            get { return _level; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _level = value;
            }
        }

        private string _position;
        [FixedLengthField(37, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string Position
        {
            get { return _position; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _position = value;
            }
        }

        private string _locationFileId;
        [FixedLengthField(38, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string LocationFileId
        {
            get { return _locationFileId; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _locationFileId = value;
            }
        }

        private long _inventoryAdjustmentQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(39, 15, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000000000")]
        public long InventoryAdjustmentQuantity_Backing
        {
            get { return _inventoryAdjustmentQuantity; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _inventoryAdjustmentQuantity = value;
            }
        }
        public decimal InventoryAdjustmentQuantity
        {
            get { return InventoryAdjustmentQuantity_Backing / 10000.0m; }
            set { InventoryAdjustmentQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _inventoryAdjustmntType;
        [FixedLengthField(40, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InventoryAdjustmntType
        {
            get { return _inventoryAdjustmntType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryAdjustmntType = value;
            }
        }

        private string _unitOfMeasure;
        [FixedLengthField(41, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _unitOfMeasure = value;
            }
        }

        private string _receivedFrom;
        [FixedLengthField(42, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ReceivedFrom
        {
            get { return _receivedFrom; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _receivedFrom = value;
            }
        }

        private string _warehouse;
        [FixedLengthField(43, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        private string _referenceWarehouse;
        [FixedLengthField(44, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string ReferenceWarehouse
        {
            get { return _referenceWarehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _referenceWarehouse = value;
            }
        }

        private string _transactionReasonCode;
        [FixedLengthField(45, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string TransactionReasonCode
        {
            get { return _transactionReasonCode; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _transactionReasonCode = value;
            }
        }

        private string _reasonCodeShortDescription;
        [FixedLengthField(46, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ReasonCodeShortDescription
        {
            get { return _reasonCodeShortDescription; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reasonCodeShortDescription = value;
            }
        }

        private string _receiptsVariance;
        [FixedLengthField(47, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ReceiptsVariance
        {
            get { return _receiptsVariance; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _receiptsVariance = value;
            }
        }

        private long _weight;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(48, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long Weight_Backing
        {
            get { return _weight; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _weight = value;
            }
        }
        public decimal Weight
        {
            get { return Weight_Backing / 100000.0m; }
            set { Weight_Backing = (int)(value * 100000.0m); }
        }

        private string _receiptsCompleted;
        [FixedLengthField(49, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ReceiptsCompleted
        {
            get { return _receiptsCompleted; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _receiptsCompleted = value;
            }
        }

        private int _casesShipped;
        [FixedLengthField(50, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int CasesShipped
        {
            get { return _casesShipped; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _casesShipped = value;
            }
        }

        private long _unitsShipped;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(51, 15, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000000000")]
        public long UnitsShipped_Backing
        {
            get { return _unitsShipped; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _unitsShipped = value;
            }
        }
        public decimal UnitsShipped
        {
            get { return UnitsShipped_Backing / 10000.0m; }
            set { UnitsShipped_Backing = (int)(value * 10000.0m); }
        }

        private int _casesReceived;
        [FixedLengthField(52, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int CasesReceived
        {
            get { return _casesReceived; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _casesReceived = value;
            }
        }

        private long _unitsReceived;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(53, 15, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000000000")]
        public long UnitsReceived_Backing
        {
            get { return _unitsReceived; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _unitsReceived = value;
            }
        }
        public decimal UnitsReceived
        {
            get { return UnitsReceived_Backing / 10000.0m; }
            set { UnitsReceived_Backing = (int)(value * 10000.0m); }
        }

        private string _referenceCode1;
        [FixedLengthField(54, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode1
        {
            get { return _referenceCode1; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode1 = value;
            }
        }

        private string _reference1;
        [FixedLengthField(55, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference1
        {
            get { return _reference1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference1 = value;
            }
        }

        private string _referenceCode2;
        [FixedLengthField(56, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode2
        {
            get { return _referenceCode2; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode2 = value;
            }
        }

        private string _reference2;
        [FixedLengthField(57, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference2
        {
            get { return _reference2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference2 = value;
            }
        }

        private string _referenceCode3;
        [FixedLengthField(58, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode3
        {
            get { return _referenceCode3; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode3 = value;
            }
        }

        private string _reference3;
        [FixedLengthField(59, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference3
        {
            get { return _reference3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference3 = value;
            }
        }

        private string _referenceCode4;
        [FixedLengthField(60, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode4
        {
            get { return _referenceCode4; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode4 = value;
            }
        }

        private string _reference4;
        [FixedLengthField(61, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference4
        {
            get { return _reference4; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference4 = value;
            }
        }

        private string _referenceCode5;
        [FixedLengthField(62, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode5
        {
            get { return _referenceCode5; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode5 = value;
            }
        }

        private string _reference5;
        [FixedLengthField(63, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference5
        {
            get { return _reference5; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference5 = value;
            }
        }

        private string _referenceCode6;
        [FixedLengthField(64, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode6
        {
            get { return _referenceCode6; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode6 = value;
            }
        }

        private string _reference6;
        [FixedLengthField(65, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference6
        {
            get { return _reference6; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference6 = value;
            }
        }

        private string _referenceCode7;
        [FixedLengthField(66, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode7
        {
            get { return _referenceCode7; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode7 = value;
            }
        }

        private string _reference7;
        [FixedLengthField(67, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference7
        {
            get { return _reference7; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference7 = value;
            }
        }

        private string _referenceCode8;
        [FixedLengthField(68, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReferenceCode8
        {
            get { return _referenceCode8; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode8 = value;
            }
        }

        private string _reference8;
        [FixedLengthField(69, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Reference8
        {
            get { return _reference8; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference8 = value;
            }
        }

        private string _pixReference1;
        [FixedLengthField(70, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string PixReference1
        {
            get { return _pixReference1; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _pixReference1 = value;
            }
        }

        private string _pixReference2;
        [FixedLengthField(71, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string PixReference2
        {
            get { return _pixReference2; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _pixReference2 = value;
            }
        }

        private string _pixReference3;
        [FixedLengthField(72, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string PixReference3
        {
            get { return _pixReference3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pixReference3 = value;
            }
        }

        private string _actionCode;
        [FixedLengthField(73, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ActionCode
        {
            get { return _actionCode; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _actionCode = value;
            }
        }

        private string _customReference;
        [FixedLengthField(74, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
        public string CustomReference
        {
            get { return _customReference; }
            set
            {
                if (value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customReference = value;
            }
        }

        private string _shipmentnumber;
        [FixedLengthField(75, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Shipmentnumber
        {
            get { return _shipmentnumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipmentnumber = value;
            }
        }

        // Will need this to reconcile receipts to the Ledger integration tables.
        private string _ponumber;
        [FixedLengthField(76, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Ponumber
        {
            get { return _ponumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _ponumber = value;
            }
        }

        private int _purchaseOrderLine;
        [FixedLengthField(77, 6, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000")]
        public int PurchaseOrderLine
        {
            get { return _purchaseOrderLine; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 6) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderLine = value;
            }
        }

        private string _vendorAsnNumber;
        [FixedLengthField(78, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string VendorAsnNumber
        {
            get { return _vendorAsnNumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _vendorAsnNumber = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(79, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(80, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _programId;
        [FixedLengthField(81, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ProgramId
        {
            get { return _programId; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _programId = value;
            }
        }

        private string _jobName;
        [FixedLengthField(82, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string JobName
        {
            get { return _jobName; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _jobName = value;
            }
        }

        private string _jobNumber;
        [FixedLengthField(83, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue = "      ")]
        public string JobNumber
        {
            get { return _jobNumber; }
            set
            {
                if (value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _jobNumber = value;
            }
        }

        private string _userId;
        [FixedLengthField(84, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _userId = value;
            }
        }

        private string _iseriesUserId;
        [FixedLengthField(85, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string IseriesUserId
        {
            get { return _iseriesUserId; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _iseriesUserId = value;
            }
        }

        private string _errorComment;
        [FixedLengthField(86, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                         ")]
        public string ErrorComment
        {
            get { return _errorComment; }
            set
            {
                if (value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _errorComment = value;
            }
        }

        private string _sizeDescription;
        [FixedLengthField(87, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string SizeDescription
        {
            get { return _sizeDescription; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _sizeDescription = value;
            }
        }

        private string _countryOfOrigin;
        [FixedLengthField(88, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _countryOfOrigin = value;
            }
        }

        private string _entryNumber;
        [FixedLengthField(89, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string EntryNumber
        {
            get { return _entryNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _entryNumber = value;
            }
        }

        private int _crossReferenceSequence;
        [FixedLengthField(90, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int CrossReferenceSequence
        {
            get { return _crossReferenceSequence; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _crossReferenceSequence = value;
            }
        }

        private string _statFld1;
        [FixedLengthField(91, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string StatFld1
        {
            get { return _statFld1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _statFld1 = value;
            }
        }

        private string _statFld2;
        [FixedLengthField(92, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string StatFld2
        {
            get { return _statFld2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _statFld2 = value;
            }
        }

        private string _statFld3;
        [FixedLengthField(93, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string StatFld3
        {
            get { return _statFld3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _statFld3 = value;
            }
        }

        private string _inventoryImpact;
        [FixedLengthField(94, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InventoryImpact
        {
            get { return _inventoryImpact; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryImpact = value;
            }
        }

        private string _batchControlNumber;
        [FixedLengthField(95, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private string _pixMessageType;
        [FixedLengthField(96, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string PixMessageType
        {
            get { return _pixMessageType; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pixMessageType = value;
            }
        }

        private string _miscellaneousIns1;
        [FixedLengthField(97, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns1
        {
            get { return _miscellaneousIns1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns1 = value;
            }
        }

        private string _miscellaneousIns2;
        [FixedLengthField(98, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns2
        {
            get { return _miscellaneousIns2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns2 = value;
            }
        }

        private string _miscellaneousIns3;
        [FixedLengthField(99, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns3
        {
            get { return _miscellaneousIns3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns3 = value;
            }
        }

        private long _miscellaneousNum1;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(100, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum1_Backing
        {
            get { return _miscellaneousNum1; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum1 = value;
            }
        }
        public decimal MiscellaneousNum1
        {
            get { return MiscellaneousNum1_Backing / 100000.0m; }
            set { MiscellaneousNum1_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum2;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(101, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum2_Backing
        {
            get { return _miscellaneousNum2; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum2 = value;
            }
        }
        public decimal MiscellaneousNum2
        {
            get { return MiscellaneousNum2_Backing / 100000.0m; }
            set { MiscellaneousNum2_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum3;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(102, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum3_Backing
        {
            get { return _miscellaneousNum3; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum3 = value;
            }
        }
        public decimal MiscellaneousNum3
        {
            get { return MiscellaneousNum3_Backing / 100000.0m; }
            set { MiscellaneousNum3_Backing = (int)(value * 100000.0m); }
        }

        private string _electronicSignatureUser;
        [FixedLengthField(103, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
        public string ElectronicSignatureUser
        {
            get { return _electronicSignatureUser; }
            set
            {
                if (value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _electronicSignatureUser = value;
            }
        }

        [Write(false)] // dapper attribute specifying not to write this property to the database
        public int TotalFileLength { get { return 977; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
