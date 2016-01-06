using System;
using System.Globalization;
using Dapper.Contrib.Extensions;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using WmMiddleware.Common.DataFiles;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.Shipment.Models.Generated
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    [Table("ShipmentCartonHeader")]
    public partial class ShipmentCartonHeader : IGeneratedFlatFile
    {
        [Key]
         public int ShipmentCartonHeaderId { get; set; }

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

        private string _cartonnumber;
        [FixedLengthField(8, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Cartonnumber
        {
            get { return _cartonnumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _cartonnumber = value;
            }
        }

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

        private string _batchControlNumber;
        [FixedLengthField(10, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string BatchControlNumber
        {
            get { return _batchControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _batchControlNumber = value;
            }
        }

        private string _pickticketnumber;
        [FixedLengthField(11, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string Pickticketnumber
        {
            get { return _pickticketnumber; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _pickticketnumber = value;
            }
        }

        private string _pickticketSuffix;
        [FixedLengthField(12, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickticketSuffix
        {
            get { return _pickticketSuffix; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickticketSuffix = value;
            }
        }

        private string _orderNumber;
        [FixedLengthField(13, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string OrderNumber
        {
            get { return _orderNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _orderNumber = value;
            }
        }

        private string _orderSuffix;
        [FixedLengthField(14, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string OrderSuffix
        {
            get { return _orderSuffix; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _orderSuffix = value;
            }
        }

        private string _soldto;
        [FixedLengthField(15, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string Soldto
        {
            get { return _soldto; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _soldto = value;
            }
        }

        private string _shipto;
        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string Shipto
        {
            get { return _shipto; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _shipto = value;
            }
        }

        private string _customerPonumber;
        [FixedLengthField(17, 26, PaddingChar = ' ', Padding = Padding.Right, NullValue="                          ")]
        public string CustomerPonumber
        {
            get { return _customerPonumber; }
            set
            {
                if(value != default(string) && value.Length > 26) throw new ArgumentOutOfRangeException("value");
                _customerPonumber = value;
            }
        }

        private string _trackingNumber;
        [FixedLengthField(18, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string TrackingNumber
        {
            get { return _trackingNumber; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _trackingNumber = value;
            }
        }

        private string _consigneeTrackingNumber;
        [FixedLengthField(19, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ConsigneeTrackingNumber
        {
            get { return _consigneeTrackingNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _consigneeTrackingNumber = value;
            }
        }

        private string _cartonType;
        [FixedLengthField(20, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CartonType
        {
            get { return _cartonType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonType = value;
            }
        }

        private string _cartonSize;
        [FixedLengthField(21, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CartonSize
        {
            get { return _cartonSize; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _cartonSize = value;
            }
        }

        private string _shippingUnit;
        [FixedLengthField(22, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShippingUnit
        {
            get { return _shippingUnit; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shippingUnit = value;
            }
        }

        private string _storeNumber;
        [FixedLengthField(23, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string StoreNumber
        {
            get { return _storeNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeNumber = value;
            }
        }

        private long _cartonVolume;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(24, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long CartonVolume_Backing
        {
            get { return _cartonVolume; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _cartonVolume = value;
            }
        }
        public decimal CartonVolume
        {
            get { return CartonVolume_Backing / 100000.0m; }
            set { CartonVolume_Backing = (int)(value * 100000.0m); }
        }

        private long _estimatedWeight;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(25, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(26, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private long _totalQuantity;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(27, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long TotalQuantity_Backing
        {
            get { return _totalQuantity; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _totalQuantity = value;
            }
        }
        public decimal TotalQuantity
        {
            get { return TotalQuantity_Backing / 10000.0m; }
            set { TotalQuantity_Backing = (int)(value * 10000.0m); }
        }

        private long _baseCharge;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(28, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long BaseCharge_Backing
        {
            get { return _baseCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
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
        [FixedLengthField(29, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long CarrierCharge_Backing
        {
            get { return _carrierCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
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
        [FixedLengthField(30, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long CustomerCharge_Backing
        {
            get { return _customerCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
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
        [FixedLengthField(31, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long InsuranceCharge_Backing
        {
            get { return _insuranceCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
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
        [FixedLengthField(32, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long AccessorialCharge_Backing
        {
            get { return _accessorialCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _accessorialCharge = value;
            }
        }
        public decimal AccessorialCharge
        {
            get { return AccessorialCharge_Backing / 10000.0m; }
            set { AccessorialCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _codAmount;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(33, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long CodAmount_Backing
        {
            get { return _codAmount; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _codAmount = value;
            }
        }
        public decimal CodAmount
        {
            get { return CodAmount_Backing / 10000.0m; }
            set { CodAmount_Backing = (int)(value * 10000.0m); }
        }

        private long _billedWeight;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(34, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long BilledWeight_Backing
        {
            get { return _billedWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _billedWeight = value;
            }
        }
        public decimal BilledWeight
        {
            get { return BilledWeight_Backing / 100000.0m; }
            set { BilledWeight_Backing = (int)(value * 100000.0m); }
        }

        private int _cartonNbrxOfY;
        [FixedLengthField(35, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CartonNbrxOfY
        {
            get { return _cartonNbrxOfY; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cartonNbrxOfY = value;
            }
        }

        private string _packageDescription;
        [FixedLengthField(36, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string PackageDescription
        {
            get { return _packageDescription; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _packageDescription = value;
            }
        }

        private string _palletId;
        [FixedLengthField(37, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PalletId
        {
            get { return _palletId; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _palletId = value;
            }
        }

        private string _tierNumber;
        [FixedLengthField(38, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string TierNumber
        {
            get { return _tierNumber; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _tierNumber = value;
            }
        }

        private string _masterBillOfLading;
        [FixedLengthField(39, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MasterBillOfLading
        {
            get { return _masterBillOfLading; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _masterBillOfLading = value;
            }
        }

        private string _billOfLading;
        [FixedLengthField(40, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string BillOfLading
        {
            get { return _billOfLading; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _billOfLading = value;
            }
        }

        private string _shipmentNumber;
        [FixedLengthField(41, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ShipmentNumber
        {
            get { return _shipmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _shipmentNumber = value;
            }
        }

        private string _loadNumber;
        [FixedLengthField(42, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string LoadNumber
        {
            get { return _loadNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _loadNumber = value;
            }
        }

        private string _route;
        [FixedLengthField(43, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Route
        {
            get { return _route; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _route = value;
            }
        }

        private string _manifestNumber;
        [FixedLengthField(44, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ManifestNumber
        {
            get { return _manifestNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _manifestNumber = value;
            }
        }

        private string _trailernumber;
        [FixedLengthField(45, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string Trailernumber
        {
            get { return _trailernumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _trailernumber = value;
            }
        }

        private long _pickupRecordNumber;
        [FixedLengthField(46, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long PickupRecordNumber
        {
            get { return _pickupRecordNumber; }
            set
            {
                if(value != default(long) && value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _pickupRecordNumber = value;
            }
        }

        private string _shipVia;
        [FixedLengthField(47, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ShipVia
        {
            get { return _shipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipVia = value;
            }
        }

        private int _numberOfTimesApptChanged;
        [FixedLengthField(48, 1, PaddingChar = '0', Padding = Padding.Left, NullValue="0")]
        public int NumberOfTimesApptChanged
        {
            get { return _numberOfTimesApptChanged; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 1) throw new ArgumentOutOfRangeException("value");
                _numberOfTimesApptChanged = value;
            }
        }

        private int _appointmentDate;
        [FixedLengthField(49, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int AppointmentDate
        {
            get { return _appointmentDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _appointmentDate = value;
            }
        }

        private string _apptMadeById;
        [FixedLengthField(50, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ApptMadeById
        {
            get { return _apptMadeById; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _apptMadeById = value;
            }
        }

        private int _loadSeqnumber;
        [FixedLengthField(51, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int LoadSeqnumber
        {
            get { return _loadSeqnumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _loadSeqnumber = value;
            }
        }

        private string _cartonVerifiedFlag;
        [FixedLengthField(52, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CartonVerifiedFlag
        {
            get { return _cartonVerifiedFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _cartonVerifiedFlag = value;
            }
        }

        private string _checkerId;
        [FixedLengthField(53, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string CheckerId
        {
            get { return _checkerId; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _checkerId = value;
            }
        }

        private string _pronumber;
        [FixedLengthField(54, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Pronumber
        {
            get { return _pronumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pronumber = value;
            }
        }

        private string _sealnumber;
        [FixedLengthField(55, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Sealnumber
        {
            get { return _sealnumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _sealnumber = value;
            }
        }

        private string _recipientFirstName;
        [FixedLengthField(56, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string RecipientFirstName
        {
            get { return _recipientFirstName; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _recipientFirstName = value;
            }
        }

        private string _recipientLastName;
        [FixedLengthField(57, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string RecipientLastName
        {
            get { return _recipientLastName; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _recipientLastName = value;
            }
        }

        private int _deliveredDate;
        [FixedLengthField(58, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int DeliveredDate
        {
            get { return _deliveredDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _deliveredDate = value;
            }
        }

        private int _deliveredTime;
        [FixedLengthField(59, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int DeliveredTime
        {
            get { return _deliveredTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _deliveredTime = value;
            }
        }

        private string _deliveredOnTimeFlag;
        [FixedLengthField(60, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DeliveredOnTimeFlag
        {
            get { return _deliveredOnTimeFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deliveredOnTimeFlag = value;
            }
        }

        private string _deliveredCompleteFlag;
        [FixedLengthField(61, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DeliveredCompleteFlag
        {
            get { return _deliveredCompleteFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deliveredCompleteFlag = value;
            }
        }

        private string _deliveryComment;
        [FixedLengthField(62, 60, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                            ")]
        public string DeliveryComment
        {
            get { return _deliveryComment; }
            set
            {
                if(value != default(string) && value.Length > 60) throw new ArgumentOutOfRangeException("value");
                _deliveryComment = value;
            }
        }

        private string _customerChargeShipVia;
        [FixedLengthField(63, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CustomerChargeShipVia
        {
            get { return _customerChargeShipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _customerChargeShipVia = value;
            }
        }

        private string _customerLoadId;
        [FixedLengthField(64, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string CustomerLoadId
        {
            get { return _customerLoadId; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _customerLoadId = value;
            }
        }

        private long _airbillNumber;
        [FixedLengthField(65, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long AirbillNumber
        {
            get { return _airbillNumber; }
            set
            {
                if(value != default(long) && value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _airbillNumber = value;
            }
        }

        private string _cartonLevelEpc;
        [FixedLengthField(66, 100, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                                                                    ")]
        public string CartonLevelEpc
        {
            get { return _cartonLevelEpc; }
            set
            {
                if(value != default(string) && value.Length > 100) throw new ArgumentOutOfRangeException("value");
                _cartonLevelEpc = value;
            }
        }

        private string _palletEpc;
        [FixedLengthField(67, 100, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                                                                    ")]
        public string PalletEpc
        {
            get { return _palletEpc; }
            set
            {
                if(value != default(string) && value.Length > 100) throw new ArgumentOutOfRangeException("value");
                _palletEpc = value;
            }
        }

        private string _miscellaneousIns10Byte1;
        [FixedLengthField(68, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte1
        {
            get { return _miscellaneousIns10Byte1; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte1 = value;
            }
        }

        private string _miscellaneousIns20Byte1;
        [FixedLengthField(69, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte1
        {
            get { return _miscellaneousIns20Byte1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte1 = value;
            }
        }

        private string _miscellaneousIns20Byte2;
        [FixedLengthField(70, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte2
        {
            get { return _miscellaneousIns20Byte2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte2 = value;
            }
        }

        private string _miscellaneousIns5Byte1;
        [FixedLengthField(71, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(72, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(73, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(74, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
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
        [FixedLengthField(75, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(76, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(77, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(78, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte5
        {
            get { return _miscellaneousIns10Byte5; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte5 = value;
            }
        }

        private string _miscellaneousIns20Byte3;
        [FixedLengthField(79, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(80, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(81, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte5
        {
            get { return _miscellaneousIns20Byte5; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte5 = value;
            }
        }

        private string _miscellaneousIns20Byte6;
        [FixedLengthField(82, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte6
        {
            get { return _miscellaneousIns20Byte6; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte6 = value;
            }
        }

        private long _miscellaneousNum1;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(83, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(84, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(85, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(86, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(87, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(88, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private string _recordExpansionField;
        [FixedLengthField(89, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
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
        [FixedLengthField(90, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _hostApointmentNumber;
        [FixedLengthField(91, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string HostApointmentNumber
        {
            get { return _hostApointmentNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _hostApointmentNumber = value;
            }
        }

        private int _cartonLength;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(92, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CartonLength_Backing
        {
            get { return _cartonLength; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cartonLength = value;
            }
        }
        public decimal CartonLength
        {
            get { return CartonLength_Backing / 100.0m; }
            set { CartonLength_Backing = (int)(value * 100.0m); }
        }

        private int _cartonWidth;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(93, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CartonWidth_Backing
        {
            get { return _cartonWidth; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cartonWidth = value;
            }
        }
        public decimal CartonWidth
        {
            get { return CartonWidth_Backing / 100.0m; }
            set { CartonWidth_Backing = (int)(value * 100.0m); }
        }

        private int _cartonHeight;
        [Write(false)] // dapper attribute specifying not to write this property to the database
        [FixedLengthField(94, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int CartonHeight_Backing
        {
            get { return _cartonHeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _cartonHeight = value;
            }
        }
        public decimal CartonHeight
        {
            get { return CartonHeight_Backing / 100.0m; }
            set { CartonHeight_Backing = (int)(value * 100.0m); }
        }

        private string _batchLabelPrintNumber;
        [FixedLengthField(95, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string BatchLabelPrintNumber
        {
            get { return _batchLabelPrintNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _batchLabelPrintNumber = value;
            }
        }

        private int _batchLabelCartonX;
        [FixedLengthField(96, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int BatchLabelCartonX
        {
            get { return _batchLabelCartonX; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _batchLabelCartonX = value;
            }
        }

        private int _batchLabelCartonY;
        [FixedLengthField(97, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int BatchLabelCartonY
        {
            get { return _batchLabelCartonY; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _batchLabelCartonY = value;
            }
        }

         [Write(false)] // dapper attribute specifying not to write this property to the database
         public int TotalFileLength { get { return 1391; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
