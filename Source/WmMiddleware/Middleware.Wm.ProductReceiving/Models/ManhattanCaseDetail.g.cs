using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Middleware.Wm.ProductReceiving.Models
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class ManhattanCaseDetail
    {
        private int _errorSequence;
        [FixedLengthField(1, 9, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(2, 9, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(3, 7, PaddingChar = '0', Padding = Padding.Left)]
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
        // date created
        private int _dateCreated;
        [FixedLengthField(5, 9, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(6, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _timeCreated = value;
            }
        }

        private string _programId;
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ProgramId
        {
            get { return _programId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _programId = value;
            }
        }

        private string _userId;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // Case number
        private string _caseNumber;
        [FixedLengthField(9, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string CaseNumber
        {
            get { return _caseNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _caseNumber = value;
            }
        }

        // Used by New Balance
        // Company number
        private string _company;
        [FixedLengthField(10, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // Warehouse, "22" for Lawrence, "33" for Ontario
        private string _division;
        [FixedLengthField(11, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(12, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        // First 2 positions of Style
        private string _seasonYear;
        [FixedLengthField(13, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        // Last 7 positions of Style
        private string _style;
        [FixedLengthField(14, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(15, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        // Width/Color
        private string _color;
        [FixedLengthField(16, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(17, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(18, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        [FixedLengthField(19, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(20, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(21, 2, PaddingChar = '0', Padding = Padding.Left)]
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
        // Only for WOs.  A unique one up sequence number (needed for manufacturing ASNs b/c some cases have the same SKU for different work orders).
        private int _skuSequenceNumber;
        [FixedLengthField(22, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int SkuSequenceNumber
        {
            get { return _skuSequenceNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _skuSequenceNumber = value;
            }
        }

        // Used by New Balance
        // Product type, "F" for finished goods
        private string _inventoryType;
        [FixedLengthField(23, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(24, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        // If not a DOB this is blanks.  If the PO/WO is a DOB this must be populated with the corresponding PO or WO.  For POs prefix is "P-" for WOs prefix is "W-".
        private string _batchNumber;
        [FixedLengthField(25, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string BatchNumber
        {
            get { return _batchNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _batchNumber = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(26, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(27, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(28, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(29, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(30, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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

        private string _sizeDescription;
        [FixedLengthField(32, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SizeDescription
        {
            get { return _sizeDescription; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _sizeDescription = value;
            }
        }

        private long _originalQuantity;
        [FixedLengthField(33, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long OriginalQuantity_Backing
        {
            get { return _originalQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _originalQuantity = value;
            }
        }
        public decimal OriginalQuantity
        {
            get { return OriginalQuantity_Backing / 10000.0m; }
            set { OriginalQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _quantity;
        [FixedLengthField(34, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long Quantity_Backing
        {
            get { return _quantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _quantity = value;
            }
        }
        public decimal Quantity
        {
            get { return Quantity_Backing / 10000.0m; }
            set { Quantity_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Case quantity
        private long _shippedAsnQuantity;
        [FixedLengthField(35, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long ShippedAsnQuantity_Backing
        {
            get { return _shippedAsnQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _shippedAsnQuantity = value;
            }
        }
        public decimal ShippedAsnQuantity
        {
            get { return ShippedAsnQuantity_Backing / 10000.0m; }
            set { ShippedAsnQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _stdCaseQuantity;
        [FixedLengthField(36, 11, PaddingChar = '0', Padding = Padding.Left)]
        public long StdCaseQuantity_Backing
        {
            get { return _stdCaseQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _stdCaseQuantity = value;
            }
        }
        public decimal StdCaseQuantity
        {
            get { return StdCaseQuantity_Backing / 10000.0m; }
            set { StdCaseQuantity_Backing = (int)(value * 10000.0m); }
        }

        private string _colorShade;
        [FixedLengthField(37, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ColorShade
        {
            get { return _colorShade; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _colorShade = value;
            }
        }

        private string _packageType;
        [FixedLengthField(38, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PackageType
        {
            get { return _packageType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _packageType = value;
            }
        }

        private string _conveyable;
        [FixedLengthField(39, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Conveyable
        {
            get { return _conveyable; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _conveyable = value;
            }
        }

        private string _dataSheetVersion;
        [FixedLengthField(40, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string DataSheetVersion
        {
            get { return _dataSheetVersion; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _dataSheetVersion = value;
            }
        }

        private string _dcOrderNumber;
        [FixedLengthField(41, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string DcOrderNumber
        {
            get { return _dcOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _dcOrderNumber = value;
            }
        }

        private string _workOrderNumber;
        [FixedLengthField(42, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string WorkOrderNumber
        {
            get { return _workOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _workOrderNumber = value;
            }
        }

        private string _manufacturingPlant;
        [FixedLengthField(43, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ManufacturingPlant
        {
            get { return _manufacturingPlant; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _manufacturingPlant = value;
            }
        }

        private string _cutNumber;
        [FixedLengthField(44, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string CutNumber
        {
            get { return _cutNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _cutNumber = value;
            }
        }

        private string _consumeCasePriority;
        [FixedLengthField(45, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ConsumeCasePriority
        {
            get { return _consumeCasePriority; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _consumeCasePriority = value;
            }
        }

        private int _consumePriorityDate;
        [FixedLengthField(46, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ConsumePriorityDate
        {
            get { return _consumePriorityDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _consumePriorityDate = value;
            }
        }

        private int _manufacturingDate;
        [FixedLengthField(47, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ManufacturingDate
        {
            get { return _manufacturingDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _manufacturingDate = value;
            }
        }

        private string _receiveFlag;
        [FixedLengthField(48, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ReceiveFlag
        {
            get { return _receiveFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _receiveFlag = value;
            }
        }

        private string _processImmdNeeds;
        [FixedLengthField(49, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ProcessImmdNeeds
        {
            get { return _processImmdNeeds; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _processImmdNeeds = value;
            }
        }

        private int _stdCostPerUnit;
        [FixedLengthField(50, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StdCostPerUnit_Backing
        {
            get { return _stdCostPerUnit; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _stdCostPerUnit = value;
            }
        }
        public decimal StdCostPerUnit
        {
            get { return StdCostPerUnit_Backing / 100.0m; }
            set { StdCostPerUnit_Backing = (int)(value * 100.0m); }
        }

        private int _addOnCostPerUnit;
        [FixedLengthField(51, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int AddOnCostPerUnit_Backing
        {
            get { return _addOnCostPerUnit; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _addOnCostPerUnit = value;
            }
        }
        public decimal AddOnCostPerUnit
        {
            get { return AddOnCostPerUnit_Backing / 100.0m; }
            set { AddOnCostPerUnit_Backing = (int)(value * 100.0m); }
        }

        private int _currentCostPerUnit;
        [FixedLengthField(52, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CurrentCostPerUnit_Backing
        {
            get { return _currentCostPerUnit; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _currentCostPerUnit = value;
            }
        }
        public decimal CurrentCostPerUnit
        {
            get { return CurrentCostPerUnit_Backing / 100.0m; }
            set { CurrentCostPerUnit_Backing = (int)(value * 100.0m); }
        }

        private int _sellingPricePerUnit;
        [FixedLengthField(53, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int SellingPricePerUnit_Backing
        {
            get { return _sellingPricePerUnit; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _sellingPricePerUnit = value;
            }
        }
        public decimal SellingPricePerUnit
        {
            get { return SellingPricePerUnit_Backing / 100.0m; }
            set { SellingPricePerUnit_Backing = (int)(value * 100.0m); }
        }

        private int _currentInvValue;
        [FixedLengthField(54, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CurrentInvValue_Backing
        {
            get { return _currentInvValue; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _currentInvValue = value;
            }
        }
        public decimal CurrentInvValue
        {
            get { return CurrentInvValue_Backing / 100.0m; }
            set { CurrentInvValue_Backing = (int)(value * 100.0m); }
        }

        private string _prePackGroupCode;
        [FixedLengthField(55, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PrePackGroupCode
        {
            get { return _prePackGroupCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _prePackGroupCode = value;
            }
        }

        private string _assortmentNumber;
        [FixedLengthField(56, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string AssortmentNumber
        {
            get { return _assortmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _assortmentNumber = value;
            }
        }

        private long _innerPackQuantity;
        [FixedLengthField(57, 11, PaddingChar = '0', Padding = Padding.Left)]
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

        private long _volume;
        [FixedLengthField(58, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long Volume_Backing
        {
            get { return _volume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _volume = value;
            }
        }
        public decimal Volume
        {
            get { return Volume_Backing / 100000.0m; }
            set { Volume_Backing = (int)(value * 100000.0m); }
        }

        private long _estimatedWeight;
        [FixedLengthField(59, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long EstimatedWeight_Backing
        {
            get { return _estimatedWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _estimatedWeight = value;
            }
        }
        public decimal EstimatedWeight
        {
            get { return EstimatedWeight_Backing / 100000.0m; }
            set { EstimatedWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _actualWeight;
        [FixedLengthField(60, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long ActualWeight_Backing
        {
            get { return _actualWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _actualWeight = value;
            }
        }
        public decimal ActualWeight
        {
            get { return ActualWeight_Backing / 100000.0m; }
            set { ActualWeight_Backing = (int)(value * 100000.0m); }
        }

        private string _caseType;
        [FixedLengthField(61, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CaseType
        {
            get { return _caseType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _caseType = value;
            }
        }

        private string _caseSize;
        [FixedLengthField(62, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CaseSize
        {
            get { return _caseSize; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _caseSize = value;
            }
        }

        private string _palletSizeType;
        [FixedLengthField(63, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PalletSizeType
        {
            get { return _palletSizeType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _palletSizeType = value;
            }
        }

        private int _unitLength;
        [FixedLengthField(64, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int UnitLength_Backing
        {
            get { return _unitLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _unitLength = value;
            }
        }
        public decimal UnitLength
        {
            get { return UnitLength_Backing / 100.0m; }
            set { UnitLength_Backing = (int)(value * 100.0m); }
        }

        private int _unitWidth;
        [FixedLengthField(65, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int UnitWidth_Backing
        {
            get { return _unitWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _unitWidth = value;
            }
        }
        public decimal UnitWidth
        {
            get { return UnitWidth_Backing / 100.0m; }
            set { UnitWidth_Backing = (int)(value * 100.0m); }
        }

        private int _unitHeight;
        [FixedLengthField(66, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int UnitHeight_Backing
        {
            get { return _unitHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _unitHeight = value;
            }
        }
        public decimal UnitHeight
        {
            get { return UnitHeight_Backing / 100.0m; }
            set { UnitHeight_Backing = (int)(value * 100.0m); }
        }

        private long _unitWeight;
        [FixedLengthField(67, 13, PaddingChar = '0', Padding = Padding.Left)]
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

        private int _innerPackLength;
        [FixedLengthField(68, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int InnerPackLength_Backing
        {
            get { return _innerPackLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _innerPackLength = value;
            }
        }
        public decimal InnerPackLength
        {
            get { return InnerPackLength_Backing / 100.0m; }
            set { InnerPackLength_Backing = (int)(value * 100.0m); }
        }

        private int _innerPackWidth;
        [FixedLengthField(69, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int InnerPackWidth_Backing
        {
            get { return _innerPackWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _innerPackWidth = value;
            }
        }
        public decimal InnerPackWidth
        {
            get { return InnerPackWidth_Backing / 100.0m; }
            set { InnerPackWidth_Backing = (int)(value * 100.0m); }
        }

        private int _innerPackHeight;
        [FixedLengthField(70, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int InnerPackHeight_Backing
        {
            get { return _innerPackHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _innerPackHeight = value;
            }
        }
        public decimal InnerPackHeight
        {
            get { return InnerPackHeight_Backing / 100.0m; }
            set { InnerPackHeight_Backing = (int)(value * 100.0m); }
        }

        private long _innerPackWeight;
        [FixedLengthField(71, 13, PaddingChar = '0', Padding = Padding.Left)]
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

        private int _caseLength;
        [FixedLengthField(72, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CaseLength_Backing
        {
            get { return _caseLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _caseLength = value;
            }
        }
        public decimal CaseLength
        {
            get { return CaseLength_Backing / 100.0m; }
            set { CaseLength_Backing = (int)(value * 100.0m); }
        }

        private int _caseWidth;
        [FixedLengthField(73, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CaseWidth_Backing
        {
            get { return _caseWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _caseWidth = value;
            }
        }
        public decimal CaseWidth
        {
            get { return CaseWidth_Backing / 100.0m; }
            set { CaseWidth_Backing = (int)(value * 100.0m); }
        }

        private int _caseHeight;
        [FixedLengthField(74, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CaseHeight_Backing
        {
            get { return _caseHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _caseHeight = value;
            }
        }
        public decimal CaseHeight
        {
            get { return CaseHeight_Backing / 100.0m; }
            set { CaseHeight_Backing = (int)(value * 100.0m); }
        }

        private int _palletLength;
        [FixedLengthField(75, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PalletLength_Backing
        {
            get { return _palletLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _palletLength = value;
            }
        }
        public decimal PalletLength
        {
            get { return PalletLength_Backing / 100.0m; }
            set { PalletLength_Backing = (int)(value * 100.0m); }
        }

        private int _palletWidth;
        [FixedLengthField(76, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PalletWidth_Backing
        {
            get { return _palletWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _palletWidth = value;
            }
        }
        public decimal PalletWidth
        {
            get { return PalletWidth_Backing / 100.0m; }
            set { PalletWidth_Backing = (int)(value * 100.0m); }
        }

        private int _palletHeight;
        [FixedLengthField(77, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int PalletHeight_Backing
        {
            get { return _palletHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _palletHeight = value;
            }
        }
        public decimal PalletHeight
        {
            get { return PalletHeight_Backing / 100.0m; }
            set { PalletHeight_Backing = (int)(value * 100.0m); }
        }

        private string _manifestNumber;
        [FixedLengthField(78, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ManifestNumber
        {
            get { return _manifestNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _manifestNumber = value;
            }
        }

        private string _manifestType;
        [FixedLengthField(79, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ManifestType
        {
            get { return _manifestType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _manifestType = value;
            }
        }

        // Used by New Balance
        // Container number
        private string _shipmentNumber;
        [FixedLengthField(80, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShipmentNumber
        {
            get { return _shipmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipmentNumber = value;
            }
        }

        // Used by New Balance
        // PO or WO number, with appropriate prefix of "P-" or "W-"
        private string _purchaseOrderNumber;
        [FixedLengthField(81, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PurchaseOrderNumber
        {
            get { return _purchaseOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderNumber = value;
            }
        }

        // Used by New Balance
        // Unique line number.  For POs: configured by a 3 position prefix which is a one-up counter, matched together with the 3 position Host PO Line.  Ex. Counter is equal to 7 and case is for PO Line 4: '007004'.  Work Orders have the same value as IDSEQN.
        private int _purchaseOrderLineNumber;
        [FixedLengthField(82, 6, PaddingChar = '0', Padding = Padding.Left)]
        public int PurchaseOrderLineNumber
        {
            get { return _purchaseOrderLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 6) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderLineNumber = value;
            }
        }

        private string _shipVia;
        [FixedLengthField(83, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ShipVia
        {
            get { return _shipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipVia = value;
            }
        }

        private string _trailerNumber;
        [FixedLengthField(84, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string TrailerNumber
        {
            get { return _trailerNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _trailerNumber = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _warehouseTransferFlag;
        [FixedLengthField(85, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string WarehouseTransferFlag
        {
            get { return _warehouseTransferFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _warehouseTransferFlag = value;
            }
        }

        // Used by New Balance
        // Always "00"
        private string _statusCode;
        [FixedLengthField(86, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _statusCode = value;
            }
        }

        private int _statusDate;
        [FixedLengthField(87, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int StatusDate
        {
            get { return _statusDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _statusDate = value;
            }
        }

        private int _statusTime;
        [FixedLengthField(88, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int StatusTime
        {
            get { return _statusTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _statusTime = value;
            }
        }

        private string _receivedFrom;
        [FixedLengthField(89, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ReceivedFrom
        {
            get { return _receivedFrom; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _receivedFrom = value;
            }
        }

        private int _receivedDate;
        [FixedLengthField(90, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ReceivedDate
        {
            get { return _receivedDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _receivedDate = value;
            }
        }

        private string _vendorId;
        [FixedLengthField(91, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string VendorId
        {
            get { return _vendorId; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _vendorId = value;
            }
        }

        private string _vendorContainerNumber;
        [FixedLengthField(92, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string VendorContainerNumber
        {
            get { return _vendorContainerNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _vendorContainerNumber = value;
            }
        }

        // Used by New Balance
        // Warehouse, "22" for Lawrence, "33" for Ontario
        private string _warehouse;
        [FixedLengthField(93, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        private string _area;
        [FixedLengthField(94, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(95, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(96, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(97, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(98, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(99, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string Position
        {
            get { return _position; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _position = value;
            }
        }

        private string _locationType;
        [FixedLengthField(100, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string LocationType
        {
            get { return _locationType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _locationType = value;
            }
        }

        private string _putawayZone;
        [FixedLengthField(101, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PutawayZone
        {
            get { return _putawayZone; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _putawayZone = value;
            }
        }

        // Used by New Balance
        // If a demo "I".  If a DOB "DO".  All others are blanks.
        private string _putawayType;
        [FixedLengthField(102, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PutawayType
        {
            get { return _putawayType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _putawayType = value;
            }
        }

        private string _previousArea;
        [FixedLengthField(103, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousArea
        {
            get { return _previousArea; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousArea = value;
            }
        }

        private string _previousZone;
        [FixedLengthField(104, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousZone
        {
            get { return _previousZone; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousZone = value;
            }
        }

        private string _previousAisle;
        [FixedLengthField(105, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousAisle
        {
            get { return _previousAisle; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousAisle = value;
            }
        }

        private string _previousBay;
        [FixedLengthField(106, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousBay
        {
            get { return _previousBay; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousBay = value;
            }
        }

        private string _previousLevel;
        [FixedLengthField(107, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousLevel
        {
            get { return _previousLevel; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousLevel = value;
            }
        }

        private string _previousPosition;
        [FixedLengthField(108, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PreviousPosition
        {
            get { return _previousPosition; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _previousPosition = value;
            }
        }

        private string _locnCaseIndicator;
        [FixedLengthField(109, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string LocnCaseIndicator
        {
            get { return _locnCaseIndicator; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _locnCaseIndicator = value;
            }
        }

        private string _locnSequencingCode;
        [FixedLengthField(110, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string LocnSequencingCode
        {
            get { return _locnSequencingCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _locnSequencingCode = value;
            }
        }

        private string _palletId;
        [FixedLengthField(111, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PalletId
        {
            get { return _palletId; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _palletId = value;
            }
        }

        private string _palletType;
        [FixedLengthField(112, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PalletType
        {
            get { return _palletType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _palletType = value;
            }
        }

        private string _singleSkuCase;
        [FixedLengthField(113, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SingleSkuCase
        {
            get { return _singleSkuCase; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _singleSkuCase = value;
            }
        }

        private string _inventoryLockCode1;
        [FixedLengthField(114, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string InventoryLockCode1
        {
            get { return _inventoryLockCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _inventoryLockCode1 = value;
            }
        }

        private string _inventoryLockCode2;
        [FixedLengthField(115, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string InventoryLockCode2
        {
            get { return _inventoryLockCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _inventoryLockCode2 = value;
            }
        }

        private string _inventoryLockCode3;
        [FixedLengthField(116, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string InventoryLockCode3
        {
            get { return _inventoryLockCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _inventoryLockCode3 = value;
            }
        }

        private string _inventoryLockCode4;
        [FixedLengthField(117, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string InventoryLockCode4
        {
            get { return _inventoryLockCode4; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _inventoryLockCode4 = value;
            }
        }

        private string _inventoryLockCode5;
        [FixedLengthField(118, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string InventoryLockCode5
        {
            get { return _inventoryLockCode5; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _inventoryLockCode5 = value;
            }
        }

        private string _reworkCode;
        [FixedLengthField(119, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReworkCode
        {
            get { return _reworkCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reworkCode = value;
            }
        }

        private string _qualityHeldCode;
        [FixedLengthField(120, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string QualityHeldCode
        {
            get { return _qualityHeldCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _qualityHeldCode = value;
            }
        }

        private long _miscellaneousNumericField1;
        [FixedLengthField(121, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MiscellaneousNumericField1_Backing
        {
            get { return _miscellaneousNumericField1; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField1 = value;
            }
        }
        public decimal MiscellaneousNumericField1
        {
            get { return MiscellaneousNumericField1_Backing / 100000.0m; }
            set { MiscellaneousNumericField1_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumericField2;
        [FixedLengthField(122, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MiscellaneousNumericField2_Backing
        {
            get { return _miscellaneousNumericField2; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField2 = value;
            }
        }
        public decimal MiscellaneousNumericField2
        {
            get { return MiscellaneousNumericField2_Backing / 100000.0m; }
            set { MiscellaneousNumericField2_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNumericField3;
        [FixedLengthField(123, 13, PaddingChar = '0', Padding = Padding.Left)]
        public long MiscellaneousNumericField3_Backing
        {
            get { return _miscellaneousNumericField3; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField3 = value;
            }
        }
        public decimal MiscellaneousNumericField3
        {
            get { return MiscellaneousNumericField3_Backing / 100000.0m; }
            set { MiscellaneousNumericField3_Backing = (int)(value * 100000.0m); }
        }

        private string _specialInstructionCode1;
        [FixedLengthField(124, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(125, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(126, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(127, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(128, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode5
        {
            get { return _specialInstructionCode5; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode5 = value;
            }
        }

        private string _caseDivertCode;
        [FixedLengthField(129, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string CaseDivertCode
        {
            get { return _caseDivertCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _caseDivertCode = value;
            }
        }

        private string _reasonCode;
        [FixedLengthField(130, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode
        {
            get { return _reasonCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode = value;
            }
        }

        private string _caseLabelType;
        [FixedLengthField(131, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CaseLabelType
        {
            get { return _caseLabelType; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _caseLabelType = value;
            }
        }

        private string _pathNumber;
        [FixedLengthField(132, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private string _keyrecRecordNumber;
        [FixedLengthField(133, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string KeyrecRecordNumber
        {
            get { return _keyrecRecordNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _keyrecRecordNumber = value;
            }
        }

        private string _shipmentControlFlag;
        [FixedLengthField(134, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShipmentControlFlag
        {
            get { return _shipmentControlFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipmentControlFlag = value;
            }
        }

        private string _auditFlag;
        [FixedLengthField(135, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AuditFlag
        {
            get { return _auditFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _auditFlag = value;
            }
        }

        private string _conditionCode;
        [FixedLengthField(136, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ConditionCode
        {
            get { return _conditionCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _conditionCode = value;
            }
        }

        private string _pixReference1;
        [FixedLengthField(137, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PixReference1
        {
            get { return _pixReference1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _pixReference1 = value;
            }
        }

        private string _pixReference2;
        [FixedLengthField(138, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PixReference2
        {
            get { return _pixReference2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _pixReference2 = value;
            }
        }

        private string _pixReference3;
        [FixedLengthField(139, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PixReference3
        {
            get { return _pixReference3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pixReference3 = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(140, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(141, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _vendorAsn;
        [FixedLengthField(142, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string VendorAsn
        {
            get { return _vendorAsn; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _vendorAsn = value;
            }
        }

        private string _ticketType;
        [FixedLengthField(143, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TicketType
        {
            get { return _ticketType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _ticketType = value;
            }
        }

        private string _storeNumber;
        [FixedLengthField(144, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string StoreNumber
        {
            get { return _storeNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeNumber = value;
            }
        }

        private string _distroNumber;
        [FixedLengthField(145, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string DistroNumber
        {
            get { return _distroNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _distroNumber = value;
            }
        }

        private int _manufacturingTime;
        [FixedLengthField(146, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int ManufacturingTime
        {
            get { return _manufacturingTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _manufacturingTime = value;
            }
        }

        private int _incubationDate;
        [FixedLengthField(147, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int IncubationDate
        {
            get { return _incubationDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _incubationDate = value;
            }
        }

        private int _incubationTime;
        [FixedLengthField(148, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int IncubationTime
        {
            get { return _incubationTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _incubationTime = value;
            }
        }

        // Used by New Balance
        // "2" for add or change, "4" for delete
        private string _function;
        [FixedLengthField(149, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Function
        {
            get { return _function; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _function = value;
            }
        }

        private string _caseEpc;
        [FixedLengthField(150, 100, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                                                                    ")]
        public string CaseEpc
        {
            get { return _caseEpc; }
            set
            {
                if(value != default(string) && value.Length > 100) throw new ArgumentOutOfRangeException("value");
                _caseEpc = value;
            }
        }

        private string _palletEpc;
        [FixedLengthField(151, 100, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                                                                    ")]
        public string PalletEpc
        {
            get { return _palletEpc; }
            set
            {
                if(value != default(string) && value.Length > 100) throw new ArgumentOutOfRangeException("value");
                _palletEpc = value;
            }
        }

        private string _invoiceNumber;
        [FixedLengthField(152, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _invoiceNumber = value;
            }
        }

        private string _trackingNumber;
        [FixedLengthField(153, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string TrackingNumber
        {
            get { return _trackingNumber; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _trackingNumber = value;
            }
        }

        private long _multipackQuantity;
        [FixedLengthField(154, 11, PaddingChar = '0', Padding = Padding.Left)]
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

    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
