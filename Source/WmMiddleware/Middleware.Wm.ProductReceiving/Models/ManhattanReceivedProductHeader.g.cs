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
    internal partial class ManhattanReceivedProductHeader
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
        // Always "3"
        private string _asnType;
        [FixedLengthField(8, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
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
        // Container ID
        private string _shipmentNumber;
        [FixedLengthField(9, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(10, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        // Warehouse, "22" for Lawrence, "33" for Ontario
        private string _toLocation;
        [FixedLengthField(11, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ToLocation
        {
            get { return _toLocation; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _toLocation = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _wholesalerTransferFlag;
        [FixedLengthField(12, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string WholesalerTransferFlag
        {
            get { return _wholesalerTransferFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _wholesalerTransferFlag = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _qcHoldUponReceipt;
        [FixedLengthField(13, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string QcHoldUponReceipt
        {
            get { return _qcHoldUponReceipt; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _qcHoldUponReceipt = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _systemCreated;
        [FixedLengthField(14, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SystemCreated
        {
            get { return _systemCreated; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _systemCreated = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _outSourceFlag;
        [FixedLengthField(15, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string OutSourceFlag
        {
            get { return _outSourceFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _outSourceFlag = value;
            }
        }

        private string _manufacturingPlant;
        [FixedLengthField(16, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ManufacturingPlant
        {
            get { return _manufacturingPlant; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _manufacturingPlant = value;
            }
        }

        private string _shipmentType;
        [FixedLengthField(17, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ShipmentType
        {
            get { return _shipmentType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shipmentType = value;
            }
        }

        private string _shipmentVehicleType;
        [FixedLengthField(18, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShipmentVehicleType
        {
            get { return _shipmentVehicleType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipmentVehicleType = value;
            }
        }

        private string _shipVia;
        [FixedLengthField(19, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ShipVia
        {
            get { return _shipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipVia = value;
            }
        }

        private string _manifestNumber;
        [FixedLengthField(20, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ManifestNumber
        {
            get { return _manifestNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _manifestNumber = value;
            }
        }

        private string _billOfLading;
        [FixedLengthField(21, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string BillOfLading
        {
            get { return _billOfLading; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _billOfLading = value;
            }
        }

        private string _trailerNumber;
        [FixedLengthField(22, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string TrailerNumber
        {
            get { return _trailerNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _trailerNumber = value;
            }
        }

        private string _scacCode;
        [FixedLengthField(23, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ScacCode
        {
            get { return _scacCode; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _scacCode = value;
            }
        }

        private string _sealNumber;
        [FixedLengthField(24, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string SealNumber
        {
            get { return _sealNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _sealNumber = value;
            }
        }

        private string _proNumber;
        [FixedLengthField(25, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ProNumber
        {
            get { return _proNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _proNumber = value;
            }
        }

        private string _workOrderNumber;
        [FixedLengthField(26, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string WorkOrderNumber
        {
            get { return _workOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _workOrderNumber = value;
            }
        }

        private string _cutNumber;
        [FixedLengthField(27, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string CutNumber
        {
            get { return _cutNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _cutNumber = value;
            }
        }

        private string _orderNumber;
        [FixedLengthField(28, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(29, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string OrderSuffix
        {
            get { return _orderSuffix; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _orderSuffix = value;
            }
        }

        private string _receivedFrom;
        [FixedLengthField(30, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ReceivedFrom
        {
            get { return _receivedFrom; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _receivedFrom = value;
            }
        }

        private string _vendorName;
        [FixedLengthField(31, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string VendorName
        {
            get { return _vendorName; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _vendorName = value;
            }
        }

        private string _address1;
        [FixedLengthField(32, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string Address1
        {
            get { return _address1; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _address1 = value;
            }
        }

        private string _address2;
        [FixedLengthField(33, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string Address2
        {
            get { return _address2; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _address2 = value;
            }
        }

        private string _address3;
        [FixedLengthField(34, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string Address3
        {
            get { return _address3; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _address3 = value;
            }
        }

        private string _city;
        [FixedLengthField(35, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string City
        {
            get { return _city; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _city = value;
            }
        }

        private string _stateCode;
        [FixedLengthField(36, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string StateCode
        {
            get { return _stateCode; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _stateCode = value;
            }
        }

        private string _zip;
        [FixedLengthField(37, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string Zip
        {
            get { return _zip; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _zip = value;
            }
        }

        private string _telephoneNumber;
        [FixedLengthField(38, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _telephoneNumber = value;
            }
        }

        private string _buyerCode;
        [FixedLengthField(39, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string BuyerCode
        {
            get { return _buyerCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _buyerCode = value;
            }
        }

        private string _representativeName;
        [FixedLengthField(40, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string RepresentativeName
        {
            get { return _representativeName; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _representativeName = value;
            }
        }

        private string _pathNumber;
        [FixedLengthField(41, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string PathNumber
        {
            get { return _pathNumber; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _pathNumber = value;
            }
        }

        private int _numberOfCases;
        [FixedLengthField(42, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int NumberOfCases
        {
            get { return _numberOfCases; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _numberOfCases = value;
            }
        }

        private long _numberOfUnits;
        [FixedLengthField(43, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long NumberOfUnits_Backing
        {
            get { return _numberOfUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _numberOfUnits = value;
            }
        }
        public decimal NumberOfUnits
        {
            get { return NumberOfUnits_Backing / 10000.0m; }
            set { NumberOfUnits_Backing = (int)(value * 10000.0m); }
        }

        private long _totalWeight;
        [FixedLengthField(44, 15, PaddingChar = '0', Padding = Padding.Left)]
        public long TotalWeight_Backing
        {
            get { return _totalWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _totalWeight = value;
            }
        }
        public decimal TotalWeight
        {
            get { return TotalWeight_Backing / 100000.0m; }
            set { TotalWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _carrierCharge;
        [FixedLengthField(45, 19, PaddingChar = '0', Padding = Padding.Left)]
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

        private string _dcOrderNumber;
        [FixedLengthField(46, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string DcOrderNumber
        {
            get { return _dcOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _dcOrderNumber = value;
            }
        }

        private string _contractorLocation;
        [FixedLengthField(47, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ContractorLocation
        {
            get { return _contractorLocation; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _contractorLocation = value;
            }
        }

        private int _casesShipped;
        [FixedLengthField(48, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int CasesShipped
        {
            get { return _casesShipped; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _casesShipped = value;
            }
        }

        private long _unitsShipped;
        [FixedLengthField(49, 15, PaddingChar = '0', Padding = Padding.Left)]
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

        private int _shippedDate;
        [FixedLengthField(50, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ShippedDate
        {
            get { return _shippedDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _shippedDate = value;
            }
        }

        private int _scheduledStartRecieveDate;
        [FixedLengthField(51, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ScheduledStartRecieveDate
        {
            get { return _scheduledStartRecieveDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduledStartRecieveDate = value;
            }
        }

        private int _scheduledStartRecieveTime;
        [FixedLengthField(52, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int ScheduledStartRecieveTime
        {
            get { return _scheduledStartRecieveTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _scheduledStartRecieveTime = value;
            }
        }

        private int _scheduledEndReceiveDate;
        [FixedLengthField(53, 9, PaddingChar = '0', Padding = Padding.Left)]
        public int ScheduledEndReceiveDate
        {
            get { return _scheduledEndReceiveDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduledEndReceiveDate = value;
            }
        }

        private int _scheduledEndReceiveTime;
        [FixedLengthField(54, 7, PaddingChar = '0', Padding = Padding.Left)]
        public int ScheduledEndReceiveTime
        {
            get { return _scheduledEndReceiveTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _scheduledEndReceiveTime = value;
            }
        }

        private string _shipmentPriority;
        [FixedLengthField(55, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ShipmentPriority
        {
            get { return _shipmentPriority; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shipmentPriority = value;
            }
        }

        private string _statusCode;
        [FixedLengthField(56, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _statusCode = value;
            }
        }

        private string _referenceCode1;
        [FixedLengthField(57, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReferenceCode1
        {
            get { return _referenceCode1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode1 = value;
            }
        }

        private string _reference1;
        [FixedLengthField(58, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Reference1
        {
            get { return _reference1; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference1 = value;
            }
        }

        private string _referenceCode2;
        [FixedLengthField(59, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReferenceCode2
        {
            get { return _referenceCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode2 = value;
            }
        }

        private string _reference2;
        [FixedLengthField(60, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Reference2
        {
            get { return _reference2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference2 = value;
            }
        }

        private string _referenceCode3;
        [FixedLengthField(61, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ReferenceCode3
        {
            get { return _referenceCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _referenceCode3 = value;
            }
        }

        private string _reference3;
        [FixedLengthField(62, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Reference3
        {
            get { return _reference3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _reference3 = value;
            }
        }

        private string _splInstr1;
        [FixedLengthField(63, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstr1
        {
            get { return _splInstr1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstr1 = value;
            }
        }

        private string _splInstr2;
        [FixedLengthField(64, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstr2
        {
            get { return _splInstr2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstr2 = value;
            }
        }

        private string _splInstr3;
        [FixedLengthField(65, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstr3
        {
            get { return _splInstr3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstr3 = value;
            }
        }

        private string _splInstr4;
        [FixedLengthField(66, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SplInstr4
        {
            get { return _splInstr4; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _splInstr4 = value;
            }
        }

        private string _misc20ByteField1;
        [FixedLengthField(67, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(68, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Misc20ByteField2
        {
            get { return _misc20ByteField2; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _misc20ByteField2 = value;
            }
        }

        private string _miscellaneousAlphaField3;
        [FixedLengthField(69, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousAlphaField3
        {
            get { return _miscellaneousAlphaField3; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousAlphaField3 = value;
            }
        }

        private string _miscellaneousAlphaField4;
        [FixedLengthField(70, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousAlphaField4
        {
            get { return _miscellaneousAlphaField4; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousAlphaField4 = value;
            }
        }

        private long _miscellaneousNumericField1;
        [FixedLengthField(71, 13, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(72, 13, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(73, 13, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(74, 13, PaddingChar = '0', Padding = Padding.Left)]
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
        [FixedLengthField(75, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
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
        [FixedLengthField(76, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        // Used by New Balance
        // "2" for add or change, "4" for delete
        private string _function;
        [FixedLengthField(77, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Function
        {
            get { return _function; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _function = value;
            }
        }

        private int _stopSequence;
        [FixedLengthField(78, 3, PaddingChar = '0', Padding = Padding.Left)]
        public int StopSequence
        {
            get { return _stopSequence; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _stopSequence = value;
            }
        }

        private string _tractorScac;
        [FixedLengthField(79, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string TractorScac
        {
            get { return _tractorScac; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _tractorScac = value;
            }
        }

        private string _tractorNumber;
        [FixedLengthField(80, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string TractorNumber
        {
            get { return _tractorNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _tractorNumber = value;
            }
        }

        private int _numberOfDetailLines;
        [FixedLengthField(81, 5, PaddingChar = '0', Padding = Padding.Left)]
        public int NumberOfDetailLines
        {
            get { return _numberOfDetailLines; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _numberOfDetailLines = value;
            }
        }

        private string _frameworkId;
        [FixedLengthField(82, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(83, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string FrameworkFlags
        {
            get { return _frameworkFlags; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _frameworkFlags = value;
            }
        }

        private string _hostDataFlag;
        [FixedLengthField(84, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string HostDataFlag
        {
            get { return _hostDataFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _hostDataFlag = value;
            }
        }

    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
