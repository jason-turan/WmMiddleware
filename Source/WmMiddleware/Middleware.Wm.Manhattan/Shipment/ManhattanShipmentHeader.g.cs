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
    [Table("ManhattanShipmentHeader")]
    public partial class ManhattanShipmentHeader : IGeneratedFlatFile
    {
        [Key]
        public int ManhattanShipmentHeaderId { get; set; }

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

        private string _company;
        [FixedLengthField(6, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
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
        [FixedLengthField(7, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Division
        {
            get { return _division; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _division = value;
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

        private string _warehouse;
        [FixedLengthField(9, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _warehouse = value;
            }
        }

        private string _pickticketnumber;
        [FixedLengthField(10, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue = "           ")]
        public string Pickticketnumber
        {
            get { return _pickticketnumber; }
            set
            {
                if (value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _pickticketnumber = value;
            }
        }

        private string _pickticketSuffix;
        [FixedLengthField(11, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string PickticketSuffix
        {
            get { return _pickticketSuffix; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickticketSuffix = value;
            }
        }

        private string _orderNumber;
        [FixedLengthField(12, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string OrderNumber
        {
            get { return _orderNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _orderNumber = value;
            }
        }

        private string _orderSuffix;
        [FixedLengthField(13, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string OrderSuffix
        {
            get { return _orderSuffix; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _orderSuffix = value;
            }
        }

        private string _orderType;
        [FixedLengthField(14, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string OrderType
        {
            get { return _orderType; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderType = value;
            }
        }

        private string _shipto;
        [FixedLengthField(15, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string Shipto
        {
            get { return _shipto; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _shipto = value;
            }
        }

        private string _soldto;
        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string Soldto
        {
            get { return _soldto; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _soldto = value;
            }
        }

        private string _storeNumber;
        [FixedLengthField(17, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string StoreNumber
        {
            get { return _storeNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeNumber = value;
            }
        }

        private string _dcCenterNumber;
        [FixedLengthField(18, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "        ")]
        public string DcCenterNumber
        {
            get { return _dcCenterNumber; }
            set
            {
                if (value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _dcCenterNumber = value;
            }
        }

        private string _merchandiseClass;
        [FixedLengthField(19, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string MerchandiseClass
        {
            get { return _merchandiseClass; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _merchandiseClass = value;
            }
        }

        private string _merchandiseCompany;
        [FixedLengthField(20, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MerchandiseCompany
        {
            get { return _merchandiseCompany; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _merchandiseCompany = value;
            }
        }

        private string _merchandiseDivision;
        [FixedLengthField(21, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MerchandiseDivision
        {
            get { return _merchandiseDivision; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _merchandiseDivision = value;
            }
        }

        private string _referencePickticketControlNumberType;
        [FixedLengthField(22, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ReferencePickticketControlNumberType
        {
            get { return _referencePickticketControlNumberType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _referencePickticketControlNumberType = value;
            }
        }

        private string _referencePickticketControlNumber;
        [FixedLengthField(23, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ReferencePickticketControlNumber
        {
            get { return _referencePickticketControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _referencePickticketControlNumber = value;
            }
        }

        private string _cartonLabelType;
        [FixedLengthField(24, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string CartonLabelType
        {
            get { return _cartonLabelType; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _cartonLabelType = value;
            }
        }

        private string _logicalWarehouse;
        [FixedLengthField(25, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string LogicalWarehouse
        {
            get { return _logicalWarehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _logicalWarehouse = value;
            }
        }

        private string _transferWarehouse;
        [FixedLengthField(26, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string TransferWarehouse
        {
            get { return _transferWarehouse; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transferWarehouse = value;
            }
        }

        private string _warehouseTransferType;
        [FixedLengthField(27, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string WarehouseTransferType
        {
            get { return _warehouseTransferType; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _warehouseTransferType = value;
            }
        }

        private string _currency;
        [FixedLengthField(28, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _currency = value;
            }
        }

        private string _plannedShipVia;
        [FixedLengthField(29, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string PlannedShipVia
        {
            get { return _plannedShipVia; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _plannedShipVia = value;
            }
        }

        private string _plannedLoadNumber;
        [FixedLengthField(30, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string PlannedLoadNumber
        {
            get { return _plannedLoadNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _plannedLoadNumber = value;
            }
        }

        private string _plannedShipmentNumber;
        [FixedLengthField(31, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string PlannedShipmentNumber
        {
            get { return _plannedShipmentNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _plannedShipmentNumber = value;
            }
        }

        private int _pickticketGenerationDate;
        [FixedLengthField(32, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int PickticketGenerationDate
        {
            get { return _pickticketGenerationDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _pickticketGenerationDate = value;
            }
        }

        private int _pickticketPrintDate;
        [FixedLengthField(33, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int PickticketPrintDate
        {
            get { return _pickticketPrintDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _pickticketPrintDate = value;
            }
        }

        private string _reasonCode;
        [FixedLengthField(34, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string ReasonCode
        {
            get { return _reasonCode; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _reasonCode = value;
            }
        }

        private int _scheduleDeliveryDate;
        [FixedLengthField(35, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int ScheduleDeliveryDate
        {
            get { return _scheduleDeliveryDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduleDeliveryDate = value;
            }
        }

        private int _shipDate;
        [FixedLengthField(36, 9, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000")]
        public int ShipDate
        {
            get { return _shipDate; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _shipDate = value;
            }
        }

        private string _shipmentTypeDi;
        [FixedLengthField(37, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ShipmentTypeDi
        {
            get { return _shipmentTypeDi; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipmentTypeDi = value;
            }
        }

        private string _customerPonumber;
        [FixedLengthField(38, 26, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                          ")]
        public string CustomerPonumber
        {
            get { return _customerPonumber; }
            set
            {
                if (value != default(string) && value.Length > 26) throw new ArgumentOutOfRangeException("value");
                _customerPonumber = value;
            }
        }

        private string _arAccountNumber;
        [FixedLengthField(39, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ArAccountNumber
        {
            get { return _arAccountNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _arAccountNumber = value;
            }
        }

        private long _totalWeight;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(40, 15, PaddingChar = '0', Padding = Padding.Left, NullValue = "000000000000000")]
        public long TotalWeight_Backing
        {
            get { return _totalWeight; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _totalWeight = value;
            }
        }
        public decimal TotalWeight
        {
            get { return TotalWeight_Backing / 100000.0m; }
            set { TotalWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _totalShippedQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(41, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
        public long TotalShippedQuantity_Backing
        {
            get { return _totalShippedQuantity; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _totalShippedQuantity = value;
            }
        }
        public decimal TotalShippedQuantity
        {
            get { return TotalShippedQuantity_Backing / 10000.0m; }
            set { TotalShippedQuantity_Backing = (int)(value * 10000.0m); }
        }

        private int _totNumberOfCartons;
        [FixedLengthField(42, 7, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000")]
        public int TotNumberOfCartons
        {
            get { return _totNumberOfCartons; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _totNumberOfCartons = value;
            }
        }

        private int _totalNumberOfLines;
        [FixedLengthField(43, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int TotalNumberOfLines
        {
            get { return _totalNumberOfLines; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _totalNumberOfLines = value;
            }
        }

        private string _shipWithControlNumber;
        [FixedLengthField(44, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string ShipWithControlNumber
        {
            get { return _shipWithControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _shipWithControlNumber = value;
            }
        }

        private long _productValue;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(45, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long ProductValue_Backing
        {
            get { return _productValue; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _productValue = value;
            }
        }
        public decimal ProductValue
        {
            get { return ProductValue_Backing / 10000.0m; }
            set { ProductValue_Backing = (int)(value * 10000.0m); }
        }

        private string _recalculateOrderChg;
        [FixedLengthField(46, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string RecalculateOrderChg
        {
            get { return _recalculateOrderChg; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _recalculateOrderChg = value;
            }
        }

        private long _creditAmount;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(47, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long CreditAmount_Backing
        {
            get { return _creditAmount; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _creditAmount = value;
            }
        }
        public decimal CreditAmount
        {
            get { return CreditAmount_Backing / 10000.0m; }
            set { CreditAmount_Backing = (int)(value * 10000.0m); }
        }

        private long _orderCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(48, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long OrderCharge_Backing
        {
            get { return _orderCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _orderCharge = value;
            }
        }
        public decimal OrderCharge
        {
            get { return OrderCharge_Backing / 10000.0m; }
            set { OrderCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _handlingCharges;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(49, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long HandlingCharges_Backing
        {
            get { return _handlingCharges; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _handlingCharges = value;
            }
        }
        public decimal HandlingCharges
        {
            get { return HandlingCharges_Backing / 10000.0m; }
            set { HandlingCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _taxCharges;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(50, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long TaxCharges_Backing
        {
            get { return _taxCharges; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _taxCharges = value;
            }
        }
        public decimal TaxCharges
        {
            get { return TaxCharges_Backing / 10000.0m; }
            set { TaxCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _miscellaneousCharges;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(51, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long MiscellaneousCharges_Backing
        {
            get { return _miscellaneousCharges; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _miscellaneousCharges = value;
            }
        }
        public decimal MiscellaneousCharges
        {
            get { return MiscellaneousCharges_Backing / 10000.0m; }
            set { MiscellaneousCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _baseCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(52, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long BaseCharge_Backing
        {
            get { return _baseCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _baseCharge = value;
            }
        }
        public decimal BaseCharge
        {
            get { return BaseCharge_Backing / 10000.0m; }
            set { BaseCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _carrierCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(53, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long CarrierCharge_Backing
        {
            get { return _carrierCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _carrierCharge = value;
            }
        }
        public decimal CarrierCharge
        {
            get { return CarrierCharge_Backing / 10000.0m; }
            set { CarrierCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _customerCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(54, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long CustomerCharge_Backing
        {
            get { return _customerCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _customerCharge = value;
            }
        }
        public decimal CustomerCharge
        {
            get { return CustomerCharge_Backing / 10000.0m; }
            set { CustomerCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _insuranceCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(55, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long InsuranceCharge_Backing
        {
            get { return _insuranceCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _insuranceCharge = value;
            }
        }
        public decimal InsuranceCharge
        {
            get { return InsuranceCharge_Backing / 10000.0m; }
            set { InsuranceCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _accessorialCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(56, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long AccessorialCharge_Backing
        {
            get { return _accessorialCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _accessorialCharge = value;
            }
        }
        public decimal AccessorialCharge
        {
            get { return AccessorialCharge_Backing / 10000.0m; }
            set { AccessorialCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _lineHaulCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(57, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long LineHaulCharge_Backing
        {
            get { return _lineHaulCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _lineHaulCharge = value;
            }
        }
        public decimal LineHaulCharge
        {
            get { return LineHaulCharge_Backing / 10000.0m; }
            set { LineHaulCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _distributingCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(58, 19, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000000000")]
        public long DistributingCharge_Backing
        {
            get { return _distributingCharge; }
            set
            {
                if (value != default(decimal) && value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _distributingCharge = value;
            }
        }
        public decimal DistributingCharge
        {
            get { return DistributingCharge_Backing / 10000.0m; }
            set { DistributingCharge_Backing = (int)(value * 10000.0m); }
        }

        private string _globalLocationNumber;
        [FixedLengthField(59, 13, PaddingChar = ' ', Padding = Padding.Right, NullValue = "             ")]
        public string GlobalLocationNumber
        {
            get { return _globalLocationNumber; }
            set
            {
                if (value != default(string) && value.Length > 13) throw new ArgumentOutOfRangeException("value");
                _globalLocationNumber = value;
            }
        }

        private string _miscellaneousIns5Byte1;
        [FixedLengthField(60, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
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
        [FixedLengthField(61, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
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
        [FixedLengthField(62, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
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
        [FixedLengthField(63, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
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
        [FixedLengthField(64, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
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
        [FixedLengthField(65, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte2
        {
            get { return _miscellaneousIns10Byte2; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte2 = value;
            }
        }

        private string _miscellaneousIns20Byte1;
        [FixedLengthField(66, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(67, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte2
        {
            get { return _miscellaneousIns20Byte2; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte2 = value;
            }
        }

        private string _miscellaneousIns20Byte3;
        [FixedLengthField(68, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte3
        {
            get { return _miscellaneousIns20Byte3; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte3 = value;
            }
        }

        private string _miscellaneousIns20Byte4;
        [FixedLengthField(69, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(70, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(71, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(72, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(73, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(74, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(75, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte10
        {
            get { return _miscellaneousIns20Byte10; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte10 = value;
            }
        }

        private string _miscellaneousIns5Byte5;
        [FixedLengthField(76, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte5
        {
            get { return _miscellaneousIns5Byte5; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte5 = value;
            }
        }

        private string _miscellaneousIns5Byte6;
        [FixedLengthField(77, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte6
        {
            get { return _miscellaneousIns5Byte6; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte6 = value;
            }
        }

        private string _miscellaneousIns5Byte7;
        [FixedLengthField(78, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte7
        {
            get { return _miscellaneousIns5Byte7; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte7 = value;
            }
        }

        private string _miscellaneousIns5Byte8;
        [FixedLengthField(79, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = "     ")]
        public string MiscellaneousIns5Byte8
        {
            get { return _miscellaneousIns5Byte8; }
            set
            {
                if (value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte8 = value;
            }
        }

        private string _miscellaneousIns10Byte3;
        [FixedLengthField(80, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
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
        [FixedLengthField(81, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte4
        {
            get { return _miscellaneousIns10Byte4; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte4 = value;
            }
        }

        private string _miscellaneousIns10Byte5;
        [FixedLengthField(82, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte5
        {
            get { return _miscellaneousIns10Byte5; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte5 = value;
            }
        }

        private string _miscellaneousIns10Byte6;
        [FixedLengthField(83, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string MiscellaneousIns10Byte6
        {
            get { return _miscellaneousIns10Byte6; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte6 = value;
            }
        }

        private string _miscellaneousIns20Byte11;
        [FixedLengthField(84, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(85, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(86, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
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
        [FixedLengthField(87, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string MiscellaneousIns20Byte14
        {
            get { return _miscellaneousIns20Byte14; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte14 = value;
            }
        }

        private long _miscellaneousNum1;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(88, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(89, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(90, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(91, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
        [FixedLengthField(92, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum5_Backing = (long)(value * 100000.0m); }
        }

        private long _miscellaneousNum6;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(93, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum6_Backing = (long)(value * 100000.0m); }
        }

        private long _miscellaneousNum7;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(94, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum7_Backing = (long)(value * 100000.0m); }
        }

        private long _miscellaneousNum8;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(95, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum8_Backing = (long)(value * 100000.0m); }
        }

        private long _miscellaneousNum9;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(96, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum9_Backing = (long)(value * 100000.0m); }
        }

        private long _miscellaneousNum10;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(97, 13, PaddingChar = '0', Padding = Padding.Left, NullValue = "0000000000000")]
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
            set { MiscellaneousNum10_Backing = (long)(value * 100000.0m); }
        }

        private string _specialInstructionCode1;
        [FixedLengthField(98, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
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
        [FixedLengthField(99, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
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
        [FixedLengthField(100, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
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
        [FixedLengthField(101, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
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
        [FixedLengthField(102, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode5
        {
            get { return _specialInstructionCode5; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode5 = value;
            }
        }

        private string _specialInstructionCode6;
        [FixedLengthField(103, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode6
        {
            get { return _specialInstructionCode6; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode6 = value;
            }
        }

        private string _specialInstructionCode7;
        [FixedLengthField(104, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode7
        {
            get { return _specialInstructionCode7; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode7 = value;
            }
        }

        private string _specialInstructionCode8;
        [FixedLengthField(105, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode8
        {
            get { return _specialInstructionCode8; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode8 = value;
            }
        }

        private string _specialInstructionCode9;
        [FixedLengthField(106, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode9
        {
            get { return _specialInstructionCode9; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode9 = value;
            }
        }

        private string _specialInstructionCode10;
        [FixedLengthField(107, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = "  ")]
        public string SpecialInstructionCode10
        {
            get { return _specialInstructionCode10; }
            set
            {
                if (value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode10 = value;
            }
        }

        private string _freightTerms;
        [FixedLengthField(108, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string FreightTerms
        {
            get { return _freightTerms; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _freightTerms = value;
            }
        }

        private string _batchInvoiceForOrd;
        [FixedLengthField(109, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string BatchInvoiceForOrd
        {
            get { return _batchInvoiceForOrd; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _batchInvoiceForOrd = value;
            }
        }

        private string _prebillingStatus;
        [FixedLengthField(110, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string PrebillingStatus
        {
            get { return _prebillingStatus; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _prebillingStatus = value;
            }
        }

        private string _invoicingStatus;
        [FixedLengthField(111, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InvoicingStatus
        {
            get { return _invoicingStatus; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _invoicingStatus = value;
            }
        }

        private string _deliveryStatus;
        [FixedLengthField(112, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string DeliveryStatus
        {
            get { return _deliveryStatus; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deliveryStatus = value;
            }
        }

        private string _invoicedByPickticketFlag;
        [FixedLengthField(113, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InvoicedByPickticketFlag
        {
            get { return _invoicedByPickticketFlag; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _invoicedByPickticketFlag = value;
            }
        }

        private string _batchControlNumber;
        [FixedLengthField(114, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private string _recordExpansionField;
        [FixedLengthField(115, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                                  ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        private string _customRecordExpansionField;
        [FixedLengthField(116, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if (value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _bulkInvoice;
        [FixedLengthField(117, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string BulkInvoice
        {
            get { return _bulkInvoice; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _bulkInvoice = value;
            }
        }

        private string _invoiceEditFlag;
        [FixedLengthField(118, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string InvoiceEditFlag
        {
            get { return _invoiceEditFlag; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _invoiceEditFlag = value;
            }
        }

        private string _codFlag;
        [FixedLengthField(119, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string CodFlag
        {
            get { return _codFlag; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _codFlag = value;
            }
        }

        private string _shipfromName;
        [FixedLengthField(120, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipfromName
        {
            get { return _shipfromName; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipfromName = value;
            }
        }

        private string _shipfromAddr1;
        [FixedLengthField(121, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipfromAddr1
        {
            get { return _shipfromAddr1; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipfromAddr1 = value;
            }
        }

        private string _shipfromAddr2;
        [FixedLengthField(122, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipfromAddr2
        {
            get { return _shipfromAddr2; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipfromAddr2 = value;
            }
        }

        private string _shipfromAddr3;
        [FixedLengthField(123, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipfromAddr3
        {
            get { return _shipfromAddr3; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipfromAddr3 = value;
            }
        }

        private string _shipfromCity;
        [FixedLengthField(124, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipfromCity
        {
            get { return _shipfromCity; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipfromCity = value;
            }
        }

        private string _shipfromState;
        [FixedLengthField(125, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShipfromState
        {
            get { return _shipfromState; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipfromState = value;
            }
        }

        private string _shipfromZip;
        [FixedLengthField(126, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue = "           ")]
        public string ShipfromZip
        {
            get { return _shipfromZip; }
            set
            {
                if (value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _shipfromZip = value;
            }
        }

        private string _shipfromCountry;
        [FixedLengthField(127, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShipfromCountry
        {
            get { return _shipfromCountry; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipfromCountry = value;
            }
        }

        private string _shiptoName;
        [FixedLengthField(128, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShiptoName
        {
            get { return _shiptoName; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shiptoName = value;
            }
        }

        private string _shipToName2;
        [FixedLengthField(129, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipToName2
        {
            get { return _shipToName2; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToName2 = value;
            }
        }

        private string _shiptoAddr1;
        [FixedLengthField(130, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShiptoAddr1
        {
            get { return _shiptoAddr1; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shiptoAddr1 = value;
            }
        }

        private string _shiptoAddr2;
        [FixedLengthField(131, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShiptoAddr2
        {
            get { return _shiptoAddr2; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shiptoAddr2 = value;
            }
        }

        private string _shiptoAddr3;
        [FixedLengthField(132, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShiptoAddr3
        {
            get { return _shiptoAddr3; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shiptoAddr3 = value;
            }
        }

        private string _shiptoCity;
        [FixedLengthField(133, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShiptoCity
        {
            get { return _shiptoCity; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shiptoCity = value;
            }
        }

        private string _shiptoState;
        [FixedLengthField(134, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShiptoState
        {
            get { return _shiptoState; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shiptoState = value;
            }
        }

        private string _shiptoZip;
        [FixedLengthField(135, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue = "           ")]
        public string ShiptoZip
        {
            get { return _shiptoZip; }
            set
            {
                if (value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _shiptoZip = value;
            }
        }

        private string _shiptoCountry;
        [FixedLengthField(136, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShiptoCountry
        {
            get { return _shiptoCountry; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shiptoCountry = value;
            }
        }

        private string _shipforName;
        [FixedLengthField(137, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipforName
        {
            get { return _shipforName; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipforName = value;
            }
        }

        private string _shipForName2;
        [FixedLengthField(138, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipForName2
        {
            get { return _shipForName2; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipForName2 = value;
            }
        }

        private string _shipforAddr1;
        [FixedLengthField(139, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipforAddr1
        {
            get { return _shipforAddr1; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipforAddr1 = value;
            }
        }

        private string _shipforAddr2;
        [FixedLengthField(140, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipforAddr2
        {
            get { return _shipforAddr2; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipforAddr2 = value;
            }
        }

        private string _shipforAddr3;
        [FixedLengthField(141, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipforAddr3
        {
            get { return _shipforAddr3; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipforAddr3 = value;
            }
        }

        private string _shipforCity;
        [FixedLengthField(142, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                                   ")]
        public string ShipforCity
        {
            get { return _shipforCity; }
            set
            {
                if (value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipforCity = value;
            }
        }

        private string _shipforState;
        [FixedLengthField(143, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ShipforState
        {
            get { return _shipforState; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipforState = value;
            }
        }

        private string _shipforZip;
        [FixedLengthField(144, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue = "           ")]
        public string ShipforZip
        {
            get { return _shipforZip; }
            set
            {
                if (value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _shipforZip = value;
            }
        }

        private string _shipforCountry;
        [FixedLengthField(145, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShipforCountry
        {
            get { return _shipforCountry; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipforCountry = value;
            }
        }

        private string _retailPickticket;
        [FixedLengthField(146, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string RetailPickticket
        {
            get { return _retailPickticket; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _retailPickticket = value;
            }
        }

        private string _consolidatorAddressCode;
        [FixedLengthField(147, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "          ")]
        public string ConsolidatorAddressCode
        {
            get { return _consolidatorAddressCode; }
            set
            {
                if (value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _consolidatorAddressCode = value;
            }
        }

        private string _tmsOrderType;
        [FixedLengthField(148, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "   ")]
        public string TmsOrderType
        {
            get { return _tmsOrderType; }
            set
            {
                if (value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _tmsOrderType = value;
            }
        }

        private string _hostApointmentNumber;
        [FixedLengthField(149, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue = "               ")]
        public string HostApointmentNumber
        {
            get { return _hostApointmentNumber; }
            set
            {
                if (value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _hostApointmentNumber = value;
            }
        }

        private int _numberOfDetailLines;
        [FixedLengthField(150, 5, PaddingChar = '0', Padding = Padding.Left, NullValue = "00000")]
        public int NumberOfDetailLines
        {
            get { return _numberOfDetailLines; }
            set
            {
                if (value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _numberOfDetailLines = value;
            }
        }

        private string _warehouseXferAsnCreate;
        [FixedLengthField(151, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string WarehouseXferAsnCreate
        {
            get { return _warehouseXferAsnCreate; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _warehouseXferAsnCreate = value;
            }
        }

        private string _backordrPickticketExists;
        [FixedLengthField(152, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string BackordrPickticketExists
        {
            get { return _backordrPickticketExists; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _backordrPickticketExists = value;
            }
        }

        private string _backordrPickticket;
        [FixedLengthField(153, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string BackordrPickticket
        {
            get { return _backordrPickticket; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _backordrPickticket = value;
            }
        }

        private string _reasonCodeShortDescription;
        [FixedLengthField(154, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "                    ")]
        public string ReasonCodeShortDescription
        {
            get { return _reasonCodeShortDescription; }
            set
            {
                if (value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reasonCodeShortDescription = value;
            }
        }

        private string _shippedShipVia;
        [FixedLengthField(155, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "    ")]
        public string ShippedShipVia
        {
            get { return _shippedShipVia; }
            set
            {
                if (value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shippedShipVia = value;
            }
        }

        private string _generateInvoiceData;
        [FixedLengthField(156, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string GenerateInvoiceData
        {
            get { return _generateInvoiceData; }
            set
            {
                if (value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _generateInvoiceData = value;
            }
        }

        [Write(false)] // dapper attribute specifying not to write this property to the database
        public int TotalFileLength { get { return 2009; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
