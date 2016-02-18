using System;
using System.Globalization;
using Dapper.Contrib.Extensions;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using Middleware.Wm.Manhattan.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Middleware.Wm.Manhattan.Shipment
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    [Table("ManhattanShipmentLineItem")]
    public partial class ManhattanShipmentLineItem : IGeneratedFlatFile
    {
        [Key]
        public int ManhattanShipmentLineItemId { get; set; }

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

        private string _shippedCompany;
        [FixedLengthField(6, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ShippedCompany
        {
            get { return _shippedCompany; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _shippedCompany = value;
            }
        }

        private string _shippedDivision;
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ShippedDivision
        {
            get { return _shippedDivision; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _shippedDivision = value;
            }
        }

        private string _pickticketControlNumber;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string PickticketControlNumber
        {
            get { return _pickticketControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _pickticketControlNumber = value;
            }
        }

        private int _pickticketLineNumber;
        [FixedLengthField(9, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int PickticketLineNumber
        {
            get { return _pickticketLineNumber; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _pickticketLineNumber = value;
            }
        }

        private int _shippedSizePosn;
        [FixedLengthField(10, 2, PaddingChar = '0', Padding = Padding.Left, NullValue = "00")]
        public int ShippedSizePosn
        {
            get { return _shippedSizePosn; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _shippedSizePosn = value;
            }
        }

        private string _shippedSeason;
        [FixedLengthField(11, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ShippedSeason
        {
            get { return _shippedSeason; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shippedSeason = value;
            }
        }

        private string _shippedSeasonYear;
        [FixedLengthField(12, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ShippedSeasonYear
        {
            get { return _shippedSeasonYear; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shippedSeasonYear = value;
            }
        }

        private string _shippedStyle;
        [FixedLengthField(13, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string ShippedStyle
        {
            get { return _shippedStyle; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _shippedStyle = value;
            }
        }

        private string _shippedStyleSuffix;
        [FixedLengthField(14, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string ShippedStyleSuffix
        {
            get { return _shippedStyleSuffix; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _shippedStyleSuffix = value;
            }
        }

        private string _shippedColor;
        [FixedLengthField(15, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShippedColor
        {
            get { return _shippedColor; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shippedColor = value;
            }
        }

        private string _shippedColorSuffix;
        [FixedLengthField(16, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ShippedColorSuffix
        {
            get { return _shippedColorSuffix; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shippedColorSuffix = value;
            }
        }

        private string _shippedSecDimn;
        [FixedLengthField(17, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string ShippedSecDimn
        {
            get { return _shippedSecDimn; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippedSecDimn = value;
            }
        }

        private string _shippedQuality;
        [FixedLengthField(18, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ShippedQuality
        {
            get { return _shippedQuality; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shippedQuality = value;
            }
        }

        private string _lotNumber;
        [FixedLengthField(19, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string LotNumber
        {
            get { return _lotNumber; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _lotNumber = value;
            }
        }

        private long _pickticketQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(20, 11, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000000000")]
        public long PickticketQuantity_Backing
        {
            get { return _pickticketQuantity; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _pickticketQuantity = value;
            }
        }
        public decimal PickticketQuantity
        {
            get { return PickticketQuantity_Backing / 10000.0m; }
            set { PickticketQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _shippedQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(21, 11, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000000000")]
        public long ShippedQuantity_Backing
        {
            get { return _shippedQuantity; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _shippedQuantity = value;
            }
        }
        public decimal ShippedQuantity
        {
            get { return ShippedQuantity_Backing / 10000.0m; }
            set { ShippedQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _deliveredUnits;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(22, 11, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000000000")]
        public long DeliveredUnits_Backing
        {
            get { return _deliveredUnits; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _deliveredUnits = value;
            }
        }
        public decimal DeliveredUnits
        {
            get { return DeliveredUnits_Backing / 10000.0m; }
            set { DeliveredUnits_Backing = (int)(value * 10000.0m); }
        }

        private string _reasonCode1;
        [FixedLengthField(23, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode1
        {
            get { return _reasonCode1; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode1 = value;
            }
        }

        private string _reasonCode2;
        [FixedLengthField(24, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode2
        {
            get { return _reasonCode2; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode2 = value;
            }
        }

        private string _reasonCode3;
        [FixedLengthField(25, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode3
        {
            get { return _reasonCode3; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode3 = value;
            }
        }

        private string _reasonCode4;
        [FixedLengthField(26, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode4
        {
            get { return _reasonCode4; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode4 = value;
            }
        }

        private string _reasonCode5;
        [FixedLengthField(27, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode5
        {
            get { return _reasonCode5; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode5 = value;
            }
        }

        private string _shippedSizeCode;
        [FixedLengthField(28, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShippedSizeCode
        {
            get { return _shippedSizeCode; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shippedSizeCode = value;
            }
        }

        private string _shippedSizeDescription;
        [FixedLengthField(29, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string ShippedSizeDescription
        {
            get { return _shippedSizeDescription; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _shippedSizeDescription = value;
            }
        }

        private string _packageBarcode;
        [FixedLengthField(30, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string PackageBarcode
        {
            get { return _packageBarcode; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _packageBarcode = value;
            }
        }

        private string _customerSku;
        [FixedLengthField(31, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string CustomerSku
        {
            get { return _customerSku; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _customerSku = value;
            }
        }

        private string _prePackGroupCode;
        [FixedLengthField(32, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string PrePackGroupCode
        {
            get { return _prePackGroupCode; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _prePackGroupCode = value;
            }
        }

        private string _assortmentNumber;
        [FixedLengthField(33, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue = "            ")]
        public string AssortmentNumber
        {
            get { return _assortmentNumber; }
            set
            {
                if (value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _assortmentNumber = value;
            }
        }

        private long _numberUnitsInPrepack;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(34, 11, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000000000")]
        public long NumberUnitsInPrepack_Backing
        {
            get { return _numberUnitsInPrepack; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _numberUnitsInPrepack = value;
            }
        }
        public decimal NumberUnitsInPrepack
        {
            get { return NumberUnitsInPrepack_Backing / 10000.0m; }
            set { NumberUnitsInPrepack_Backing = (int)(value * 10000.0m); }
        }

        private string _priceTicketType;
        [FixedLengthField(35, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string PriceTicketType
        {
            get { return _priceTicketType; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _priceTicketType = value;
            }
        }

        private string _areaOutboundOnly;
        [FixedLengthField(36, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string AreaOutboundOnly
        {
            get { return _areaOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _areaOutboundOnly = value;
            }
        }

        private string _zoneOutboundOnly;
        [FixedLengthField(37, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ZoneOutboundOnly
        {
            get { return _zoneOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _zoneOutboundOnly = value;
            }
        }

        private string _aisleOutboundOnly;
        [FixedLengthField(38, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string AisleOutboundOnly
        {
            get { return _aisleOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _aisleOutboundOnly = value;
            }
        }

        private string _bayOutboundOnly;
        [FixedLengthField(39, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string BayOutboundOnly
        {
            get { return _bayOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _bayOutboundOnly = value;
            }
        }

        private string _levelOutboundOnly;
        [FixedLengthField(40, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string LevelOutboundOnly
        {
            get { return _levelOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _levelOutboundOnly = value;
            }
        }

        private string _positionOutboundOnly;
        [FixedLengthField(41, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string PositionOutboundOnly
        {
            get { return _positionOutboundOnly; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _positionOutboundOnly = value;
            }
        }

        private string _distroType;
        [FixedLengthField(42, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string DistroType
        {
            get { return _distroType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _distroType = value;
            }
        }

        private string _distronumber;
        [FixedLengthField(43, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue = "            ")]
        public string Distronumber
        {
            get { return _distronumber; }
            set
            {
                if (value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _distronumber = value;
            }
        }

        private string _storeNumber;
        [FixedLengthField(44, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string StoreNumber
        {
            get { return _storeNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeNumber = value;
            }
        }

        private string _taxable;
        [FixedLengthField(45, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string Taxable
        {
            get { return _taxable; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _taxable = value;
            }
        }

        private int _taxPercentage;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(46, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int TaxPercentage_Backing
        {
            get { return _taxPercentage; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _taxPercentage = value;
            }
        }
        public decimal TaxPercentage
        {
            get { return TaxPercentage_Backing / 100.0m; }
            set { TaxPercentage_Backing = (int)(value * 100.0m); }
        }

        private string _supprprtAmounts;
        [FixedLengthField(47, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SupprprtAmounts
        {
            get { return _supprprtAmounts; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _supprprtAmounts = value;
            }
        }

        private string _specialInstructionCode1;
        [FixedLengthField(48, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode1
        {
            get { return _specialInstructionCode1; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode1 = value;
            }
        }

        private string _specialInstructionCode2;
        [FixedLengthField(49, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode2
        {
            get { return _specialInstructionCode2; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode2 = value;
            }
        }

        private string _specialInstructionCode3;
        [FixedLengthField(50, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode3
        {
            get { return _specialInstructionCode3; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode3 = value;
            }
        }

        private string _specialInstructionCode4;
        [FixedLengthField(51, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode4
        {
            get { return _specialInstructionCode4; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode4 = value;
            }
        }

        private string _specialInstructionCode5;
        [FixedLengthField(52, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode5
        {
            get { return _specialInstructionCode5; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode5 = value;
            }
        }

        private string _miscellaneousIns20Byte1;
        [FixedLengthField(53, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte1
        {
            get { return _miscellaneousIns20Byte1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte1 = value;
            }
        }

        private string _miscellaneousIns20Byte2;
        [FixedLengthField(54, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte2
        {
            get { return _miscellaneousIns20Byte2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte2 = value;
            }
        }

        private string _miscellaneousIns20Byte4;
        [FixedLengthField(55, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte4
        {
            get { return _miscellaneousIns20Byte4; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte4 = value;
            }
        }

        private string _miscellaneousIns20Byte5;
        [FixedLengthField(56, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte5
        {
            get { return _miscellaneousIns20Byte5; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte5 = value;
            }
        }

        private string _miscellaneousIns20Byte6;
        [FixedLengthField(57, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte6
        {
            get { return _miscellaneousIns20Byte6; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte6 = value;
            }
        }

        private string _miscellaneousIns20Byte7;
        [FixedLengthField(58, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte7
        {
            get { return _miscellaneousIns20Byte7; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte7 = value;
            }
        }

        private string _miscellaneousIns20Byte8;
        [FixedLengthField(59, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte8
        {
            get { return _miscellaneousIns20Byte8; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte8 = value;
            }
        }

        private string _miscellaneousIns20Byte9;
        [FixedLengthField(60, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte9
        {
            get { return _miscellaneousIns20Byte9; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte9 = value;
            }
        }

        private string _miscellaneousIns20Byte10;
        [FixedLengthField(61, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte10
        {
            get { return _miscellaneousIns20Byte10; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte10 = value;
            }
        }

        private string _miscellaneousIns5Byte1;
        [FixedLengthField(62, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte1
        {
            get { return _miscellaneousIns5Byte1; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte1 = value;
            }
        }

        private string _miscellaneousIns5Byte2;
        [FixedLengthField(63, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte2
        {
            get { return _miscellaneousIns5Byte2; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte2 = value;
            }
        }

        private string _miscellaneousIns5Byte3;
        [FixedLengthField(64, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte3
        {
            get { return _miscellaneousIns5Byte3; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte3 = value;
            }
        }

        private string _miscellaneousIns5Byte4;
        [FixedLengthField(65, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte4
        {
            get { return _miscellaneousIns5Byte4; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte4 = value;
            }
        }

        private string _miscellaneousIns10Byte1;
        [FixedLengthField(66, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte1
        {
            get { return _miscellaneousIns10Byte1; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte1 = value;
            }
        }

        private string _miscellaneousIns10Byte2;
        [FixedLengthField(67, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte2
        {
            get { return _miscellaneousIns10Byte2; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte2 = value;
            }
        }

        private string _miscellaneousIns10Byte3;
        [FixedLengthField(68, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte3
        {
            get { return _miscellaneousIns10Byte3; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte3 = value;
            }
        }

        private string _miscellaneousIns10Byte4;
        [FixedLengthField(69, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte4
        {
            get { return _miscellaneousIns10Byte4; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte4 = value;
            }
        }

        private string _miscellaneousIns20Byte11;
        [FixedLengthField(70, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte11
        {
            get { return _miscellaneousIns20Byte11; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte11 = value;
            }
        }

        private string _miscellaneousIns20Byte12;
        [FixedLengthField(71, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte12
        {
            get { return _miscellaneousIns20Byte12; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte12 = value;
            }
        }

        private string _miscellaneousIns20Byte13;
        [FixedLengthField(72, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte13
        {
            get { return _miscellaneousIns20Byte13; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte13 = value;
            }
        }

        private string _miscellaneousIns20Byte14;
        [FixedLengthField(73, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte14
        {
            get { return _miscellaneousIns20Byte14; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte14 = value;
            }
        }

        private string _batchControlNumber;
        [FixedLengthField(74, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private long _miscellaneousNum1;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(75, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(76, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(77, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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

        private long _miscellaneousNum4;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(78, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum4_Backing
        {
            get { return _miscellaneousNum4; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum4 = value;
            }
        }
        public decimal MiscellaneousNum4
        {
            get { return MiscellaneousNum4_Backing / 100000.0m; }
            set { MiscellaneousNum4_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum5;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(79, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum5_Backing
        {
            get { return _miscellaneousNum5; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum5 = value;
            }
        }
        public decimal MiscellaneousNum5
        {
            get { return MiscellaneousNum5_Backing / 100000.0m; }
            set { MiscellaneousNum5_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum6;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(80, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum6_Backing
        {
            get { return _miscellaneousNum6; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum6 = value;
            }
        }
        public decimal MiscellaneousNum6
        {
            get { return MiscellaneousNum6_Backing / 100000.0m; }
            set { MiscellaneousNum6_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum7;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(81, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum7_Backing
        {
            get { return _miscellaneousNum7; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum7 = value;
            }
        }
        public decimal MiscellaneousNum7
        {
            get { return MiscellaneousNum7_Backing / 100000.0m; }
            set { MiscellaneousNum7_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum8;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(82, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum8_Backing
        {
            get { return _miscellaneousNum8; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum8 = value;
            }
        }
        public decimal MiscellaneousNum8
        {
            get { return MiscellaneousNum8_Backing / 100000.0m; }
            set { MiscellaneousNum8_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum9;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(83, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum9_Backing
        {
            get { return _miscellaneousNum9; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum9 = value;
            }
        }
        public decimal MiscellaneousNum9
        {
            get { return MiscellaneousNum9_Backing / 100000.0m; }
            set { MiscellaneousNum9_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum10;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(84, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum10_Backing
        {
            get { return _miscellaneousNum10; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum10 = value;
            }
        }
        public decimal MiscellaneousNum10
        {
            get { return MiscellaneousNum10_Backing / 100000.0m; }
            set { MiscellaneousNum10_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum11;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(85, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum11_Backing
        {
            get { return _miscellaneousNum11; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum11 = value;
            }
        }
        public decimal MiscellaneousNum11
        {
            get { return MiscellaneousNum11_Backing / 100000.0m; }
            set { MiscellaneousNum11_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum12;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(86, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long MiscellaneousNum12_Backing
        {
            get { return _miscellaneousNum12; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum12 = value;
            }
        }
        public decimal MiscellaneousNum12
        {
            get { return MiscellaneousNum12_Backing / 100000.0m; }
            set { MiscellaneousNum12_Backing = (int)(value * 100000.0m); }
        }

        private string _pathNumber;
        [FixedLengthField(87, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(88, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
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
        [FixedLengthField(89, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                              ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _lineItemStatus;
        [FixedLengthField(90, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string LineItemStatus
        {
            get { return _lineItemStatus; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _lineItemStatus = value;
            }
        }

        private int _scheduleDeliveryDate;
        [FixedLengthField(91, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int ScheduleDeliveryDate
        {
            get { return _scheduleDeliveryDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduleDeliveryDate = value;
            }
        }

        private string _miscellaneousIns20Byte3;
        [FixedLengthField(92, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte3
        {
            get { return _miscellaneousIns20Byte3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte3 = value;
            }
        }

        private string _orderedCompany;
        [FixedLengthField(93, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string OrderedCompany
        {
            get { return _orderedCompany; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _orderedCompany = value;
            }
        }

        private string _orderedDivision;
        [FixedLengthField(94, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string OrderedDivision
        {
            get { return _orderedDivision; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _orderedDivision = value;
            }
        }

        private string _orderedSeason;
        [FixedLengthField(95, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string OrderedSeason
        {
            get { return _orderedSeason; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderedSeason = value;
            }
        }

        private string _orderedSeasonYear;
        [FixedLengthField(96, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string OrderedSeasonYear
        {
            get { return _orderedSeasonYear; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderedSeasonYear = value;
            }
        }

        private string _orderedStyle;
        [FixedLengthField(97, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string OrderedStyle
        {
            get { return _orderedStyle; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _orderedStyle = value;
            }
        }

        private string _orderedStyleSuffix;
        [FixedLengthField(98, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string OrderedStyleSuffix
        {
            get { return _orderedStyleSuffix; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _orderedStyleSuffix = value;
            }
        }

        private string _orderedColor;
        [FixedLengthField(99, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string OrderedColor
        {
            get { return _orderedColor; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _orderedColor = value;
            }
        }

        private string _orderedColorSuffix;
        [FixedLengthField(100, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string OrderedColorSuffix
        {
            get { return _orderedColorSuffix; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderedColorSuffix = value;
            }
        }

        private string _orderedSecDimn;
        [FixedLengthField(101, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string OrderedSecDimn
        {
            get { return _orderedSecDimn; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _orderedSecDimn = value;
            }
        }

        private string _orderedQuality;
        [FixedLengthField(102, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string OrderedQuality
        {
            get { return _orderedQuality; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _orderedQuality = value;
            }
        }

        private string _orderedSizeCode;
        [FixedLengthField(103, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string OrderedSizeCode
        {
            get { return _orderedSizeCode; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _orderedSizeCode = value;
            }
        }

        private int _orderedSizePosn;
        [FixedLengthField(104, 2, PaddingChar = '0', Padding = Padding.Left, NullValue = "00")]
        public int OrderedSizePosn
        {
            get { return _orderedSizePosn; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderedSizePosn = value;
            }
        }

        private string _orderedSizeDescription;
        [FixedLengthField(105, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string OrderedSizeDescription
        {
            get { return _orderedSizeDescription; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _orderedSizeDescription = value;
            }
        }

        private string _invoicingStatus;
        [FixedLengthField(106, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InvoicingStatus
        {
            get { return _invoicingStatus; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _invoicingStatus = value;
            }
        }

        private string _demandId;
        [FixedLengthField(107, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string DemandId
        {
            get { return _demandId; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _demandId = value;
            }
        }

        private string _ponumber;
        [FixedLengthField(108, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string Ponumber
        {
            get { return _ponumber; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _ponumber = value;
            }
        }

        private string _exportIdentificationCode;
        [FixedLengthField(109, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ExportIdentificationCode
        {
            get { return _exportIdentificationCode; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _exportIdentificationCode = value;
            }
        }

        private string _marksAndNumbers;
        [FixedLengthField(110, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string MarksAndNumbers
        {
            get { return _marksAndNumbers; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _marksAndNumbers = value;
            }
        }

        private string _tpePurchaseOrder;
        [FixedLengthField(111, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                         ")]
        public string TpePurchaseOrder
        {
            get { return _tpePurchaseOrder; }
            set
            {
                if (value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _tpePurchaseOrder = value;
            }
        }

        private string _shortDescription1;
        [FixedLengthField(112, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShortDescription1
        {
            get { return _shortDescription1; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription1 = value;
            }
        }

        private string _shortDescription2;
        [FixedLengthField(113, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShortDescription2
        {
            get { return _shortDescription2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription2 = value;
            }
        }

        private string _shortDescription3;
        [FixedLengthField(114, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShortDescription3
        {
            get { return _shortDescription3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription3 = value;
            }
        }

        private string _shortDescription4;
        [FixedLengthField(115, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShortDescription4
        {
            get { return _shortDescription4; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription4 = value;
            }
        }

        private string _shortDescription5;
        [FixedLengthField(116, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShortDescription5
        {
            get { return _shortDescription5; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shortDescription5 = value;
            }
        }

        [Write(false)] // dapper attribute specifying not to write this property to the database
        public int TotalFileLength { get { return 1180; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
