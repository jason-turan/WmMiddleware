using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.ProductUpdating.Models
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class ManhattanProduct
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

        // Used by New Balance
        // Unique transaction batch control number (prefix is the warehouse number)
        private string _batchControlNumber;
        [FixedLengthField(4, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // create date
        private int _dateCreated;
        [FixedLengthField(5, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
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
        // create time
        private int _timeCreated;
        [FixedLengthField(6, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
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
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // Company code
        private string _company;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // Warehouse "22" Lawrence, "33" Ontario
        private string _division;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(10, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(11, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(12, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(13, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(14, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(15, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(16, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        [FixedLengthField(17, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(18, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SizeRangeCode
        {
            get { return _sizeRangeCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _sizeRangeCode = value;
            }
        }

        private int _sizeRelPosninTable;
        [FixedLengthField(19, 2, PaddingChar = '0', Padding = Padding.Left, NullValue="00")]
        public int SizeRelPosninTable
        {
            get { return _sizeRelPosninTable; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _sizeRelPosninTable = value;
            }
        }

        private int _sequenceNumber;
        [FixedLengthField(20, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _sequenceNumber = value;
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

        private string _skuProfileId;
        [FixedLengthField(22, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string SkuProfileId
        {
            get { return _skuProfileId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _skuProfileId = value;
            }
        }

        private string _pickLocnAssignmentType;
        [FixedLengthField(23, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickLocnAssignmentType
        {
            get { return _pickLocnAssignmentType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickLocnAssignmentType = value;
            }
        }

        // Used by New Balance
        // Demos = "IRR", Non Shoes = "POP", all others "DFT"
        private string _pickDeterminationType;
        [FixedLengthField(24, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickDeterminationType
        {
            get { return _pickDeterminationType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickDeterminationType = value;
            }
        }

        private string _waveProcessingType;
        [FixedLengthField(25, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string WaveProcessingType
        {
            get { return _waveProcessingType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _waveProcessingType = value;
            }
        }

        private int _coordinate1;
        [FixedLengthField(26, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int Coordinate1
        {
            get { return _coordinate1; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _coordinate1 = value;
            }
        }

        private int _coordinate2;
        [FixedLengthField(27, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int Coordinate2
        {
            get { return _coordinate2; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _coordinate2 = value;
            }
        }

        private string _replenishmentZone;
        [FixedLengthField(28, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReplenishmentZone
        {
            get { return _replenishmentZone; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _replenishmentZone = value;
            }
        }

        private string _replenishmentLocn;
        [FixedLengthField(29, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ReplenishmentLocn
        {
            get { return _replenishmentLocn; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _replenishmentLocn = value;
            }
        }

        private string _volatilityCode;
        [FixedLengthField(30, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string VolatilityCode
        {
            get { return _volatilityCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _volatilityCode = value;
            }
        }

        private string _suggestedZone;
        [FixedLengthField(31, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SuggestedZone
        {
            get { return _suggestedZone; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _suggestedZone = value;
            }
        }

        private string _packageType;
        [FixedLengthField(32, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PackageType
        {
            get { return _packageType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _packageType = value;
            }
        }

        private string _actInvCountFrequency;
        [FixedLengthField(33, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ActInvCountFrequency
        {
            get { return _actInvCountFrequency; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _actInvCountFrequency = value;
            }
        }

        private string _productGroup;
        [FixedLengthField(34, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductGroup
        {
            get { return _productGroup; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productGroup = value;
            }
        }

        // Used by New Balance
        // Brand Code
        private string _productSubgroup;
        [FixedLengthField(35, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductSubgroup
        {
            get { return _productSubgroup; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productSubgroup = value;
            }
        }

        // Used by New Balance
        // Product Type Code: F = finished goods, R = Raw Materials
        private string _productType;
        [FixedLengthField(36, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductType
        {
            get { return _productType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productType = value;
            }
        }

        // Used by New Balance
        // Product Line Code
        private string _productLine;
        [FixedLengthField(37, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductLine
        {
            get { return _productLine; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productLine = value;
            }
        }

        private string _salesGroup;
        [FixedLengthField(38, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string SalesGroup
        {
            get { return _salesGroup; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _salesGroup = value;
            }
        }

        private string _protectionFactor;
        [FixedLengthField(39, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProtectionFactor
        {
            get { return _protectionFactor; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _protectionFactor = value;
            }
        }

        private int _shelfDays;
        [FixedLengthField(40, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int ShelfDays
        {
            get { return _shelfDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _shelfDays = value;
            }
        }

        private string _shipAlone;
        [FixedLengthField(41, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShipAlone
        {
            get { return _shipAlone; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipAlone = value;
            }
        }

        private string _unitofMeasure;
        [FixedLengthField(42, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string UnitofMeasure
        {
            get { return _unitofMeasure; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _unitofMeasure = value;
            }
        }

        private string _stockingUm;
        [FixedLengthField(43, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string StockingUm
        {
            get { return _stockingUm; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _stockingUm = value;
            }
        }

        private string _purchasingUm;
        [FixedLengthField(44, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PurchasingUm
        {
            get { return _purchasingUm; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _purchasingUm = value;
            }
        }

        private string _sellingUm;
        [FixedLengthField(45, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string SellingUm
        {
            get { return _sellingUm; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _sellingUm = value;
            }
        }

        // Used by New Balance
        // Style Description
        private string _styleDescription;
        [FixedLengthField(46, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
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
        [FixedLengthField(47, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
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
        // UPC# if one exists other wise concatenate style/width/size no spaces between
        private string _packageBarcode;
        [FixedLengthField(48, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PackageBarcode
        {
            get { return _packageBarcode; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _packageBarcode = value;
            }
        }

        private string _cartonType;
        [FixedLengthField(49, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CartonType
        {
            get { return _cartonType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonType = value;
            }
        }

        private string _palletType;
        [FixedLengthField(50, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PalletType
        {
            get { return _palletType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _palletType = value;
            }
        }

        private string _cartonBreakAttribute;
        [FixedLengthField(51, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CartonBreakAttribute
        {
            get { return _cartonBreakAttribute; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonBreakAttribute = value;
            }
        }

        // Used by New Balance
        // Inventory standard cost
        private long _price;
        [FixedLengthField(52, 19, PaddingChar = '0', Padding = Padding.Left)]
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

        private long _retailPrice;
        [FixedLengthField(53, 19, PaddingChar = '0', Padding = Padding.Left)]
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

        private string _operationCode;
        [FixedLengthField(54, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string OperationCode
        {
            get { return _operationCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _operationCode = value;
            }
        }

        private long _innerPackQuantity;
        [FixedLengthField(55, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long InnerPackQuantity_Backing
        {
            get { return _innerPackQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _innerPackQuantity = value;
            }
        }
        public decimal InnerPackQuantity
        {
            get { return InnerPackQuantity_Backing / 10000.0m; }
            set { InnerPackQuantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Always "1"
        private long _boxQuantity;
        [FixedLengthField(56, 11, PaddingChar = '0', Padding = Padding.Left)]
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

        // Used by New Balance
        // Dunham Shoes = 6, Other Shoes = 12, all others = 1
        private long _standardCaseQuantity;
        [FixedLengthField(57, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long StandardCaseQuantity_Backing
        {
            get { return _standardCaseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _standardCaseQuantity = value;
            }
        }
        public decimal StandardCaseQuantity
        {
            get { return StandardCaseQuantity_Backing / 10000.0m; }
            set { StandardCaseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _maximumCaseQuantity;
        [FixedLengthField(58, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long MaximumCaseQuantity_Backing
        {
            get { return _maximumCaseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _maximumCaseQuantity = value;
            }
        }
        public decimal MaximumCaseQuantity
        {
            get { return MaximumCaseQuantity_Backing / 10000.0m; }
            set { MaximumCaseQuantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Non shoes = .01
        private int _standardCaseLength;
        [FixedLengthField(59, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StandardCaseLength_Backing
        {
            get { return _standardCaseLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _standardCaseLength = value;
            }
        }
        public decimal StandardCaseLength
        {
            get { return StandardCaseLength_Backing / 100.0m; }
            set { StandardCaseLength_Backing = (int)(value * 100.0m); }
        }

        // Used by New Balance
        // Non shoes = .01
        private int _standardCaseWidth;
        [FixedLengthField(60, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StandardCaseWidth_Backing
        {
            get { return _standardCaseWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _standardCaseWidth = value;
            }
        }
        public decimal StandardCaseWidth
        {
            get { return StandardCaseWidth_Backing / 100.0m; }
            set { StandardCaseWidth_Backing = (int)(value * 100.0m); }
        }

        // Used by New Balance
        // Non shoes = .01
        private int _standardCaseHeight;
        [FixedLengthField(61, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StandardCaseHeight_Backing
        {
            get { return _standardCaseHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _standardCaseHeight = value;
            }
        }
        public decimal StandardCaseHeight
        {
            get { return StandardCaseHeight_Backing / 100.0m; }
            set { StandardCaseHeight_Backing = (int)(value * 100.0m); }
        }

        private int _stdPalletLength;
        [FixedLengthField(62, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StdPalletLength_Backing
        {
            get { return _stdPalletLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _stdPalletLength = value;
            }
        }
        public decimal StdPalletLength
        {
            get { return StdPalletLength_Backing / 100.0m; }
            set { StdPalletLength_Backing = (int)(value * 100.0m); }
        }

        private int _stdPalletWidth;
        [FixedLengthField(63, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StdPalletWidth_Backing
        {
            get { return _stdPalletWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _stdPalletWidth = value;
            }
        }
        public decimal StdPalletWidth
        {
            get { return StdPalletWidth_Backing / 100.0m; }
            set { StdPalletWidth_Backing = (int)(value * 100.0m); }
        }

        private int _stdPalletHeight;
        [FixedLengthField(64, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StdPalletHeight_Backing
        {
            get { return _stdPalletHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _stdPalletHeight = value;
            }
        }
        public decimal StdPalletHeight
        {
            get { return StdPalletHeight_Backing / 100.0m; }
            set { StdPalletHeight_Backing = (int)(value * 100.0m); }
        }

        private int _maxCasesStacked;
        [FixedLengthField(65, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int MaxCasesStacked
        {
            get { return _maxCasesStacked; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _maxCasesStacked = value;
            }
        }

        private int _maxPalletsStacked;
        [FixedLengthField(66, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int MaxPalletsStacked
        {
            get { return _maxPalletsStacked; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _maxPalletsStacked = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _lenWidthSensitive;
        [FixedLengthField(67, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string LenWidthSensitive
        {
            get { return _lenWidthSensitive; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _lenWidthSensitive = value;
            }
        }

        private long _tierQuantity;
        [FixedLengthField(68, 11, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(69, 11, PaddingChar = '0', Padding = Padding.Left)]
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

        private long _packMultipleQuantity;
        [FixedLengthField(70, 11, PaddingChar = '0', Padding = Padding.Left)]
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
        // Non shoes = .01
        private long _unitWeight;
        [FixedLengthField(71, 13, PaddingChar = '0', Padding = Padding.Left)]
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

        // Used by New Balance
        // Non shoes = .000001
        private long _unitVolume;
        [FixedLengthField(72, 13, PaddingChar = '0', Padding = Padding.Left)]
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

        private long _innerPackWeight;
        [FixedLengthField(73, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long InnerPackWeight_Backing
        {
            get { return _innerPackWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _innerPackWeight = value;
            }
        }
        public decimal InnerPackWeight
        {
            get { return InnerPackWeight_Backing / 100000.0m; }
            set { InnerPackWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _innerPackVolume;
        [FixedLengthField(74, 13, PaddingChar = '0', Padding = Padding.Left)]
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

        // Used by New Balance
        // Non shoes = .01
        private long _standardCaseWeight;
        [FixedLengthField(75, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long StandardCaseWeight_Backing
        {
            get { return _standardCaseWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _standardCaseWeight = value;
            }
        }
        public decimal StandardCaseWeight
        {
            get { return StandardCaseWeight_Backing / 100000.0m; }
            set { StandardCaseWeight_Backing = (int)(value * 100000.0m); }
        }

        // Used by New Balance
        // Non shoes = .01
        private long _standardCaseVolume;
        [FixedLengthField(76, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long StandardCaseVolume_Backing
        {
            get { return _standardCaseVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _standardCaseVolume = value;
            }
        }
        public decimal StandardCaseVolume
        {
            get { return StandardCaseVolume_Backing / 100000.0m; }
            set { StandardCaseVolume_Backing = (int)(value * 100000.0m); }
        }

        private int _cartonsTiers;
        [FixedLengthField(77, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int CartonsTiers
        {
            get { return _cartonsTiers; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _cartonsTiers = value;
            }
        }

        private int _tierPerPallet;
        [FixedLengthField(78, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int TierPerPallet
        {
            get { return _tierPerPallet; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _tierPerPallet = value;
            }
        }

        private string _i2of5PackQuantityReference;
        [FixedLengthField(79, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(80, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(81, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2of5TierQuantityReference
        {
            get { return _i2of5TierQuantityReference; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2of5TierQuantityReference = value;
            }
        }

        private string _caseSizeType;
        [FixedLengthField(82, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CaseSizeType
        {
            get { return _caseSizeType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _caseSizeType = value;
            }
        }

        private string _conveyable;
        [FixedLengthField(83, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Conveyable
        {
            get { return _conveyable; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _conveyable = value;
            }
        }

        private int _qualityAuditPercentage;
        [FixedLengthField(84, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int QualityAuditPercentage_Backing
        {
            get { return _qualityAuditPercentage; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _qualityAuditPercentage = value;
            }
        }
        public decimal QualityAuditPercentage
        {
            get { return QualityAuditPercentage_Backing / 100.0m; }
            set { QualityAuditPercentage_Backing = (int)(value * 100.0m); }
        }

        private string _activePickSite;
        [FixedLengthField(85, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ActivePickSite
        {
            get { return _activePickSite; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _activePickSite = value;
            }
        }

        // Used by New Balance
        // Demos = "I", others blanks
        private string _unitPutawayType;
        [FixedLengthField(86, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string UnitPutawayType
        {
            get { return _unitPutawayType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _unitPutawayType = value;
            }
        }

        private string _casePutawayType;
        [FixedLengthField(87, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CasePutawayType
        {
            get { return _casePutawayType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _casePutawayType = value;
            }
        }

        private string _palletPutawayType;
        [FixedLengthField(88, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PalletPutawayType
        {
            get { return _palletPutawayType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _palletPutawayType = value;
            }
        }

        private long _maxUnitsReserveLocn;
        [FixedLengthField(89, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MaxUnitsReserveLocn_Backing
        {
            get { return _maxUnitsReserveLocn; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _maxUnitsReserveLocn = value;
            }
        }
        public decimal MaxUnitsReserveLocn
        {
            get { return MaxUnitsReserveLocn_Backing / 10000.0m; }
            set { MaxUnitsReserveLocn_Backing = (int)(value * 10000.0m); }
        }

        private long _maxInventoryforActive;
        [FixedLengthField(90, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MaxInventoryforActive_Backing
        {
            get { return _maxInventoryforActive; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _maxInventoryforActive = value;
            }
        }
        public decimal MaxInventoryforActive
        {
            get { return MaxInventoryforActive_Backing / 10000.0m; }
            set { MaxInventoryforActive_Backing = (int)(value * 10000.0m); }
        }

        private long _minInventoryforActive;
        [FixedLengthField(91, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MinInventoryforActive_Backing
        {
            get { return _minInventoryforActive; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _minInventoryforActive = value;
            }
        }
        public decimal MinInventoryforActive
        {
            get { return MinInventoryforActive_Backing / 10000.0m; }
            set { MinInventoryforActive_Backing = (int)(value * 10000.0m); }
        }

        private int _maxCasesforActive;
        [FixedLengthField(92, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int MaxCasesforActive
        {
            get { return _maxCasesforActive; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _maxCasesforActive = value;
            }
        }

        private int _minCasesforActive;
        [FixedLengthField(93, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int MinCasesforActive
        {
            get { return _minCasesforActive; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _minCasesforActive = value;
            }
        }

        private int _productLifeinDays;
        [FixedLengthField(94, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int ProductLifeinDays
        {
            get { return _productLifeinDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _productLifeinDays = value;
            }
        }

        private string _skuType;
        [FixedLengthField(95, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string SkuType
        {
            get { return _skuType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _skuType = value;
            }
        }

        private string _shipmentType;
        [FixedLengthField(96, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ShipmentType
        {
            get { return _shipmentType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shipmentType = value;
            }
        }

        private string _tariffClass;
        [FixedLengthField(97, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TariffClass
        {
            get { return _tariffClass; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _tariffClass = value;
            }
        }

        private int _activationDate;
        [FixedLengthField(98, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ActivationDate
        {
            get { return _activationDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _activationDate = value;
            }
        }

        private int _packRate;
        [FixedLengthField(99, 9, PaddingChar = '0', Padding = Padding.Left)]
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

        private long _wageValue;
        [FixedLengthField(100, 19, PaddingChar = '0', Padding = Padding.Left)]
        public long WageValue_Backing
        {
            get { return _wageValue; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _wageValue = value;
            }
        }
        public decimal WageValue
        {
            get { return WageValue_Backing / 10000.0m; }
            set { WageValue_Backing = (int)(value * 10000.0m); }
        }

        private int _pickRate;
        [FixedLengthField(101, 9, PaddingChar = '0', Padding = Padding.Left)]
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

        private int _specialProcessRate;
        [FixedLengthField(102, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int SpecialProcessRate_Backing
        {
            get { return _specialProcessRate; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _specialProcessRate = value;
            }
        }
        public decimal SpecialProcessRate
        {
            get { return SpecialProcessRate_Backing / 10000.0m; }
            set { SpecialProcessRate_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Always "N"
        private string _foreignTradeZone;
        [FixedLengthField(103, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ForeignTradeZone
        {
            get { return _foreignTradeZone; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _foreignTradeZone = value;
            }
        }

        // Used by New Balance
        // Tariff code or blanks.  (New NB Database holds Tariff codes for each style or sku.  If no record in database blanks.)
        private string _harmonizedTariffSchedule;
        [FixedLengthField(104, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string HarmonizedTariffSchedule
        {
            get { return _harmonizedTariffSchedule; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _harmonizedTariffSchedule = value;
            }
        }

        // Used by New Balance
        // ISO Country code, default is 840 for USA.  (On JBA this is tied to the PRC table which holds price regulator PREG35 data).
        private string _defaultCountryofOrigin;
        [FixedLengthField(105, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string DefaultCountryofOrigin
        {
            get { return _defaultCountryofOrigin; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _defaultCountryofOrigin = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _multipleCountryofOrigin;
        [FixedLengthField(106, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string MultipleCountryofOrigin
        {
            get { return _multipleCountryofOrigin; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _multipleCountryofOrigin = value;
            }
        }

        private string _dateSensitive;
        [FixedLengthField(107, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DateSensitive
        {
            get { return _dateSensitive; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _dateSensitive = value;
            }
        }

        private string _dateType;
        [FixedLengthField(108, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string DateType
        {
            get { return _dateType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _dateType = value;
            }
        }

        private string _displayDateFormat;
        [FixedLengthField(109, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DisplayDateFormat
        {
            get { return _displayDateFormat; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _displayDateFormat = value;
            }
        }

        private string _productTemperatureZone;
        [FixedLengthField(110, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ProductTemperatureZone
        {
            get { return _productTemperatureZone; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _productTemperatureZone = value;
            }
        }

        private string _trailerTemperatureZone;
        [FixedLengthField(111, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string TrailerTemperatureZone
        {
            get { return _trailerTemperatureZone; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _trailerTemperatureZone = value;
            }
        }

        private string _loadAttr;
        [FixedLengthField(112, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string LoadAttr
        {
            get { return _loadAttr; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _loadAttr = value;
            }
        }

        private string _hazardousMaterialCode;
        [FixedLengthField(113, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string HazardousMaterialCode
        {
            get { return _hazardousMaterialCode; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _hazardousMaterialCode = value;
            }
        }

        private string _merchandiseType;
        [FixedLengthField(114, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string MerchandiseType
        {
            get { return _merchandiseType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _merchandiseType = value;
            }
        }

        private string _merchandiseGroup;
        [FixedLengthField(115, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string MerchandiseGroup
        {
            get { return _merchandiseGroup; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _merchandiseGroup = value;
            }
        }

        private string _storeDepartment;
        [FixedLengthField(116, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string StoreDepartment
        {
            get { return _storeDepartment; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _storeDepartment = value;
            }
        }

        private int _productLifeWindow;
        [FixedLengthField(117, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int ProductLifeWindow
        {
            get { return _productLifeWindow; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _productLifeWindow = value;
            }
        }

        // Used by New Balance
        // Non shoes = .01
        private int _criticalDimension1;
        [FixedLengthField(118, 7, PaddingChar = '0', Padding = Padding.Left)]
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

        // Used by New Balance
        // Non shoes = .01
        private int _criticalDimension2;
        [FixedLengthField(119, 7, PaddingChar = '0', Padding = Padding.Left)]
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

        // Used by New Balance
        // Non shoes = .01
        private int _criticalDimension3;
        [FixedLengthField(120, 7, PaddingChar = '0', Padding = Padding.Left)]
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

        private int _optimumLinearSpace;
        [FixedLengthField(121, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int OptimumLinearSpace
        {
            get { return _optimumLinearSpace; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _optimumLinearSpace = value;
            }
        }

        private int _optimumLinearSpaceUnit;
        [FixedLengthField(122, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int OptimumLinearSpaceUnit
        {
            get { return _optimumLinearSpaceUnit; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _optimumLinearSpaceUnit = value;
            }
        }

        private string _topShelfEligible;
        [FixedLengthField(123, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TopShelfEligible
        {
            get { return _topShelfEligible; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _topShelfEligible = value;
            }
        }

        private string _automaticSubCase;
        [FixedLengthField(124, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AutomaticSubCase
        {
            get { return _automaticSubCase; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _automaticSubCase = value;
            }
        }

        private string _defaultConsumeDate;
        [FixedLengthField(125, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string DefaultConsumeDate
        {
            get { return _defaultConsumeDate; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _defaultConsumeDate = value;
            }
        }

        private string _serialNumberReqYn;
        [FixedLengthField(126, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SerialNumberReqYn
        {
            get { return _serialNumberReqYn; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _serialNumberReqYn = value;
            }
        }

        private string _excessWaveNeedProcFlag;
        [FixedLengthField(127, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ExcessWaveNeedProcFlag
        {
            get { return _excessWaveNeedProcFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _excessWaveNeedProcFlag = value;
            }
        }

        private string _pathNumber;
        [FixedLengthField(128, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private string _vendorNumber;
        [FixedLengthField(129, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string VendorNumber
        {
            get { return _vendorNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _vendorNumber = value;
            }
        }

        private string _vendorProductNumber;
        [FixedLengthField(130, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string VendorProductNumber
        {
            get { return _vendorProductNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _vendorProductNumber = value;
            }
        }

        private string _acceptManufacDate;
        [FixedLengthField(131, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AcceptManufacDate
        {
            get { return _acceptManufacDate; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _acceptManufacDate = value;
            }
        }

        private string _acceptExpirationDate;
        [FixedLengthField(132, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AcceptExpirationDate
        {
            get { return _acceptExpirationDate; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _acceptExpirationDate = value;
            }
        }

        private string _acceptCatchWeight;
        [FixedLengthField(133, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AcceptCatchWeight
        {
            get { return _acceptCatchWeight; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _acceptCatchWeight = value;
            }
        }

        private int _catchWtTolerancePercent;
        [FixedLengthField(134, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int CatchWtTolerancePercent_Backing
        {
            get { return _catchWtTolerancePercent; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _catchWtTolerancePercent = value;
            }
        }
        public decimal CatchWtTolerancePercent
        {
            get { return CatchWtTolerancePercent_Backing / 100.0m; }
            set { CatchWtTolerancePercent_Backing = (int)(value * 100.0m); }
        }

        private long _catchWeightTolerance;
        [FixedLengthField(135, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long CatchWeightTolerance_Backing
        {
            get { return _catchWeightTolerance; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _catchWeightTolerance = value;
            }
        }
        public decimal CatchWeightTolerance
        {
            get { return CatchWeightTolerance_Backing / 100000.0m; }
            set { CatchWeightTolerance_Backing = (int)(value * 100000.0m); }
        }

        private long _catchWeightErrorTolerance;
        [FixedLengthField(136, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long CatchWeightErrorTolerance_Backing
        {
            get { return _catchWeightErrorTolerance; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _catchWeightErrorTolerance = value;
            }
        }
        public decimal CatchWeightErrorTolerance
        {
            get { return CatchWeightErrorTolerance_Backing / 100000.0m; }
            set { CatchWeightErrorTolerance_Backing = (int)(value * 100000.0m); }
        }

        private int _catchWeightErrorTolPercent;
        [FixedLengthField(137, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int CatchWeightErrorTolPercent_Backing
        {
            get { return _catchWeightErrorTolPercent; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _catchWeightErrorTolPercent = value;
            }
        }
        public decimal CatchWeightErrorTolPercent
        {
            get { return CatchWeightErrorTolPercent_Backing / 100.0m; }
            set { CatchWeightErrorTolPercent_Backing = (int)(value * 100.0m); }
        }

        private string _buyerDispositionCode;
        [FixedLengthField(138, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string BuyerDispositionCode
        {
            get { return _buyerDispositionCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _buyerDispositionCode = value;
            }
        }

        private string _inventoryAllocationType;
        [FixedLengthField(139, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InventoryAllocationType
        {
            get { return _inventoryAllocationType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _inventoryAllocationType = value;
            }
        }

        private string _priceTicketType;
        [FixedLengthField(140, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PriceTicketType
        {
            get { return _priceTicketType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _priceTicketType = value;
            }
        }

        // Used by New Balance
        // "NU" when it’s a demo shoe or a Non Shoe or a Shoe with no UPC code assigned.  Default is blanks.
        private string _specialInstructionCode1;
        [FixedLengthField(141, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode1
        {
            get { return _specialInstructionCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode1 = value;
            }
        }

        // Used by New Balance
        // Sourcing Warehouse Code
        private string _specialInstructionCode2;
        [FixedLengthField(142, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(143, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(144, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(145, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode5
        {
            get { return _specialInstructionCode5; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode5 = value;
            }
        }

        private string _specialInstructionCode6;
        [FixedLengthField(146, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode6
        {
            get { return _specialInstructionCode6; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode6 = value;
            }
        }

        private string _specialInstructionCode7;
        [FixedLengthField(147, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode7
        {
            get { return _specialInstructionCode7; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode7 = value;
            }
        }

        private string _specialInstructionCode8;
        [FixedLengthField(148, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode8
        {
            get { return _specialInstructionCode8; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode8 = value;
            }
        }

        private string _specialInstructionCode9;
        [FixedLengthField(149, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode9
        {
            get { return _specialInstructionCode9; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode9 = value;
            }
        }

        private string _specialInstructionCode10;
        [FixedLengthField(150, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode10
        {
            get { return _specialInstructionCode10; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode10 = value;
            }
        }

        private int _miscellaneousNumericField1;
        [FixedLengthField(151, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MiscellaneousNumericField1_Backing
        {
            get { return _miscellaneousNumericField1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField1 = value;
            }
        }
        public decimal MiscellaneousNumericField1
        {
            get { return MiscellaneousNumericField1_Backing / 10000.0m; }
            set { MiscellaneousNumericField1_Backing = (int)(value * 10000.0m); }
        }

        private int _miscellaneousNumericField2;
        [FixedLengthField(152, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MiscellaneousNumericField2_Backing
        {
            get { return _miscellaneousNumericField2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField2 = value;
            }
        }
        public decimal MiscellaneousNumericField2
        {
            get { return MiscellaneousNumericField2_Backing / 10000.0m; }
            set { MiscellaneousNumericField2_Backing = (int)(value * 10000.0m); }
        }

        private int _miscellaneousNumericField3;
        [FixedLengthField(153, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MiscellaneousNumericField3_Backing
        {
            get { return _miscellaneousNumericField3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField3 = value;
            }
        }
        public decimal MiscellaneousNumericField3
        {
            get { return MiscellaneousNumericField3_Backing / 10000.0m; }
            set { MiscellaneousNumericField3_Backing = (int)(value * 10000.0m); }
        }

        private int _miscellaneousNumericField4;
        [FixedLengthField(154, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MiscellaneousNumericField4_Backing
        {
            get { return _miscellaneousNumericField4; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField4 = value;
            }
        }
        public decimal MiscellaneousNumericField4
        {
            get { return MiscellaneousNumericField4_Backing / 10000.0m; }
            set { MiscellaneousNumericField4_Backing = (int)(value * 10000.0m); }
        }

        private int _miscellaneousNumericField5;
        [FixedLengthField(155, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MiscellaneousNumericField5_Backing
        {
            get { return _miscellaneousNumericField5; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField5 = value;
            }
        }
        public decimal MiscellaneousNumericField5
        {
            get { return MiscellaneousNumericField5_Backing / 10000.0m; }
            set { MiscellaneousNumericField5_Backing = (int)(value * 10000.0m); }
        }

        private string _recordExpansionField;
        [FixedLengthField(156, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
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
        // For label printing.  Width description (6), French Width description (9), USA Size (3), UK Size (3), Europe Size (3), Centimeter Size (3), Issue Unit of Measure (2).   IMPORTANT: Suppress leading zeros and left justify all size fields.  If all above fields are not available then put in the STSDIM or size of the SKU.
        private string _customRecordExpansionField;
        [FixedLengthField(157, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _statusCode;
        [FixedLengthField(158, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _statusCode = value;
            }
        }

        private string _trackSkuAttributes;
        [FixedLengthField(159, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TrackSkuAttributes
        {
            get { return _trackSkuAttributes; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _trackSkuAttributes = value;
            }
        }

        // Used by New Balance
        // Always "Y"
        private string _trackBatchNumber;
        [FixedLengthField(160, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TrackBatchNumber
        {
            get { return _trackBatchNumber; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _trackBatchNumber = value;
            }
        }

        private string _trackProductStatus;
        [FixedLengthField(161, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TrackProductStatus
        {
            get { return _trackProductStatus; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _trackProductStatus = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _trackCountryofOrigin;
        [FixedLengthField(162, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TrackCountryofOrigin
        {
            get { return _trackCountryofOrigin; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _trackCountryofOrigin = value;
            }
        }

        private long _unitsperGrabReserve;
        [FixedLengthField(163, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long UnitsperGrabReserve_Backing
        {
            get { return _unitsperGrabReserve; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _unitsperGrabReserve = value;
            }
        }
        public decimal UnitsperGrabReserve
        {
            get { return UnitsperGrabReserve_Backing / 10000.0m; }
            set { UnitsperGrabReserve_Backing = (int)(value * 10000.0m); }
        }

        private long _unitsperGrabCasPk;
        [FixedLengthField(164, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long UnitsperGrabCasPk_Backing
        {
            get { return _unitsperGrabCasPk; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _unitsperGrabCasPk = value;
            }
        }
        public decimal UnitsperGrabCasPk
        {
            get { return UnitsperGrabCasPk_Backing / 10000.0m; }
            set { UnitsperGrabCasPk_Backing = (int)(value * 10000.0m); }
        }

        private long _unitsperPickActive;
        [FixedLengthField(165, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long UnitsperPickActive_Backing
        {
            get { return _unitsperPickActive; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _unitsperPickActive = value;
            }
        }
        public decimal UnitsperPickActive
        {
            get { return UnitsperPickActive_Backing / 10000.0m; }
            set { UnitsperPickActive_Backing = (int)(value * 10000.0m); }
        }

        private string _handlingAttributeActive;
        [FixedLengthField(166, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string HandlingAttributeActive
        {
            get { return _handlingAttributeActive; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _handlingAttributeActive = value;
            }
        }

        private string _reserveHandlingAttribute;
        [FixedLengthField(167, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ReserveHandlingAttribute
        {
            get { return _reserveHandlingAttribute; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _reserveHandlingAttribute = value;
            }
        }

        private string _casePickHandlingAttribute;
        [FixedLengthField(168, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CasePickHandlingAttribute
        {
            get { return _casePickHandlingAttribute; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _casePickHandlingAttribute = value;
            }
        }

        private string _ticketType;
        [FixedLengthField(169, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TicketType
        {
            get { return _ticketType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _ticketType = value;
            }
        }

        private string _sensorTagType;
        [FixedLengthField(170, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string SensorTagType
        {
            get { return _sensorTagType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _sensorTagType = value;
            }
        }

        // Used by New Balance
        // "2" for add/change and "4" for delete
        private string _function;
        [FixedLengthField(171, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Function
        {
            get { return _function; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _function = value;
            }
        }

        // Used by New Balance
        // 2 tables hold this information in JBA NMF1 (by silhouette) and NMF2 (by product line)
        private string _nmfcCode;
        [FixedLengthField(172, 9, PaddingChar = ' ', Padding = Padding.Right, NullValue="         ")]
        public string NmfcCode
        {
            get { return _nmfcCode; }
            set
            {
                if(value != default(string) && value.Length > 9) throw new ArgumentOutOfRangeException("value");
                _nmfcCode = value;
            }
        }

        private int _physicalDimension1;
        [FixedLengthField(173, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PhysicalDimension1_Backing
        {
            get { return _physicalDimension1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _physicalDimension1 = value;
            }
        }
        public decimal PhysicalDimension1
        {
            get { return PhysicalDimension1_Backing / 100.0m; }
            set { PhysicalDimension1_Backing = (int)(value * 100.0m); }
        }

        private int _physicalDimension2;
        [FixedLengthField(174, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PhysicalDimension2_Backing
        {
            get { return _physicalDimension2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _physicalDimension2 = value;
            }
        }
        public decimal PhysicalDimension2
        {
            get { return PhysicalDimension2_Backing / 100.0m; }
            set { PhysicalDimension2_Backing = (int)(value * 100.0m); }
        }

        private int _physicalDimension3;
        [FixedLengthField(175, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PhysicalDimension3_Backing
        {
            get { return _physicalDimension3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _physicalDimension3 = value;
            }
        }
        public decimal PhysicalDimension3
        {
            get { return PhysicalDimension3_Backing / 100.0m; }
            set { PhysicalDimension3_Backing = (int)(value * 100.0m); }
        }

        private int _numberCasesPerPallet;
        [FixedLengthField(176, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int NumberCasesPerPallet
        {
            get { return _numberCasesPerPallet; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _numberCasesPerPallet = value;
            }
        }

        private string _i2of5PkgIndicator;
        [FixedLengthField(177, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2of5PkgIndicator
        {
            get { return _i2of5PkgIndicator; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2of5PkgIndicator = value;
            }
        }

        private string _consumeCasePriority;
        [FixedLengthField(178, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ConsumeCasePriority
        {
            get { return _consumeCasePriority; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _consumeCasePriority = value;
            }
        }

        private string _itemExclusionClass;
        [FixedLengthField(179, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ItemExclusionClass
        {
            get { return _itemExclusionClass; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _itemExclusionClass = value;
            }
        }

        // Used by New Balance
        // "N" if bought or bought and made, "Y" if made only 
        private string _producer;
        [FixedLengthField(180, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Producer
        {
            get { return _producer; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _producer = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _netCostValidation;
        [FixedLengthField(181, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NetCostValidation
        {
            get { return _netCostValidation; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _netCostValidation = value;
            }
        }

        private string _exportLicenseNumber;
        [FixedLengthField(182, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string ExportLicenseNumber
        {
            get { return _exportLicenseNumber; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _exportLicenseNumber = value;
            }
        }

        private int _exportLicenseExpireDate;
        [FixedLengthField(183, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ExportLicenseExpireDate
        {
            get { return _exportLicenseExpireDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _exportLicenseExpireDate = value;
            }
        }

        private string _exportControlClassNumber;
        [FixedLengthField(184, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string ExportControlClassNumber
        {
            get { return _exportControlClassNumber; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _exportControlClassNumber = value;
            }
        }

        private string _exportLicenseExceptSymbol;
        [FixedLengthField(185, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string ExportLicenseExceptSymbol
        {
            get { return _exportLicenseExceptSymbol; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _exportLicenseExceptSymbol = value;
            }
        }

        // Used by New Balance
        // Material type description
        private string _ftsrExceptionNumber;
        [FixedLengthField(186, 32, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                ")]
        public string FtsrExceptionNumber
        {
            get { return _ftsrExceptionNumber; }
            set
            {
                if(value != default(string) && value.Length > 32) throw new ArgumentOutOfRangeException("value");
                _ftsrExceptionNumber = value;
            }
        }

        private string _crushabilityCode;
        [FixedLengthField(187, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CrushabilityCode
        {
            get { return _crushabilityCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _crushabilityCode = value;
            }
        }

        private long _minInvDrp;
        [FixedLengthField(188, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MinInvDrp_Backing
        {
            get { return _minInvDrp; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _minInvDrp = value;
            }
        }
        public decimal MinInvDrp
        {
            get { return MinInvDrp_Backing / 10000.0m; }
            set { MinInvDrp_Backing = (int)(value * 10000.0m); }
        }

        private long _maxInvDrp;
        [FixedLengthField(189, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MaxInvDrp_Backing
        {
            get { return _maxInvDrp; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _maxInvDrp = value;
            }
        }
        public decimal MaxInvDrp
        {
            get { return MaxInvDrp_Backing / 10000.0m; }
            set { MaxInvDrp_Backing = (int)(value * 10000.0m); }
        }

        private long _unitsPerGrab;
        [FixedLengthField(190, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long UnitsPerGrab_Backing
        {
            get { return _unitsPerGrab; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _unitsPerGrab = value;
            }
        }
        public decimal UnitsPerGrab
        {
            get { return UnitsPerGrab_Backing / 10000.0m; }
            set { UnitsPerGrab_Backing = (int)(value * 10000.0m); }
        }

        private string _handlingAttrib;
        [FixedLengthField(191, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string HandlingAttrib
        {
            get { return _handlingAttrib; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _handlingAttrib = value;
            }
        }

        private string _activeVelRate;
        [FixedLengthField(192, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ActiveVelRate
        {
            get { return _activeVelRate; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _activeVelRate = value;
            }
        }

        private string _csPkVelRate;
        [FixedLengthField(193, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string CsPkVelRate
        {
            get { return _csPkVelRate; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _csPkVelRate = value;
            }
        }

        // Used by New Balance
        // Category and Sub category description (PGMN on JBA).  Example: Mens Running, Womens Walking
        private string _commodityCode;
        [FixedLengthField(194, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string CommodityCode
        {
            get { return _commodityCode; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _commodityCode = value;
            }
        }

        private string _exportCommodityCode;
        [FixedLengthField(195, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string ExportCommodityCode
        {
            get { return _exportCommodityCode; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _exportCommodityCode = value;
            }
        }

        private string _grpCode1;
        [FixedLengthField(196, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string GrpCode1
        {
            get { return _grpCode1; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _grpCode1 = value;
            }
        }

        private string _grpCode2;
        [FixedLengthField(197, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string GrpCode2
        {
            get { return _grpCode2; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _grpCode2 = value;
            }
        }

        private string _grpCode3;
        [FixedLengthField(198, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string GrpCode3
        {
            get { return _grpCode3; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _grpCode3 = value;
            }
        }

        private string _grpCode4;
        [FixedLengthField(199, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string GrpCode4
        {
            get { return _grpCode4; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _grpCode4 = value;
            }
        }

        private string _grpCode5;
        [FixedLengthField(200, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string GrpCode5
        {
            get { return _grpCode5; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _grpCode5 = value;
            }
        }

        private string _coMingleCat;
        [FixedLengthField(201, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string CoMingleCat
        {
            get { return _coMingleCat; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _coMingleCat = value;
            }
        }

        private string _itemVersSub;
        [FixedLengthField(202, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ItemVersSub
        {
            get { return _itemVersSub; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _itemVersSub = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _lotControlUsed;
        [FixedLengthField(203, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string LotControlUsed
        {
            get { return _lotControlUsed; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _lotControlUsed = value;
            }
        }

        private string _defaultLotStat;
        [FixedLengthField(204, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string DefaultLotStat
        {
            get { return _defaultLotStat; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _defaultLotStat = value;
            }
        }

        private int _numberLotsAssgn;
        [FixedLengthField(205, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int NumberLotsAssgn
        {
            get { return _numberLotsAssgn; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _numberLotsAssgn = value;
            }
        }

        private string _rankCode;
        [FixedLengthField(206, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string RankCode
        {
            get { return _rankCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _rankCode = value;
            }
        }

        private string _rtRankCode;
        [FixedLengthField(207, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string RtRankCode
        {
            get { return _rtRankCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _rtRankCode = value;
            }
        }

        private string _receivingCategory;
        [FixedLengthField(208, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ReceivingCategory
        {
            get { return _receivingCategory; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _receivingCategory = value;
            }
        }

        private string _returnsCategory;
        [FixedLengthField(209, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ReturnsCategory
        {
            get { return _returnsCategory; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _returnsCategory = value;
            }
        }

        private string _naftaPrefCriteria;
        [FixedLengthField(210, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NaftaPrefCriteria
        {
            get { return _naftaPrefCriteria; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _naftaPrefCriteria = value;
            }
        }

        private string _innerCtnType;
        [FixedLengthField(211, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InnerCtnType
        {
            get { return _innerCtnType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _innerCtnType = value;
            }
        }

        private string _innerCartonBreakAttr;
        [FixedLengthField(212, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InnerCartonBreakAttr
        {
            get { return _innerCartonBreakAttr; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _innerCartonBreakAttr = value;
            }
        }

        private string _itemOrientation;
        [FixedLengthField(213, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ItemOrientation
        {
            get { return _itemOrientation; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _itemOrientation = value;
            }
        }

        private int _stackabilityOfTheItem;
        [FixedLengthField(214, 1, PaddingChar = '0', Padding = Padding.Left, NullValue="0")]
        public int StackabilityOfTheItem
        {
            get { return _stackabilityOfTheItem; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 1) throw new ArgumentOutOfRangeException("value");
                _stackabilityOfTheItem = value;
            }
        }

        private int _cavityLength;
        [FixedLengthField(215, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CavityLength_Backing
        {
            get { return _cavityLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cavityLength = value;
            }
        }
        public decimal CavityLength
        {
            get { return CavityLength_Backing / 100.0m; }
            set { CavityLength_Backing = (int)(value * 100.0m); }
        }

        private int _cavityWidth;
        [FixedLengthField(216, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CavityWidth_Backing
        {
            get { return _cavityWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cavityWidth = value;
            }
        }
        public decimal CavityWidth
        {
            get { return CavityWidth_Backing / 100.0m; }
            set { CavityWidth_Backing = (int)(value * 100.0m); }
        }

        private int _cavityHeight;
        [FixedLengthField(217, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CavityHeight_Backing
        {
            get { return _cavityHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cavityHeight = value;
            }
        }
        public decimal CavityHeight
        {
            get { return CavityHeight_Backing / 100.0m; }
            set { CavityHeight_Backing = (int)(value * 100.0m); }
        }

        private int _maxNest;
        [FixedLengthField(218, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int MaxNest_Backing
        {
            get { return _maxNest; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _maxNest = value;
            }
        }
        public decimal MaxNest
        {
            get { return MaxNest_Backing / 100.0m; }
            set { MaxNest_Backing = (int)(value * 100.0m); }
        }

        private int _incrementalLength;
        [FixedLengthField(219, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int IncrementalLength_Backing
        {
            get { return _incrementalLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _incrementalLength = value;
            }
        }
        public decimal IncrementalLength
        {
            get { return IncrementalLength_Backing / 100.0m; }
            set { IncrementalLength_Backing = (int)(value * 100.0m); }
        }

        private int _incrementalWidth;
        [FixedLengthField(220, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int IncrementalWidth_Backing
        {
            get { return _incrementalWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _incrementalWidth = value;
            }
        }
        public decimal IncrementalWidth
        {
            get { return IncrementalWidth_Backing / 100.0m; }
            set { IncrementalWidth_Backing = (int)(value * 100.0m); }
        }

        private int _incrementalHeight;
        [FixedLengthField(221, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int IncrementalHeight_Backing
        {
            get { return _incrementalHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _incrementalHeight = value;
            }
        }
        public decimal IncrementalHeight
        {
            get { return IncrementalHeight_Backing / 100.0m; }
            set { IncrementalHeight_Backing = (int)(value * 100.0m); }
        }

        private string _stabilizationCode;
        [FixedLengthField(222, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string StabilizationCode
        {
            get { return _stabilizationCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _stabilizationCode = value;
            }
        }

        private string _incubActivatedFlag;
        [FixedLengthField(223, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string IncubActivatedFlag
        {
            get { return _incubActivatedFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _incubActivatedFlag = value;
            }
        }

        private int _incubPeriodDays;
        [FixedLengthField(224, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int IncubPeriodDays
        {
            get { return _incubPeriodDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _incubPeriodDays = value;
            }
        }

        private int _incubPeriodHrs;
        [FixedLengthField(225, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int IncubPeriodHrs
        {
            get { return _incubPeriodHrs; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _incubPeriodHrs = value;
            }
        }

        private int _secIncubPeriodDays;
        [FixedLengthField(226, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int SecIncubPeriodDays
        {
            get { return _secIncubPeriodDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _secIncubPeriodDays = value;
            }
        }

        private int _secIncubPeriodHours;
        [FixedLengthField(227, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int SecIncubPeriodHours
        {
            get { return _secIncubPeriodHours; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _secIncubPeriodHours = value;
            }
        }

        private string _incubLockCode;
        [FixedLengthField(228, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string IncubLockCode
        {
            get { return _incubLockCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _incubLockCode = value;
            }
        }

        private string _productClassCode;
        [FixedLengthField(229, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue="                         ")]
        public string ProductClassCode
        {
            get { return _productClassCode; }
            set
            {
                if(value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _productClassCode = value;
            }
        }

        // Used by New Balance
        // Always "0"
        private string _vendorTaggedEpc;
        [FixedLengthField(230, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string VendorTaggedEpc
        {
            get { return _vendorTaggedEpc; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _vendorTaggedEpc = value;
            }
        }

        private string _garmentsOnHangerFlag;
        [FixedLengthField(231, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string GarmentsOnHangerFlag
        {
            get { return _garmentsOnHangerFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _garmentsOnHangerFlag = value;
            }
        }

        private long _monetaryValue;
        [FixedLengthField(232, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MonetaryValue_Backing
        {
            get { return _monetaryValue; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _monetaryValue = value;
            }
        }
        public decimal MonetaryValue
        {
            get { return MonetaryValue_Backing / 100.0m; }
            set { MonetaryValue_Backing = (int)(value * 100.0m); }
        }

        private string _mvCurrencyCode;
        [FixedLengthField(233, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string MvCurrencyCode
        {
            get { return _mvCurrencyCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _mvCurrencyCode = value;
            }
        }

        private string _mvSizeUom;
        [FixedLengthField(234, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string MvSizeUom
        {
            get { return _mvSizeUom; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _mvSizeUom = value;
            }
        }

        private string _tpeCommodityCode;
        [FixedLengthField(235, 16, PaddingChar = ' ', Padding = Padding.Right, NullValue="                ")]
        public string TpeCommodityCode
        {
            get { return _tpeCommodityCode; }
            set
            {
                if(value != default(string) && value.Length > 16) throw new ArgumentOutOfRangeException("value");
                _tpeCommodityCode = value;
            }
        }

        private string _unNumber;
        [FixedLengthField(236, 32, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                ")]
        public string UnNumber
        {
            get { return _unNumber; }
            set
            {
                if(value != default(string) && value.Length > 32) throw new ArgumentOutOfRangeException("value");
                _unNumber = value;
            }
        }

        private int _consumePrtyWndwDays;
        [FixedLengthField(237, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int ConsumePrtyWndwDays
        {
            get { return _consumePrtyWndwDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _consumePrtyWndwDays = value;
            }
        }

        private string _productCategory;
        [FixedLengthField(238, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductCategory
        {
            get { return _productCategory; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productCategory = value;
            }
        }

        private string _unidNumber;
        [FixedLengthField(239, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string UnidNumber
        {
            get { return _unidNumber; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _unidNumber = value;
            }
        }

        private string _idVersion;
        [FixedLengthField(240, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string IdVersion
        {
            get { return _idVersion; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _idVersion = value;
            }
        }

        private long _liquidQuantity;
        [FixedLengthField(241, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long LiquidQuantity_Backing
        {
            get { return _liquidQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _liquidQuantity = value;
            }
        }
        public decimal LiquidQuantity
        {
            get { return LiquidQuantity_Backing / 100000.0m; }
            set { LiquidQuantity_Backing = (int)(value * 100000.0m); }
        }

        private string _slotMisc1;
        [FixedLengthField(242, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc1
        {
            get { return _slotMisc1; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc1 = value;
            }
        }

        private string _slotMisc2;
        [FixedLengthField(243, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc2
        {
            get { return _slotMisc2; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc2 = value;
            }
        }

        private string _slotMisc3;
        [FixedLengthField(244, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc3
        {
            get { return _slotMisc3; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc3 = value;
            }
        }

        private string _slotMisc4;
        [FixedLengthField(245, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc4
        {
            get { return _slotMisc4; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc4 = value;
            }
        }

        private string _slotMisc5;
        [FixedLengthField(246, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc5
        {
            get { return _slotMisc5; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc5 = value;
            }
        }

        private string _slotMisc6;
        [FixedLengthField(247, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SlotMisc6
        {
            get { return _slotMisc6; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _slotMisc6 = value;
            }
        }

        private string _slotRotateEachesFlag;
        [FixedLengthField(248, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SlotRotateEachesFlag
        {
            get { return _slotRotateEachesFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _slotRotateEachesFlag = value;
            }
        }

        private string _slotRotateInnersFlag;
        [FixedLengthField(249, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SlotRotateInnersFlag
        {
            get { return _slotRotateInnersFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _slotRotateInnersFlag = value;
            }
        }

        private string _slotRotateBinsFlag;
        [FixedLengthField(250, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SlotRotateBinsFlag
        {
            get { return _slotRotateBinsFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _slotRotateBinsFlag = value;
            }
        }

        private string _slotRotateCasesFlag;
        [FixedLengthField(251, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SlotRotateCasesFlag
        {
            get { return _slotRotateCasesFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _slotRotateCasesFlag = value;
            }
        }

        private string _slot3dSlottingFlag;
        [FixedLengthField(252, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Slot3dSlottingFlag
        {
            get { return _slot3dSlottingFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _slot3dSlottingFlag = value;
            }
        }

        private string _cartonEpcType;
        [FixedLengthField(253, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(254, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PalletEpcType
        {
            get { return _palletEpcType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _palletEpcType = value;
            }
        }

        private string _exceedPercentageInSmartPull;
        [FixedLengthField(255, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ExceedPercentageInSmartPull
        {
            get { return _exceedPercentageInSmartPull; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _exceedPercentageInSmartPull = value;
            }
        }

        private int _exceedPercentageInSmartAllocation;
        [FixedLengthField(256, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int ExceedPercentageInSmartAllocation_Backing
        {
            get { return _exceedPercentageInSmartAllocation; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _exceedPercentageInSmartAllocation = value;
            }
        }
        public decimal ExceedPercentageInSmartAllocation
        {
            get { return ExceedPercentageInSmartAllocation_Backing / 100.0m; }
            set { ExceedPercentageInSmartAllocation_Backing = (int)(value * 100.0m); }
        }

        private string _nonInventorySku;
        [FixedLengthField(257, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NonInventorySku
        {
            get { return _nonInventorySku; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _nonInventorySku = value;
            }
        }

        private string _nonInventorySkuTrackingType;
        [FixedLengthField(258, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NonInventorySkuTrackingType
        {
            get { return _nonInventorySkuTrackingType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _nonInventorySkuTrackingType = value;
            }
        }

        private string _nonInventorySkuInventoryReduction;
        [FixedLengthField(259, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NonInventorySkuInventoryReduction
        {
            get { return _nonInventorySkuInventoryReduction; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _nonInventorySkuInventoryReduction = value;
            }
        }

        private string _sloTtoAssignLocation;
        [FixedLengthField(260, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SloTtoAssignLocation
        {
            get { return _sloTtoAssignLocation; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _sloTtoAssignLocation = value;
            }
        }

        private string _reserveVelocityRate;
        [FixedLengthField(261, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReserveVelocityRate
        {
            get { return _reserveVelocityRate; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reserveVelocityRate = value;
            }
        }

        private string _frameworkId;
        [FixedLengthField(262, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string FrameworkId
        {
            get { return _frameworkId; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _frameworkId = value;
            }
        }

        private string _frameworkFlags;
        [FixedLengthField(263, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string FrameworkFlags
        {
            get { return _frameworkFlags; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _frameworkFlags = value;
            }
        }

        private string _trackCasesInActive;
        [FixedLengthField(264, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TrackCasesInActive
        {
            get { return _trackCasesInActive; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _trackCasesInActive = value;
            }
        }

        private string _certificateOfOriginPrintFl;
        [FixedLengthField(265, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CertificateOfOriginPrintFl
        {
            get { return _certificateOfOriginPrintFl; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _certificateOfOriginPrintFl = value;
            }
        }

        private string _shippersExportDeclarationPr;
        [FixedLengthField(266, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShippersExportDeclarationPr
        {
            get { return _shippersExportDeclarationPr; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shippersExportDeclarationPr = value;
            }
        }

        private string _internationalSpecialCommodity;
        [FixedLengthField(267, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string InternationalSpecialCommodity
        {
            get { return _internationalSpecialCommodity; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _internationalSpecialCommodity = value;
            }
        }

        private long _bundleQuantity;
        [FixedLengthField(268, 11, PaddingChar = '0', Padding = Padding.Left)]
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

        private string _transferWarehouse;
        [FixedLengthField(269, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TransferWarehouse
        {
            get { return _transferWarehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transferWarehouse = value;
            }
        }

        private long _maxStackFactorUnits;
        [FixedLengthField(270, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long MaxStackFactorUnits_Backing
        {
            get { return _maxStackFactorUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _maxStackFactorUnits = value;
            }
        }
        public decimal MaxStackFactorUnits
        {
            get { return MaxStackFactorUnits_Backing / 10000.0m; }
            set { MaxStackFactorUnits_Backing = (int)(value * 10000.0m); }
        }

        private string _rotateHeightDuringMinMax;
        [FixedLengthField(271, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string RotateHeightDuringMinMax
        {
            get { return _rotateHeightDuringMinMax; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _rotateHeightDuringMinMax = value;
            }
        }

        private int _cycleCountEscalationQuantity;
        [FixedLengthField(272, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int CycleCountEscalationQuantity_Backing
        {
            get { return _cycleCountEscalationQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _cycleCountEscalationQuantity = value;
            }
        }
        public decimal CycleCountEscalationQuantity
        {
            get { return CycleCountEscalationQuantity_Backing / 100.0m; }
            set { CycleCountEscalationQuantity_Backing = (int)(value * 100.0m); }
        }

        private int _cycleCountEscalationValue;
        [FixedLengthField(273, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int CycleCountEscalationValue
        {
            get { return _cycleCountEscalationValue; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _cycleCountEscalationValue = value;
            }
        }

        private string _hostDataFlag;
        [FixedLengthField(274, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string HostDataFlag
        {
            get { return _hostDataFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _hostDataFlag = value;
            }
        }

        private string _nonHazLiBatteryIndicator;
        [FixedLengthField(275, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NonHazLiBatteryIndicator
        {
            get { return _nonHazLiBatteryIndicator; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _nonHazLiBatteryIndicator = value;
            }
        }

        private long _multipackQuantity;
        [FixedLengthField(276, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long MultipackQuantity_Backing
        {
            get { return _multipackQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _multipackQuantity = value;
            }
        }
        public decimal MultipackQuantity
        {
            get { return MultipackQuantity_Backing / 10000.0m; }
            set { MultipackQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _multipackIpQuantity;
        [FixedLengthField(277, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long MultipackIpQuantity_Backing
        {
            get { return _multipackIpQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _multipackIpQuantity = value;
            }
        }
        public decimal MultipackIpQuantity
        {
            get { return MultipackIpQuantity_Backing / 10000.0m; }
            set { MultipackIpQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _multipackWeight;
        [FixedLengthField(278, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MultipackWeight_Backing
        {
            get { return _multipackWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _multipackWeight = value;
            }
        }
        public decimal MultipackWeight
        {
            get { return MultipackWeight_Backing / 100000.0m; }
            set { MultipackWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _multipackVolume;
        [FixedLengthField(279, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MultipackVolume_Backing
        {
            get { return _multipackVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _multipackVolume = value;
            }
        }
        public decimal MultipackVolume
        {
            get { return MultipackVolume_Backing / 100000.0m; }
            set { MultipackVolume_Backing = (int)(value * 100000.0m); }
        }

        private int _multipackDimension1;
        [FixedLengthField(280, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int MultipackDimension1_Backing
        {
            get { return _multipackDimension1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _multipackDimension1 = value;
            }
        }
        public decimal MultipackDimension1
        {
            get { return MultipackDimension1_Backing / 100.0m; }
            set { MultipackDimension1_Backing = (int)(value * 100.0m); }
        }

        private int _multipackDimension2;
        [FixedLengthField(281, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int MultipackDimension2_Backing
        {
            get { return _multipackDimension2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _multipackDimension2 = value;
            }
        }
        public decimal MultipackDimension2
        {
            get { return MultipackDimension2_Backing / 100.0m; }
            set { MultipackDimension2_Backing = (int)(value * 100.0m); }
        }

        private int _multipackDimension3;
        [FixedLengthField(282, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int MultipackDimension3_Backing
        {
            get { return _multipackDimension3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _multipackDimension3 = value;
            }
        }
        public decimal MultipackDimension3
        {
            get { return MultipackDimension3_Backing / 100.0m; }
            set { MultipackDimension3_Backing = (int)(value * 100.0m); }
        }

        private long _nationalDrugCode;
        [FixedLengthField(283, 10, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000")]
        public long NationalDrugCode
        {
            get { return _nationalDrugCode; }
            set
            {
                if(value != default(long) && value.ToString(CultureInfo.InvariantCulture).Length > 10) throw new ArgumentOutOfRangeException("value");
                _nationalDrugCode = value;
            }
        }

        private string _ndcFormatType;
        [FixedLengthField(284, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string NdcFormatType
        {
            get { return _ndcFormatType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _ndcFormatType = value;
            }
        }

        private long _ndcHipaaFormat;
        [FixedLengthField(285, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long NdcHipaaFormat
        {
            get { return _ndcHipaaFormat; }
            set
            {
                if(value != default(long) && value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _ndcHipaaFormat = value;
            }
        }

        private string _deaDrugSchedule;
        [FixedLengthField(286, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string DeaDrugSchedule
        {
            get { return _deaDrugSchedule; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _deaDrugSchedule = value;
            }
        }

        private string _stateDrugSchedule;
        [FixedLengthField(287, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string StateDrugSchedule
        {
            get { return _stateDrugSchedule; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _stateDrugSchedule = value;
            }
        }

        private string _deaForm222Required;
        [FixedLengthField(288, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DeaForm222Required
        {
            get { return _deaForm222Required; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deaForm222Required = value;
            }
        }

        private string _pedigreeRequired;
        [FixedLengthField(289, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PedigreeRequired
        {
            get { return _pedigreeRequired; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _pedigreeRequired = value;
            }
        }

        private string _secureStorageRequirement;
        [FixedLengthField(290, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SecureStorageRequirement
        {
            get { return _secureStorageRequirement; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _secureStorageRequirement = value;
            }
        }

        private string _specialStorageRequirement1;
        [FixedLengthField(291, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialStorageRequirement1
        {
            get { return _specialStorageRequirement1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialStorageRequirement1 = value;
            }
        }

        private string _specialStorageRequirement2;
        [FixedLengthField(292, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialStorageRequirement2
        {
            get { return _specialStorageRequirement2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialStorageRequirement2 = value;
            }
        }

        private string _specialStorageRequirement3;
        [FixedLengthField(293, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialStorageRequirement3
        {
            get { return _specialStorageRequirement3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialStorageRequirement3 = value;
            }
        }

        private int _shortDays;
        [FixedLengthField(294, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int ShortDays
        {
            get { return _shortDays; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _shortDays = value;
            }
        }

    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
