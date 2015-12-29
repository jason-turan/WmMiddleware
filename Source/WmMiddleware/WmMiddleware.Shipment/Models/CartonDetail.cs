using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using WmMiddleware.Common.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.Shipment.Models
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class CartonDetail : IGeneratedFlatFile
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

        private string _company;
        [FixedLengthField(6, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
            }
        }

        private string _pickticketControlNumber;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string PickticketControlNumber
        {
            get { return _pickticketControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _pickticketControlNumber = value;
            }
        }

        private string _batchControlNumber;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private string _cartonnumber;
        [FixedLengthField(10, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Cartonnumber
        {
            get { return _cartonnumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _cartonnumber = value;
            }
        }

        private string _referenceCasenumber;
        [FixedLengthField(11, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ReferenceCasenumber
        {
            get { return _referenceCasenumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _referenceCasenumber = value;
            }
        }

        private int _pickticketLineNumber;
        [FixedLengthField(12, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int PickticketLineNumber
        {
            get { return _pickticketLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _pickticketLineNumber = value;
            }
        }

        private int _sizeRelPosnInTable;
        [FixedLengthField(13, 2, PaddingChar = '0', Padding = Padding.Left, NullValue="00")]
        public int SizeRelPosnInTable
        {
            get { return _sizeRelPosnInTable; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _sizeRelPosnInTable = value;
            }
        }

        private int _cartonLineNumber;
        [FixedLengthField(14, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int CartonLineNumber
        {
            get { return _cartonLineNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonLineNumber = value;
            }
        }

        private string _season;
        [FixedLengthField(15, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(16, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(17, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(18, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
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
        [FixedLengthField(19, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
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
        [FixedLengthField(20, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(21, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
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
        [FixedLengthField(22, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        [FixedLengthField(23, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SizeRngeCode
        {
            get { return _sizeRngeCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _sizeRngeCode = value;
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

        private string _customerSku;
        [FixedLengthField(26, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string CustomerSku
        {
            get { return _customerSku; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customerSku = value;
            }
        }

        private string _productStatus;
        [FixedLengthField(27, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ProductStatus
        {
            get { return _productStatus; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _productStatus = value;
            }
        }

        private string _lotNumber;
        [FixedLengthField(28, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string LotNumber
        {
            get { return _lotNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _lotNumber = value;
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

        private string _countryOfOrigin;
        [FixedLengthField(34, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _countryOfOrigin = value;
            }
        }

        private string _preCubeFlag;
        [FixedLengthField(35, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PreCubeFlag
        {
            get { return _preCubeFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _preCubeFlag = value;
            }
        }

        private string _distroType;
        [FixedLengthField(36, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DistroType
        {
            get { return _distroType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _distroType = value;
            }
        }

        private string _distronumber;
        [FixedLengthField(37, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string Distronumber
        {
            get { return _distronumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _distronumber = value;
            }
        }

        private string _packageBarcode;
        [FixedLengthField(38, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PackageBarcode
        {
            get { return _packageBarcode; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _packageBarcode = value;
            }
        }

        private long _toBePackedUnits;
        [FixedLengthField(39, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long ToBePackedUnits_Backing
        {
            get { return _toBePackedUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _toBePackedUnits = value;
            }
        }
        public decimal ToBePackedUnits
        {
            get { return ToBePackedUnits_Backing / 10000.0m; }
            set { ToBePackedUnits_Backing = (int)(value * 10000.0m); }
        }

        private int _toBePackedBoxes;
        [FixedLengthField(40, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int ToBePackedBoxes
        {
            get { return _toBePackedBoxes; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _toBePackedBoxes = value;
            }
        }

        private long _unitsPacked;
        [FixedLengthField(41, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long UnitsPacked_Backing
        {
            get { return _unitsPacked; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _unitsPacked = value;
            }
        }
        public decimal UnitsPacked
        {
            get { return UnitsPacked_Backing / 10000.0m; }
            set { UnitsPacked_Backing = (int)(value * 10000.0m); }
        }

        private int _boxesPacked;
        [FixedLengthField(42, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int BoxesPacked
        {
            get { return _boxesPacked; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _boxesPacked = value;
            }
        }

        private long _deliveredUnits;
        [FixedLengthField(43, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long DeliveredUnits_Backing
        {
            get { return _deliveredUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _deliveredUnits = value;
            }
        }
        public decimal DeliveredUnits
        {
            get { return DeliveredUnits_Backing / 10000.0m; }
            set { DeliveredUnits_Backing = (int)(value * 10000.0m); }
        }

        private long _cancelQuantity;
        [FixedLengthField(44, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
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

        private string _reasonCode1;
        [FixedLengthField(45, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode1
        {
            get { return _reasonCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode1 = value;
            }
        }

        private string _reasonCode2;
        [FixedLengthField(46, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode2
        {
            get { return _reasonCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode2 = value;
            }
        }

        private string _reasonCode3;
        [FixedLengthField(47, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode3
        {
            get { return _reasonCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode3 = value;
            }
        }

        private string _reasonCode4;
        [FixedLengthField(48, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode4
        {
            get { return _reasonCode4; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode4 = value;
            }
        }

        private string _reasonCode5;
        [FixedLengthField(49, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReasonCode5
        {
            get { return _reasonCode5; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode5 = value;
            }
        }

        private string _assortmentNumber;
        [FixedLengthField(50, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string AssortmentNumber
        {
            get { return _assortmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _assortmentNumber = value;
            }
        }

        private string _palletId;
        [FixedLengthField(51, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PalletId
        {
            get { return _palletId; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _palletId = value;
            }
        }

        private string _pickerId;
        [FixedLengthField(52, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string PickerId
        {
            get { return _pickerId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _pickerId = value;
            }
        }

        private string _packerId;
        [FixedLengthField(53, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string PackerId
        {
            get { return _packerId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _packerId = value;
            }
        }

        private string _minorPickticketControlNumber;
        [FixedLengthField(54, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MinorPickticketControlNumber
        {
            get { return _minorPickticketControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _minorPickticketControlNumber = value;
            }
        }

        private string _masterShipmentId;
        [FixedLengthField(55, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MasterShipmentId
        {
            get { return _masterShipmentId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _masterShipmentId = value;
            }
        }

        private string _customerPonumber;
        [FixedLengthField(56, 26, PaddingChar = ' ', Padding = Padding.Right, NullValue="                          ")]
        public string CustomerPonumber
        {
            get { return _customerPonumber; }
            set
            {
                if(value != default(string) && value.Length > 26) throw new ArgumentOutOfRangeException("value");
                _customerPonumber = value;
            }
        }

        private string _miscellaneous10Byte1;
        [FixedLengthField(57, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Miscellaneous10Byte1
        {
            get { return _miscellaneous10Byte1; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneous10Byte1 = value;
            }
        }

        private string _miscellaneous20Byte1;
        [FixedLengthField(58, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Miscellaneous20Byte1
        {
            get { return _miscellaneous20Byte1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneous20Byte1 = value;
            }
        }

        private string _miscellaneousIns5Byte1;
        [FixedLengthField(59, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(60, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(61, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(62, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte4
        {
            get { return _miscellaneousIns5Byte4; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte4 = value;
            }
        }

        private string _miscellaneousIns10Byte2;
        [FixedLengthField(63, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(64, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(65, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte4
        {
            get { return _miscellaneousIns10Byte4; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte4 = value;
            }
        }

        private string _miscellaneousIns10Byte5;
        [FixedLengthField(66, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte5
        {
            get { return _miscellaneousIns10Byte5; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte5 = value;
            }
        }

        private string _miscellaneousIns20Byte2;
        [FixedLengthField(67, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte2
        {
            get { return _miscellaneousIns20Byte2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte2 = value;
            }
        }

        private string _miscellaneousIns20Byte3;
        [FixedLengthField(68, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte3
        {
            get { return _miscellaneousIns20Byte3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte3 = value;
            }
        }

        private string _miscellaneousIns20Byte4;
        [FixedLengthField(69, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte4
        {
            get { return _miscellaneousIns20Byte4; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte4 = value;
            }
        }

        private string _miscellaneousIns20Byte5;
        [FixedLengthField(70, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte5
        {
            get { return _miscellaneousIns20Byte5; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte5 = value;
            }
        }

        private long _miscellaneousNum1;
        [FixedLengthField(71, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(72, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(73, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(74, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(75, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private long _miscellaneousNum6;
        [FixedLengthField(76, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum6_Backing
        {
            get { return _miscellaneousNum6; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum6 = value;
            }
        }
        public decimal MiscellaneousNum6
        {
            get { return MiscellaneousNum6_Backing / 100000.0m; }
            set { MiscellaneousNum6_Backing = (int)(value * 100000.0m); }
        }

        private string _pathNumber;
        [FixedLengthField(77, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private string _shortDescription1;
        [FixedLengthField(78, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShortDescription1
        {
            get { return _shortDescription1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription1 = value;
            }
        }

        private string _shortDescription2;
        [FixedLengthField(79, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShortDescription2
        {
            get { return _shortDescription2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription2 = value;
            }
        }

        private string _shortDescription3;
        [FixedLengthField(80, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShortDescription3
        {
            get { return _shortDescription3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription3 = value;
            }
        }

        private string _shortDescription4;
        [FixedLengthField(81, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShortDescription4
        {
            get { return _shortDescription4; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription4 = value;
            }
        }

        private string _shortDescription5;
        [FixedLengthField(82, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShortDescription5
        {
            get { return _shortDescription5; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription5 = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(83, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
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
        [FixedLengthField(84, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        public int TotalFileLength { get { return 868; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
