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
    internal partial class ManhattanSkuDetail
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
        // Always "3"
        private string _asnType;
        [FixedLengthField(6, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AsnType
        {
            get { return _asnType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _asnType = value;
            }
        }

        // Used by New Balance
        // Container number
        private string _shipmentNumber;
        [FixedLengthField(7, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShipmentNumber
        {
            get { return _shipmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipmentNumber = value;
            }
        }

        private string _vendorAsn;
        [FixedLengthField(8, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string VendorAsn
        {
            get { return _vendorAsn; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _vendorAsn = value;
            }
        }

        // Used by New Balance
        // PO with appropriate prefix of "P-"
        private string _purchaseOrderNumber;
        [FixedLengthField(9, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        // PO Line number
        private int _purchaseOrderLineNumber;
        [FixedLengthField(10, 6, PaddingChar = '0', Padding = Padding.Left, NullValue="000000")]
        public int PurchaseOrderLineNumber
        {
            get { return _purchaseOrderLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 6) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderLineNumber = value;
            }
        }

        // Used by New Balance
        // Company number
        private string _company;
        [FixedLengthField(11, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(12, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(13, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(14, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(15, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(17, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(18, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(19, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        [FixedLengthField(20, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(21, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(22, 2, PaddingChar = '0', Padding = Padding.Left, NullValue="00")]
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
        // PO Line number
        private int _sequenceNumber;
        [FixedLengthField(23, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
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
        [FixedLengthField(24, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string SizeDescription
        {
            get { return _sizeDescription; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _sizeDescription = value;
            }
        }

        // Used by New Balance
        // Product type, "F" for finished goods
        private string _inventoryType;
        [FixedLengthField(25, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(26, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        // If not a DOB this is blanks.  If the PO is a DOB this must be populated with the corresponding PO.  For POs prefix is "P-".
        private string _batchNumber;
        [FixedLengthField(27, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
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
        [FixedLengthField(28, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _countryOfOrigin = value;
            }
        }

        private string _skuAttribute1;
        [FixedLengthField(29, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(30, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(31, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(32, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(33, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SkuAttribute5
        {
            get { return _skuAttribute5; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _skuAttribute5 = value;
            }
        }

        private long _innerPackQuantity;
        [FixedLengthField(34, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
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

        private int _casesShipped;
        [FixedLengthField(35, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CasesShipped
        {
            get { return _casesShipped; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _casesShipped = value;
            }
        }

        // Used by New Balance
        // Quantity shipped
        private long _unitsShipped;
        [FixedLengthField(36, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long UnitsShipped_Backing
        {
            get { return _unitsShipped; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _unitsShipped = value;
            }
        }
        public decimal UnitsShipped
        {
            get { return UnitsShipped_Backing / 10000.0m; }
            set { UnitsShipped_Backing = (int)(value * 10000.0m); }
        }

        private long _stdCaseQuantity;
        [FixedLengthField(37, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
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

        private int _vendorTier;
        [FixedLengthField(38, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int VendorTier_Backing
        {
            get { return _vendorTier; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _vendorTier = value;
            }
        }
        public decimal VendorTier
        {
            get { return VendorTier_Backing / 100.0m; }
            set { VendorTier_Backing = (int)(value * 100.0m); }
        }

        private int _vendorHeight;
        [FixedLengthField(39, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int VendorHeight_Backing
        {
            get { return _vendorHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _vendorHeight = value;
            }
        }
        public decimal VendorHeight
        {
            get { return VendorHeight_Backing / 100.0m; }
            set { VendorHeight_Backing = (int)(value * 100.0m); }
        }

        private long _price;
        [FixedLengthField(40, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
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

        private string _ticketType;
        [FixedLengthField(41, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TicketType
        {
            get { return _ticketType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _ticketType = value;
            }
        }

        private string _processImmdNeeds;
        [FixedLengthField(42, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ProcessImmdNeeds
        {
            get { return _processImmdNeeds; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _processImmdNeeds = value;
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

        private int _manufacturingDate;
        [FixedLengthField(44, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ManufacturingDate
        {
            get { return _manufacturingDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _manufacturingDate = value;
            }
        }

        private string _qcHoldUponReceipt;
        [FixedLengthField(45, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string QcHoldUponReceipt
        {
            get { return _qcHoldUponReceipt; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _qcHoldUponReceipt = value;
            }
        }

        private string _purchasingUom;
        [FixedLengthField(46, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PurchasingUom
        {
            get { return _purchasingUom; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _purchasingUom = value;
            }
        }

        private string _shipmentPriority;
        [FixedLengthField(47, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ShipmentPriority
        {
            get { return _shipmentPriority; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shipmentPriority = value;
            }
        }

        private string _pathNumber;
        [FixedLengthField(48, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private long _weight;
        [FixedLengthField(49, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long Weight_Backing
        {
            get { return _weight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _weight = value;
            }
        }
        public decimal Weight
        {
            get { return Weight_Backing / 100000.0m; }
            set { Weight_Backing = (int)(value * 100000.0m); }
        }

        private string _conditionCode;
        [FixedLengthField(50, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ConditionCode
        {
            get { return _conditionCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _conditionCode = value;
            }
        }

        private string _statusCode;
        [FixedLengthField(51, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _statusCode = value;
            }
        }

        private int _manufacturingTime;
        [FixedLengthField(52, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
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
        [FixedLengthField(53, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
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
        [FixedLengthField(54, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int IncubationTime
        {
            get { return _incubationTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _incubationTime = value;
            }
        }

        private string _reference1;
        [FixedLengthField(55, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Reference1
        {
            get { return _reference1; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _reference1 = value;
            }
        }

        private string _reference2;
        [FixedLengthField(56, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Reference2
        {
            get { return _reference2; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _reference2 = value;
            }
        }

        private string _reference3;
        [FixedLengthField(57, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Reference3
        {
            get { return _reference3; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _reference3 = value;
            }
        }

        private string _splInstructionCode1;
        [FixedLengthField(58, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstructionCode1
        {
            get { return _splInstructionCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstructionCode1 = value;
            }
        }

        // Used by New Balance
        // If not a DOB this is blanks.  If the PO is a DOB this must be populated with "DO".
        private string _splInstructionCode2;
        [FixedLengthField(59, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstructionCode2
        {
            get { return _splInstructionCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstructionCode2 = value;
            }
        }

        private string _splInstructionCode3;
        [FixedLengthField(60, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstructionCode3
        {
            get { return _splInstructionCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstructionCode3 = value;
            }
        }

        private string _splInstructionCode4;
        [FixedLengthField(61, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstructionCode4
        {
            get { return _splInstructionCode4; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstructionCode4 = value;
            }
        }

        private string _misc20ByteField1;
        [FixedLengthField(62, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Misc20ByteField1
        {
            get { return _misc20ByteField1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _misc20ByteField1 = value;
            }
        }

        private string _misc20ByteField2;
        [FixedLengthField(63, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Misc20ByteField2
        {
            get { return _misc20ByteField2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _misc20ByteField2 = value;
            }
        }

        private string _misc20ByteField3;
        [FixedLengthField(64, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Misc20ByteField3
        {
            get { return _misc20ByteField3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _misc20ByteField3 = value;
            }
        }

        private string _misc20ByteField4;
        [FixedLengthField(65, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Misc20ByteField4
        {
            get { return _misc20ByteField4; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _misc20ByteField4 = value;
            }
        }

        private long _miscellaneousNumericField1;
        [FixedLengthField(66, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(67, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(68, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private long _miscellaneousNumericField4;
        [FixedLengthField(69, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNumericField4_Backing
        {
            get { return _miscellaneousNumericField4; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNumericField4 = value;
            }
        }
        public decimal MiscellaneousNumericField4
        {
            get { return MiscellaneousNumericField4_Backing / 100000.0m; }
            set { MiscellaneousNumericField4_Backing = (int)(value * 100000.0m); }
        }

        private string _recordExpansionField;
        [FixedLengthField(70, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
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
        [FixedLengthField(71, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        // Used by New Balance
        // "2" for add or change, "4" for delete
        private string _function;
        [FixedLengthField(72, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Function
        {
            get { return _function; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _function = value;
            }
        }

        private int _expireDate;
        [FixedLengthField(73, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ExpireDate
        {
            get { return _expireDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _expireDate = value;
            }
        }

        private string _convToPreOwnSku;
        [FixedLengthField(74, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ConvToPreOwnSku
        {
            get { return _convToPreOwnSku; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _convToPreOwnSku = value;
            }
        }

public int TotalFileLength { get { return 626; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
