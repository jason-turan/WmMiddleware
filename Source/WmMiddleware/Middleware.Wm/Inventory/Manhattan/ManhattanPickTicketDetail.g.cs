using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

namespace Middleware.Wm.Inventory.Manhattan
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    public partial class ManhattanPickTicketDetail
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

        private string _programId;
        [FixedLengthField(6, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ProgramId
        {
            get { return _programId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _programId = value;
            }
        }

        // Used by New Balance
        // company
        private string _company;
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Company
        {
            get { return _company; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _company = value;
            }
        }

        // Used by New Balance
        // Warehouse code "22" for Lawrence, "33" for Ontario
        private string _division;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
            }
        }

        // Used by New Balance
        // Pick Ticket Number (JBA Order # (7 pos) and Shipment Seq # (3 pos))
        private string _pickticketControlNumber;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string PickticketControlNumber
        {
            get { return _pickticketControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _pickticketControlNumber = value;
            }
        }

        // Used by New Balance
        // JBA Line number is 3 positions numeric.  Multiply JBA line number by 100 and add a one up sequence number to make this value UNIQUE FOR EACH LINE AND SKU combination.
        private int _pickticketLineNumber;
        [FixedLengthField(10, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int PickticketLineNumber
        {
            get { return _pickticketLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _pickticketLineNumber = value;
            }
        }

        private int _sizeRelPosninTable;
        [FixedLengthField(11, 2, PaddingChar = '0', Padding = Padding.Left, NullValue="00")]
        public int SizeRelPosninTable
        {
            get { return _sizeRelPosninTable; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _sizeRelPosninTable = value;
            }
        }

        // Used by New Balance
        // Warehouse code "22" for Lawrence, "33" for Ontario
        private string _warehouse;
        [FixedLengthField(12, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        // Used by New Balance
        // 1 = Non Shoes or Demo Shoes; DV = Shoes, VAS Required and a DOB; 3V = Shoes, VAS Required; D = Shoes and a DOB; 3 = Shoes (no VAS, no DOB)
        private string _waveProcessingType;
        [FixedLengthField(13, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string WaveProcessingType
        {
            get { return _waveProcessingType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _waveProcessingType = value;
            }
        }

        private string _season;
        [FixedLengthField(14, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string Season
        {
            get { return _season; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _season = value;
            }
        }

        // Used by New Balance
        // First 2 bytes of Style
        private string _seasonYear;
        [FixedLengthField(15, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SeasonYear
        {
            get { return _seasonYear; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _seasonYear = value;
            }
        }

        // Used by New Balance
        // Last 7 bytes of Style
        private string _style;
        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(17, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string StyleSuffix
        {
            get { return _styleSuffix; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _styleSuffix = value;
            }
        }

        // Used by New Balance
        // Color/Width
        private string _color;
        [FixedLengthField(18, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(19, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ColorSuffix
        {
            get { return _colorSuffix; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _colorSuffix = value;
            }
        }

        // Used by New Balance
        // Size
        private string _secDimension;
        [FixedLengthField(20, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        [FixedLengthField(21, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Quality
        {
            get { return _quality; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _quality = value;
            }
        }

        private string _sizeRangeCode;
        [FixedLengthField(22, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SizeRangeCode
        {
            get { return _sizeRangeCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _sizeRangeCode = value;
            }
        }

        private string _sizeDescription;
        [FixedLengthField(23, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SizeDescription
        {
            get { return _sizeDescription; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _sizeDescription = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(24, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(25, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(26, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(27, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(28, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute5
        {
            get { return _skuAttribute5; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute5 = value;
            }
        }

        private string _productStatus;
        [FixedLengthField(29, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductStatus
        {
            get { return _productStatus; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productStatus = value;
            }
        }

        // Used by New Balance
        // Must be the Lot # if the Pick is a DOB.  JBA uses actual PO# or WO# (utilizing the forced reservation feature).  The ASN linked to the sales order (pick) will contain the same value.  Non DOB picks leave this field blanks.
        private string _batchNumber;
        [FixedLengthField(30, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string BatchNumber
        {
            get { return _batchNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _batchNumber = value;
            }
        }

        private string _countryOfOrigin;
        [FixedLengthField(31, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _countryOfOrigin = value;
            }
        }

        private string _packageBarcode;
        [FixedLengthField(32, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PackageBarcode
        {
            get { return _packageBarcode; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _packageBarcode = value;
            }
        }

        private string _area;
        [FixedLengthField(33, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Area
        {
            get { return _area; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _area = value;
            }
        }

        private string _zone;
        [FixedLengthField(34, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Zone
        {
            get { return _zone; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _zone = value;
            }
        }

        private string _aisle;
        [FixedLengthField(35, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Aisle
        {
            get { return _aisle; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _aisle = value;
            }
        }

        private string _bay;
        [FixedLengthField(36, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Bay
        {
            get { return _bay; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _bay = value;
            }
        }

        private string _level;
        [FixedLengthField(37, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Level
        {
            get { return _level; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _level = value;
            }
        }

        private string _position;
        [FixedLengthField(38, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Position
        {
            get { return _position; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _position = value;
            }
        }

        // Used by New Balance
        // Always F
        private string _inventoryType;
        [FixedLengthField(39, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string InventoryType
        {
            get { return _inventoryType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _inventoryType = value;
            }
        }

        private string _pathNumber;
        [FixedLengthField(40, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private string _pickLocAssignmentType;
        [FixedLengthField(41, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickLocAssignmentType
        {
            get { return _pickLocAssignmentType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickLocAssignmentType = value;
            }
        }

        private string _pickDeterminationType;
        [FixedLengthField(42, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickDeterminationType
        {
            get { return _pickDeterminationType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickDeterminationType = value;
            }
        }

        private long _originalOrderQuantity;
        [FixedLengthField(43, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long OriginalOrderQuantity_Backing
        {
            get { return _originalOrderQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _originalOrderQuantity = value;
            }
        }
        public decimal OriginalOrderQuantity
        {
            get { return OriginalOrderQuantity_Backing / 10000.0m; }
            set { OriginalOrderQuantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Pick qty
        private long _originalPickticketQuantity;
        [FixedLengthField(44, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long OriginalPickticketQuantity_Backing
        {
            get { return _originalPickticketQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _originalPickticketQuantity = value;
            }
        }
        public decimal OriginalPickticketQuantity
        {
            get { return OriginalPickticketQuantity_Backing / 10000.0m; }
            set { OriginalPickticketQuantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Pick qty
        private long _pickticketQuantity;
        [FixedLengthField(45, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long PickticketQuantity_Backing
        {
            get { return _pickticketQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _pickticketQuantity = value;
            }
        }
        public decimal PickticketQuantity
        {
            get { return PickticketQuantity_Backing / 10000.0m; }
            set { PickticketQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _cancelQuantity;
        [FixedLengthField(46, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long CancelQuantity_Backing
        {
            get { return _cancelQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _cancelQuantity = value;
            }
        }
        public decimal CancelQuantity
        {
            get { return CancelQuantity_Backing / 10000.0m; }
            set { CancelQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _packMultipleQuantity;
        [FixedLengthField(47, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long PackMultipleQuantity_Backing
        {
            get { return _packMultipleQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _packMultipleQuantity = value;
            }
        }
        public decimal PackMultipleQuantity
        {
            get { return PackMultipleQuantity_Backing / 10000.0m; }
            set { PackMultipleQuantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Always 1
        private long _boxQuantity;
        [FixedLengthField(48, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long BoxQuantity_Backing
        {
            get { return _boxQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _boxQuantity = value;
            }
        }
        public decimal BoxQuantity
        {
            get { return BoxQuantity_Backing / 10000.0m; }
            set { BoxQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _packQuantity;
        [FixedLengthField(49, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long PackQuantity_Backing
        {
            get { return _packQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _packQuantity = value;
            }
        }
        public decimal PackQuantity
        {
            get { return PackQuantity_Backing / 10000.0m; }
            set { PackQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _caseQuantity;
        [FixedLengthField(50, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long CaseQuantity_Backing
        {
            get { return _caseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _caseQuantity = value;
            }
        }
        public decimal CaseQuantity
        {
            get { return CaseQuantity_Backing / 10000.0m; }
            set { CaseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _tierQuantity;
        [FixedLengthField(51, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long TierQuantity_Backing
        {
            get { return _tierQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _tierQuantity = value;
            }
        }
        public decimal TierQuantity
        {
            get { return TierQuantity_Backing / 10000.0m; }
            set { TierQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _palletQuantity;
        [FixedLengthField(52, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long PalletQuantity_Backing
        {
            get { return _palletQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _palletQuantity = value;
            }
        }
        public decimal PalletQuantity
        {
            get { return PalletQuantity_Backing / 10000.0m; }
            set { PalletQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _unitWeight;
        [FixedLengthField(53, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long UnitWeight_Backing
        {
            get { return _unitWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _unitWeight = value;
            }
        }
        public decimal UnitWeight
        {
            get { return UnitWeight_Backing / 100000.0m; }
            set { UnitWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _unitVolume;
        [FixedLengthField(54, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long UnitVolume_Backing
        {
            get { return _unitVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _unitVolume = value;
            }
        }
        public decimal UnitVolume
        {
            get { return UnitVolume_Backing / 100000.0m; }
            set { UnitVolume_Backing = (int)(value * 100000.0m); }
        }

        private long _innerPackWieght;
        [FixedLengthField(55, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long InnerPackWieght_Backing
        {
            get { return _innerPackWieght; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _innerPackWieght = value;
            }
        }
        public decimal InnerPackWieght
        {
            get { return InnerPackWieght_Backing / 100000.0m; }
            set { InnerPackWieght_Backing = (int)(value * 100000.0m); }
        }

        private long _innerPackVolume;
        [FixedLengthField(56, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long InnerPackVolume_Backing
        {
            get { return _innerPackVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _innerPackVolume = value;
            }
        }
        public decimal InnerPackVolume
        {
            get { return InnerPackVolume_Backing / 100000.0m; }
            set { InnerPackVolume_Backing = (int)(value * 100000.0m); }
        }

        private long _packMultipleWeight;
        [FixedLengthField(57, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long PackMultipleWeight_Backing
        {
            get { return _packMultipleWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _packMultipleWeight = value;
            }
        }
        public decimal PackMultipleWeight
        {
            get { return PackMultipleWeight_Backing / 100000.0m; }
            set { PackMultipleWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _packMultipleVolume;
        [FixedLengthField(58, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long PackMultipleVolume_Backing
        {
            get { return _packMultipleVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _packMultipleVolume = value;
            }
        }
        public decimal PackMultipleVolume
        {
            get { return PackMultipleVolume_Backing / 100000.0m; }
            set { PackMultipleVolume_Backing = (int)(value * 100000.0m); }
        }

        private string _styleDescription;
        [FixedLengthField(59, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string StyleDescription
        {
            get { return _styleDescription; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _styleDescription = value;
            }
        }

        private string _colorDescription;
        [FixedLengthField(60, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ColorDescription
        {
            get { return _colorDescription; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _colorDescription = value;
            }
        }

        // Used by New Balance
        // NB specific database (NOEP003) Customer cross reference file, field GRID03
        private string _customerSku;
        [FixedLengthField(61, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string CustomerSku
        {
            get { return _customerSku; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customerSku = value;
            }
        }

        private string _prePackGroupCode;
        [FixedLengthField(62, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PrePackGroupCode
        {
            get { return _prePackGroupCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _prePackGroupCode = value;
            }
        }

        // Used by New Balance
        // Unique 12 position internal pre-pack number (JBA - NMAP010), customer ppk# on order is 20 long and will be bridged down in PDMIS1.  If not a prepack then this is blanks.
        private string _assortmentNumber;
        [FixedLengthField(63, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string AssortmentNumber
        {
            get { return _assortmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _assortmentNumber = value;
            }
        }

        // Used by New Balance
        // Pre pack units (JBA - NMAP010).  If not a prepack then this is 0.
        private long _numberUnitsInPpacks;
        [FixedLengthField(64, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long NumberUnitsInPpacks_Backing
        {
            get { return _numberUnitsInPpacks; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _numberUnitsInPpacks = value;
            }
        }
        public decimal NumberUnitsInPpacks
        {
            get { return NumberUnitsInPpacks_Backing / 10000.0m; }
            set { NumberUnitsInPpacks_Backing = (int)(value * 10000.0m); }
        }

        private int _shelfDays;
        [FixedLengthField(65, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int ShelfDays
        {
            get { return _shelfDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _shelfDays = value;
            }
        }

        private string _printPriceTicketWithWave;
        [FixedLengthField(66, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PrintPriceTicketWithWave
        {
            get { return _printPriceTicketWithWave; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _printPriceTicketWithWave = value;
            }
        }

        private string _priceTicketType;
        [FixedLengthField(67, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PriceTicketType
        {
            get { return _priceTicketType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _priceTicketType = value;
            }
        }

        private string _palletType;
        [FixedLengthField(68, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PalletType
        {
            get { return _palletType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _palletType = value;
            }
        }

        private string _cartonType;
        [FixedLengthField(69, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CartonType
        {
            get { return _cartonType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonType = value;
            }
        }

        private string _crtnBrkAttribute;
        [FixedLengthField(70, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CrtnBrkAttribute
        {
            get { return _crtnBrkAttribute; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _crtnBrkAttribute = value;
            }
        }

        private int _criticalDimension1;
        [FixedLengthField(71, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CriticalDimension1_Backing
        {
            get { return _criticalDimension1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _criticalDimension1 = value;
            }
        }
        public decimal CriticalDimension1
        {
            get { return CriticalDimension1_Backing / 100.0m; }
            set { CriticalDimension1_Backing = (int)(value * 100.0m); }
        }

        private int _criticalDimension2;
        [FixedLengthField(72, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CriticalDimension2_Backing
        {
            get { return _criticalDimension2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _criticalDimension2 = value;
            }
        }
        public decimal CriticalDimension2
        {
            get { return CriticalDimension2_Backing / 100.0m; }
            set { CriticalDimension2_Backing = (int)(value * 100.0m); }
        }

        private int _criticalDimension3;
        [FixedLengthField(73, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CriticalDimension3_Backing
        {
            get { return _criticalDimension3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _criticalDimension3 = value;
            }
        }
        public decimal CriticalDimension3
        {
            get { return CriticalDimension3_Backing / 100.0m; }
            set { CriticalDimension3_Backing = (int)(value * 100.0m); }
        }

        private long _stdCaseWeight;
        [FixedLengthField(74, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long StdCaseWeight_Backing
        {
            get { return _stdCaseWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _stdCaseWeight = value;
            }
        }
        public decimal StdCaseWeight
        {
            get { return StdCaseWeight_Backing / 100000.0m; }
            set { StdCaseWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _stdCaseVolume;
        [FixedLengthField(75, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long StdCaseVolume_Backing
        {
            get { return _stdCaseVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _stdCaseVolume = value;
            }
        }
        public decimal StdCaseVolume
        {
            get { return StdCaseVolume_Backing / 100000.0m; }
            set { StdCaseVolume_Backing = (int)(value * 100000.0m); }
        }

        private string _vasStatus;
        [FixedLengthField(76, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string VasStatus
        {
            get { return _vasStatus; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _vasStatus = value;
            }
        }

        private string _vasType;
        [FixedLengthField(77, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string VasType
        {
            get { return _vasType; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _vasType = value;
            }
        }

        private string _vasGroup;
        [FixedLengthField(78, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string VasGroup
        {
            get { return _vasGroup; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _vasGroup = value;
            }
        }

        private string _catchWeight;
        [FixedLengthField(79, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string CatchWeight
        {
            get { return _catchWeight; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _catchWeight = value;
            }
        }

        private string _unitOfMeasure;
        [FixedLengthField(80, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _unitOfMeasure = value;
            }
        }

        // Used by New Balance
        // Always 0
        private string _preCubeFlag;
        [FixedLengthField(81, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PreCubeFlag
        {
            get { return _preCubeFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _preCubeFlag = value;
            }
        }

        private string _isbnNumber;
        [FixedLengthField(82, 13, PaddingChar = ' ', Padding = Padding.Right, NullValue="             ")]
        public string IsbnNumber
        {
            get { return _isbnNumber; }
            set
            {
                if(value != default(string) && value.Length > 13) throw new ArgumentOutOfRangeException("value");
                _isbnNumber = value;
            }
        }

        // Used by New Balance
        // Either from NB Database (NOEP003) Customer Cross Reference, RPRC03 or if the customer number exists in NMAP050 table ORDP.  Prints on Packing List.
        private long _price;
        [FixedLengthField(83, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long Price_Backing
        {
            get { return _price; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _price = value;
            }
        }
        public decimal Price
        {
            get { return Price_Backing / 10000.0m; }
            set { Price_Backing = (int)(value * 10000.0m); }
        }

        // unit price our customer is paying - needed for comm invoice
        private long _retailPrice;
        [FixedLengthField(84, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long RetailPrice_Backing
        {
            get { return _retailPrice; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _retailPrice = value;
            }
        }
        public decimal RetailPrice
        {
            get { return RetailPrice_Backing / 10000.0m; }
            set { RetailPrice_Backing = (int)(value * 10000.0m); }
        }

        private long _discountDollars;
        [FixedLengthField(85, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long DiscountDollars_Backing
        {
            get { return _discountDollars; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _discountDollars = value;
            }
        }
        public decimal DiscountDollars
        {
            get { return DiscountDollars_Backing / 10000.0m; }
            set { DiscountDollars_Backing = (int)(value * 10000.0m); }
        }

        private string _taxable;
        [FixedLengthField(86, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Taxable
        {
            get { return _taxable; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _taxable = value;
            }
        }

        private int _taxPercentage;
        [FixedLengthField(87, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int TaxPercentage_Backing
        {
            get { return _taxPercentage; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _taxPercentage = value;
            }
        }
        public decimal TaxPercentage
        {
            get { return TaxPercentage_Backing / 100.0m; }
            set { TaxPercentage_Backing = (int)(value * 100.0m); }
        }

        private string _suppressPrintAmounts;
        [FixedLengthField(88, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SuppressPrintAmounts
        {
            get { return _suppressPrintAmounts; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _suppressPrintAmounts = value;
            }
        }

        private string _messageId;
        [FixedLengthField(89, 7, PaddingChar = ' ', Padding = Padding.Right, NullValue="       ")]
        public string MessageId
        {
            get { return _messageId; }
            set
            {
                if(value != default(string) && value.Length > 7) throw new ArgumentOutOfRangeException("value");
                _messageId = value;
            }
        }

        private string _customTag;
        [FixedLengthField(90, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string CustomTag
        {
            get { return _customTag; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _customTag = value;
            }
        }

        private string _tarrifClass;
        [FixedLengthField(91, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TarrifClass
        {
            get { return _tarrifClass; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _tarrifClass = value;
            }
        }

        private string _packAreaCode;
        [FixedLengthField(92, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PackAreaCode
        {
            get { return _packAreaCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _packAreaCode = value;
            }
        }

        private int _pickRate;
        [FixedLengthField(93, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int PickRate_Backing
        {
            get { return _pickRate; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _pickRate = value;
            }
        }
        public decimal PickRate
        {
            get { return PickRate_Backing / 10000.0m; }
            set { PickRate_Backing = (int)(value * 10000.0m); }
        }

        private int _packRate;
        [FixedLengthField(94, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int PackRate_Backing
        {
            get { return _packRate; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _packRate = value;
            }
        }
        public decimal PackRate
        {
            get { return PackRate_Backing / 10000.0m; }
            set { PackRate_Backing = (int)(value * 10000.0m); }
        }

        private int _overSizeLength;
        [FixedLengthField(95, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int OverSizeLength
        {
            get { return _overSizeLength; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _overSizeLength = value;
            }
        }

        private string _i2of5PackQuantityReference;
        [FixedLengthField(96, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2of5PackQuantityReference
        {
            get { return _i2of5PackQuantityReference; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2of5PackQuantityReference = value;
            }
        }

        private string _i2of5CaseQuantityReference;
        [FixedLengthField(97, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2of5CaseQuantityReference
        {
            get { return _i2of5CaseQuantityReference; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2of5CaseQuantityReference = value;
            }
        }

        private string _i2of5TierQuantityReference;
        [FixedLengthField(98, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2of5TierQuantityReference
        {
            get { return _i2of5TierQuantityReference; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2of5TierQuantityReference = value;
            }
        }

        private int _ruleNumber;
        [FixedLengthField(99, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int RuleNumber_Backing
        {
            get { return _ruleNumber; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _ruleNumber = value;
            }
        }
        public decimal RuleNumber
        {
            get { return RuleNumber_Backing / 100.0m; }
            set { RuleNumber_Backing = (int)(value * 100.0m); }
        }

        // Used by New Balance
        // If DOB this is "D" else its blanks.
        private string _inventoryAllocationType;
        [FixedLengthField(100, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InventoryAllocationType
        {
            get { return _inventoryAllocationType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _inventoryAllocationType = value;
            }
        }

        private string _workType;
        [FixedLengthField(101, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string WorkType
        {
            get { return _workType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _workType = value;
            }
        }

        private string _packZone;
        [FixedLengthField(102, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PackZone
        {
            get { return _packZone; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _packZone = value;
            }
        }

        private string _serialNumberReq;
        [FixedLengthField(103, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SerialNumberReq
        {
            get { return _serialNumberReq; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _serialNumberReq = value;
            }
        }

        private string _protectionFactor;
        [FixedLengthField(104, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProtectionFactor
        {
            get { return _protectionFactor; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _protectionFactor = value;
            }
        }

        private string _sku100Inventory;
        [FixedLengthField(105, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Sku100Inventory
        {
            get { return _sku100Inventory; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _sku100Inventory = value;
            }
        }

        private string _chuteAssignmentType;
        [FixedLengthField(106, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ChuteAssignmentType
        {
            get { return _chuteAssignmentType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _chuteAssignmentType = value;
            }
        }

        private string _specialInstructionCode1;
        [FixedLengthField(107, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode1
        {
            get { return _specialInstructionCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode1 = value;
            }
        }

        private string _specialInstructionCode2;
        [FixedLengthField(108, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode2
        {
            get { return _specialInstructionCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode2 = value;
            }
        }

        private string _specialInstructionCode3;
        [FixedLengthField(109, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode3
        {
            get { return _specialInstructionCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode3 = value;
            }
        }

        private string _specialInstructionCode4;
        [FixedLengthField(110, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode4
        {
            get { return _specialInstructionCode4; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode4 = value;
            }
        }

        private string _specialInstructionCode5;
        [FixedLengthField(111, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode5
        {
            get { return _specialInstructionCode5; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode5 = value;
            }
        }

        // Used by New Balance
        // If a prepack, the NB/Customer prepack #.  If not a prepack then blanks.
        private string _miscellaneousField1;
        [FixedLengthField(112, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField1
        {
            get { return _miscellaneousField1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField1 = value;
            }
        }

        // Used by New Balance
        // Width description (for grid label).  Either from NB Database NOEP003 Customer Cross Reference, RWDS03 or NB Width Desc in UPC file.
        private string _miscellaneousField2;
        [FixedLengthField(113, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField2
        {
            get { return _miscellaneousField2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField2 = value;
            }
        }

        // Used by New Balance
        // For labelling, NB Database NOEP003 Customer Cross Reference, Misc description #2, RMD203.
        private string _miscellaneousField3;
        [FixedLengthField(114, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField3
        {
            get { return _miscellaneousField3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField3 = value;
            }
        }

        private long _miscellaneousNum1;
        [FixedLengthField(115, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum1_Backing
        {
            get { return _miscellaneousNum1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum1 = value;
            }
        }
        public decimal MiscellaneousNum1
        {
            get { return MiscellaneousNum1_Backing / 100000.0m; }
            set { MiscellaneousNum1_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum2;
        [FixedLengthField(116, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum2_Backing
        {
            get { return _miscellaneousNum2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum2 = value;
            }
        }
        public decimal MiscellaneousNum2
        {
            get { return MiscellaneousNum2_Backing / 100000.0m; }
            set { MiscellaneousNum2_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum3;
        [FixedLengthField(117, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum3_Backing
        {
            get { return _miscellaneousNum3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum3 = value;
            }
        }
        public decimal MiscellaneousNum3
        {
            get { return MiscellaneousNum3_Backing / 100000.0m; }
            set { MiscellaneousNum3_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum4;
        [FixedLengthField(118, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum4_Backing
        {
            get { return _miscellaneousNum4; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum4 = value;
            }
        }
        public decimal MiscellaneousNum4
        {
            get { return MiscellaneousNum4_Backing / 100000.0m; }
            set { MiscellaneousNum4_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum5;
        [FixedLengthField(119, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum5_Backing
        {
            get { return _miscellaneousNum5; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum5 = value;
            }
        }
        public decimal MiscellaneousNum5
        {
            get { return MiscellaneousNum5_Backing / 100000.0m; }
            set { MiscellaneousNum5_Backing = (int)(value * 100000.0m); }
        }

        // Used by New Balance
        // Always N
        private string _recordExpansionField;
        [FixedLengthField(120, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        // Used by New Balance
        // Pack List Info or Style Description.  Either from NB Database NOEP003 Customer Cross Reference, PKLS03 or JBA Parts file (First 17 of Part desc).  For packing list?
        private string _customRecordExpansionField;
        [FixedLengthField(121, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _nmfcCode;
        [FixedLengthField(122, 9, PaddingChar = ' ', Padding = Padding.Right, NullValue="         ")]
        public string NmfcCode
        {
            get { return _nmfcCode; }
            set
            {
                if(value != default(string) && value.Length > 9) throw new ArgumentOutOfRangeException("value");
                _nmfcCode = value;
            }
        }

        private string _itemVersSub;
        [FixedLengthField(123, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ItemVersSub
        {
            get { return _itemVersSub; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _itemVersSub = value;
            }
        }

        private string _lotReqType;
        [FixedLengthField(124, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string LotReqType
        {
            get { return _lotReqType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _lotReqType = value;
            }
        }

        private string _drpProcType;
        [FixedLengthField(125, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DrpProcType
        {
            get { return _drpProcType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _drpProcType = value;
            }
        }

        private string _crushabilityCode;
        [FixedLengthField(126, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CrushabilityCode
        {
            get { return _crushabilityCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _crushabilityCode = value;
            }
        }

        private string _eventCode;
        [FixedLengthField(127, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string EventCode
        {
            get { return _eventCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _eventCode = value;
            }
        }

        private string _innerCtnItem;
        [FixedLengthField(128, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string InnerCtnItem
        {
            get { return _innerCtnItem; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _innerCtnItem = value;
            }
        }

        private string _innerCtnType;
        [FixedLengthField(129, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InnerCtnType
        {
            get { return _innerCtnType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _innerCtnType = value;
            }
        }

        private string _innerCtnBreakAttribute;
        [FixedLengthField(130, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InnerCtnBreakAttribute
        {
            get { return _innerCtnBreakAttribute; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _innerCtnBreakAttribute = value;
            }
        }

        private string _tpePurchaseOrder;
        [FixedLengthField(131, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue="                         ")]
        public string TpePurchaseOrder
        {
            get { return _tpePurchaseOrder; }
            set
            {
                if(value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _tpePurchaseOrder = value;
            }
        }

        private string _tpeTranspOrdNumber;
        [FixedLengthField(132, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string TpeTranspOrdNumber
        {
            get { return _tpeTranspOrdNumber; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _tpeTranspOrdNumber = value;
            }
        }

        private string _miscellaneousField4;
        [FixedLengthField(133, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField4
        {
            get { return _miscellaneousField4; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField4 = value;
            }
        }

        private string _miscellaneousField5;
        [FixedLengthField(134, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField5
        {
            get { return _miscellaneousField5; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField5 = value;
            }
        }

        private string _miscellaneousField6;
        [FixedLengthField(135, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField6
        {
            get { return _miscellaneousField6; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField6 = value;
            }
        }

        private string _miscellaneousField7;
        [FixedLengthField(136, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField7
        {
            get { return _miscellaneousField7; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField7 = value;
            }
        }

        private string _miscellaneousField8;
        [FixedLengthField(137, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField8
        {
            get { return _miscellaneousField8; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField8 = value;
            }
        }

        private string _miscellaneousField9;
        [FixedLengthField(138, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField9
        {
            get { return _miscellaneousField9; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField9 = value;
            }
        }

        private string _miscellaneousField10;
        [FixedLengthField(139, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField10
        {
            get { return _miscellaneousField10; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField10 = value;
            }
        }

        private string _miscellaneousIns5Byte1;
        [FixedLengthField(140, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte1
        {
            get { return _miscellaneousIns5Byte1; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte1 = value;
            }
        }

        private string _miscellaneousIns5Byte2;
        [FixedLengthField(141, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte2
        {
            get { return _miscellaneousIns5Byte2; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte2 = value;
            }
        }

        private string _miscellaneousIns5Byte3;
        [FixedLengthField(142, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte3
        {
            get { return _miscellaneousIns5Byte3; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte3 = value;
            }
        }

        private string _miscellaneousIns5Byte4;
        [FixedLengthField(143, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte4
        {
            get { return _miscellaneousIns5Byte4; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte4 = value;
            }
        }

        private string _miscellaneousIns10Byte1;
        [FixedLengthField(144, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte1
        {
            get { return _miscellaneousIns10Byte1; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte1 = value;
            }
        }

        private string _miscellaneousIns10Byte2;
        [FixedLengthField(145, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte2
        {
            get { return _miscellaneousIns10Byte2; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte2 = value;
            }
        }

        private string _miscellaneousIns10Byte3;
        [FixedLengthField(146, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte3
        {
            get { return _miscellaneousIns10Byte3; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte3 = value;
            }
        }

        private string _miscellaneousIns10Byte4;
        [FixedLengthField(147, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte4
        {
            get { return _miscellaneousIns10Byte4; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte4 = value;
            }
        }

        private string _miscellaneousIns20Byte11;
        [FixedLengthField(148, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte11
        {
            get { return _miscellaneousIns20Byte11; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte11 = value;
            }
        }

        private string _miscellaneousIns20Byte12;
        [FixedLengthField(149, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte12
        {
            get { return _miscellaneousIns20Byte12; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte12 = value;
            }
        }

        private string _miscellaneousIns20Byte13;
        [FixedLengthField(150, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte13
        {
            get { return _miscellaneousIns20Byte13; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte13 = value;
            }
        }

        private string _miscellaneousIns20Byte14;
        [FixedLengthField(151, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte14
        {
            get { return _miscellaneousIns20Byte14; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte14 = value;
            }
        }

        private long _miscellaneousNumber6;
        [FixedLengthField(152, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber6_Backing
        {
            get { return _miscellaneousNumber6; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber6 = value;
            }
        }
        public decimal MiscellaneousNumber6
        {
            get { return MiscellaneousNumber6_Backing / 100000.0m; }
            set { MiscellaneousNumber6_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber7;
        [FixedLengthField(153, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber7_Backing
        {
            get { return _miscellaneousNumber7; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber7 = value;
            }
        }
        public decimal MiscellaneousNumber7
        {
            get { return MiscellaneousNumber7_Backing / 100000.0m; }
            set { MiscellaneousNumber7_Backing = (int)(value * 100000.0m); }
        }

        // Used by New Balance
        // Price Carbella's customers are paying, prints on carbellas packlist.
        private long _miscellaneousNumber8;
        [FixedLengthField(154, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber8_Backing
        {
            get { return _miscellaneousNumber8; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber8 = value;
            }
        }
        public decimal MiscellaneousNumber8
        {
            get { return MiscellaneousNumber8_Backing / 100000.0m; }
            set { MiscellaneousNumber8_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber9;
        [FixedLengthField(155, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber9_Backing
        {
            get { return _miscellaneousNumber9; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber9 = value;
            }
        }
        public decimal MiscellaneousNumber9
        {
            get { return MiscellaneousNumber9_Backing / 100000.0m; }
            set { MiscellaneousNumber9_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber10;
        [FixedLengthField(156, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber10_Backing
        {
            get { return _miscellaneousNumber10; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber10 = value;
            }
        }
        public decimal MiscellaneousNumber10
        {
            get { return MiscellaneousNumber10_Backing / 100000.0m; }
            set { MiscellaneousNumber10_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber11;
        [FixedLengthField(157, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber11_Backing
        {
            get { return _miscellaneousNumber11; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber11 = value;
            }
        }
        public decimal MiscellaneousNumber11
        {
            get { return MiscellaneousNumber11_Backing / 100000.0m; }
            set { MiscellaneousNumber11_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumber12;
        [FixedLengthField(158, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumber12_Backing
        {
            get { return _miscellaneousNumber12; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumber12 = value;
            }
        }
        public decimal MiscellaneousNumber12
        {
            get { return MiscellaneousNumber12_Backing / 100000.0m; }
            set { MiscellaneousNumber12_Backing = (int)(value * 100000.0m); }
        }

        private string _cartonEpcType;
        [FixedLengthField(159, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CartonEpcType
        {
            get { return _cartonEpcType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _cartonEpcType = value;
            }
        }

        private string _palletEpcType;
        [FixedLengthField(160, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PalletEpcType
        {
            get { return _palletEpcType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _palletEpcType = value;
            }
        }

        private string _garmentsOnHangerFlag;
        [FixedLengthField(161, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string GarmentsOnHangerFlag
        {
            get { return _garmentsOnHangerFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _garmentsOnHangerFlag = value;
            }
        }

        private string _allocateIncubateCase;
        [FixedLengthField(162, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllocateIncubateCase
        {
            get { return _allocateIncubateCase; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allocateIncubateCase = value;
            }
        }

        private string _exportIdentificationCode;
        [FixedLengthField(163, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ExportIdentificationCode
        {
            get { return _exportIdentificationCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _exportIdentificationCode = value;
            }
        }

        private string _marksAndNumbers;
        [FixedLengthField(164, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string MarksAndNumbers
        {
            get { return _marksAndNumbers; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _marksAndNumbers = value;
            }
        }

        private string _allocationMethod;
        [FixedLengthField(165, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllocationMethod
        {
            get { return _allocationMethod; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allocationMethod = value;
            }
        }

        private int _exceedForFullCaseAlloc;
        [FixedLengthField(166, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int ExceedForFullCaseAlloc_Backing
        {
            get { return _exceedForFullCaseAlloc; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _exceedForFullCaseAlloc = value;
            }
        }
        public decimal ExceedForFullCaseAlloc
        {
            get { return ExceedForFullCaseAlloc_Backing / 100.0m; }
            set { ExceedForFullCaseAlloc_Backing = (int)(value * 100.0m); }
        }

        private int _purchaseOrderLine;
        [FixedLengthField(167, 6, PaddingChar = '0', Padding = Padding.Left, NullValue="000000")]
        public int PurchaseOrderLine
        {
            get { return _purchaseOrderLine; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 6) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderLine = value;
            }
        }

        private string _singlestopPallet;
        [FixedLengthField(168, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SinglestopPallet
        {
            get { return _singlestopPallet; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _singlestopPallet = value;
            }
        }

        private int _customerMaxPalletCube;
        [FixedLengthField(169, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int CustomerMaxPalletCube_Backing
        {
            get { return _customerMaxPalletCube; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _customerMaxPalletCube = value;
            }
        }
        public decimal CustomerMaxPalletCube
        {
            get { return CustomerMaxPalletCube_Backing / 100.0m; }
            set { CustomerMaxPalletCube_Backing = (int)(value * 100.0m); }
        }

        private long _bundleQuantity;
        [FixedLengthField(170, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long BundleQuantity_Backing
        {
            get { return _bundleQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _bundleQuantity = value;
            }
        }
        public decimal BundleQuantity
        {
            get { return BundleQuantity_Backing / 10000.0m; }
            set { BundleQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _maximumDispenseQuantity;
        [FixedLengthField(171, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long MaximumDispenseQuantity_Backing
        {
            get { return _maximumDispenseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _maximumDispenseQuantity = value;
            }
        }
        public decimal MaximumDispenseQuantity
        {
            get { return MaximumDispenseQuantity_Backing / 10000.0m; }
            set { MaximumDispenseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _preticketed;
        [FixedLengthField(172, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Preticketed
        {
            get { return _preticketed; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _preticketed = value;
            }
        }

public int TotalFileLength { get { return 1551; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
