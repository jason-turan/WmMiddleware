using System;
using System.Globalization;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace WmMiddleware.Picking.Models
{
    // Generated with FlatFileClassGenerator
    [FixedLengthFile]
    internal partial class ManhattanPickTicketHeader
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
        // date created
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
        // time created
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

        private string _programId;
        [FixedLengthField(8, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // company number
        private string _company;
        [FixedLengthField(9, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(10, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(11, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        // Do Not Ship Before Date in MM/DD/YY format
        private string _pickticketNumber;
        [FixedLengthField(13, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string PickticketNumber
        {
            get { return _pickticketNumber; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _pickticketNumber = value;
            }
        }

        // Used by New Balance
        // Same as PHOTYP, position 3 has "*" if prepack.
        private string _pickticketSuffix;
        [FixedLengthField(14, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string PickticketSuffix
        {
            get { return _pickticketSuffix; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _pickticketSuffix = value;
            }
        }

        // Used by New Balance
        // Order number without shipment seq #
        private string _orderNumber;
        [FixedLengthField(15, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string OrderNumber
        {
            get { return _orderNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _orderNumber = value;
            }
        }

        // Used by New Balance
        // PPK for prepack, MIX if 1st quality and demos, DEM if demos, blank if none of the above, "ERR" for DOB errors - probably not needed with SAP
        private string _orderSuffix;
        [FixedLengthField(16, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string OrderSuffix
        {
            get { return _orderSuffix; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _orderSuffix = value;
            }
        }

        // Used by New Balance
        // VERY CRITICAL FIELD.  This field is used in identifying orders and for wave planning.  Official documentation exists in "H:\IT\Documentation\Warehouse\WMS Order TypeXRef - MA.doc".  This will identify: DOBs, Rush Orders, Rate Shopping, Non Shoes (Apparel, Accessories, Other), Samples, 24 Hours, Team Priority, Consumer Drop Ship, EDI Quick Response, Weekly Replens, Team Dealer, Dealers, Single Unit, Greater than 90 units, all others.
        private string _orderType;
        [FixedLengthField(17, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string OrderType
        {
            get { return _orderType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _orderType = value;
            }
        }

        // Used by New Balance
        // Delivery sequence, if DC Association exists must be the DCs delivery seq
        private string _shipTo;
        [FixedLengthField(18, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string ShipTo
        {
            get { return _shipTo; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _shipTo = value;
            }
        }

        // Used by New Balance
        // DC Assoc Name, else drop ship name, else regular ship to name
        private string _shipToName;
        [FixedLengthField(19, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToName
        {
            get { return _shipToName; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToName = value;
            }
        }

        private string _shipToName2;
        [FixedLengthField(20, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToName2
        {
            get { return _shipToName2; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToName2 = value;
            }
        }

        // Used by New Balance
        // All Ship to address logic populates based on these rules:  (1) If DC Association exists use DC, (2) If drop ship override exists use drop ship, (3) Catch All, use regular customer master ship to address
        private string _shipToAddr1;
        [FixedLengthField(21, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToAddr1
        {
            get { return _shipToAddr1; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToAddr1 = value;
            }
        }

        // Used by New Balance
        // All Ship to address logic populates based on these rules:  (1) If DC Association exists use DC, (2) If drop ship override exists use drop ship, (3) Catch All, use regular customer master ship to address
        private string _shipToAddr2;
        [FixedLengthField(22, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToAddr2
        {
            get { return _shipToAddr2; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToAddr2 = value;
            }
        }

        private string _shipToAddr3;
        [FixedLengthField(23, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToAddr3
        {
            get { return _shipToAddr3; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToAddr3 = value;
            }
        }

        // Used by New Balance
        // All Ship to address logic populates based on these rules:  (1) If DC Association exists use DC, (2) If drop ship override exists use drop ship, (3) Catch All, use regular customer master ship to address
        private string _shipToCity;
        [FixedLengthField(24, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string ShipToCity
        {
            get { return _shipToCity; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _shipToCity = value;
            }
        }

        // Used by New Balance
        // All Ship to address logic populates based on these rules:  (1) If DC Association exists use DC, (2) If drop ship override exists use drop ship, (3) Catch All, use regular customer master ship to address
        private string _shipToState;
        [FixedLengthField(25, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ShipToState
        {
            get { return _shipToState; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _shipToState = value;
            }
        }

        // Used by New Balance
        // All Ship to address logic populates based on these rules:  (1) If DC Association exists use DC, (2) If drop ship override exists use drop ship, (3) Catch All, use regular customer master ship to address
        private string _shipToZip;
        [FixedLengthField(26, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string ShipToZip
        {
            get { return _shipToZip; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _shipToZip = value;
            }
        }

        // Used by New Balance
        // Must be ISO compliant
        private string _shipToCountry;
        [FixedLengthField(27, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ShipToCountry
        {
            get { return _shipToCountry; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipToCountry = value;
            }
        }

        private string _shiptoFaxNumber;
        [FixedLengthField(28, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string ShiptoFaxNumber
        {
            get { return _shiptoFaxNumber; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _shiptoFaxNumber = value;
            }
        }

        // Used by New Balance
        // Customer number
        private string _soldTo;
        [FixedLengthField(29, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string SoldTo
        {
            get { return _soldTo; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _soldTo = value;
            }
        }

        // Used by New Balance
        // Bill to "000" name
        private string _soldToName;
        [FixedLengthField(30, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToName
        {
            get { return _soldToName; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToName = value;
            }
        }

        private string _soldToName2;
        [FixedLengthField(31, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToName2
        {
            get { return _soldToName2; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToName2 = value;
            }
        }

        // Used by New Balance
        // Bill to info
        private string _soldToAddr1;
        [FixedLengthField(32, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToAddr1
        {
            get { return _soldToAddr1; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToAddr1 = value;
            }
        }

        // Used by New Balance
        // Bill to info
        private string _soldToAddr2;
        [FixedLengthField(33, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToAddr2
        {
            get { return _soldToAddr2; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToAddr2 = value;
            }
        }

        private string _soldToAddr3;
        [FixedLengthField(34, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToAddr3
        {
            get { return _soldToAddr3; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToAddr3 = value;
            }
        }

        // Used by New Balance
        // Bill to info
        private string _soldToCity;
        [FixedLengthField(35, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string SoldToCity
        {
            get { return _soldToCity; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _soldToCity = value;
            }
        }

        // Used by New Balance
        // Bill to info
        private string _soldToState;
        [FixedLengthField(36, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string SoldToState
        {
            get { return _soldToState; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _soldToState = value;
            }
        }

        // Used by New Balance
        // Bill to info
        private string _soldToZip;
        [FixedLengthField(37, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string SoldToZip
        {
            get { return _soldToZip; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _soldToZip = value;
            }
        }

        // Used by New Balance
        // Hard Coded (555) 555 - 5555
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

        // Used by New Balance
        // Must be ISO compliant
        private string _soldToCountry;
        [FixedLengthField(39, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string SoldToCountry
        {
            get { return _soldToCountry; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _soldToCountry = value;
            }
        }

        private string _dcCenterNumber;
        [FixedLengthField(40, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string DcCenterNumber
        {
            get { return _dcCenterNumber; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _dcCenterNumber = value;
            }
        }

        private string _logicalWarehouse;
        [FixedLengthField(41, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string LogicalWarehouse
        {
            get { return _logicalWarehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _logicalWarehouse = value;
            }
        }

        private string _transferWarehouses;
        [FixedLengthField(42, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TransferWarehouses
        {
            get { return _transferWarehouses; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _transferWarehouses = value;
            }
        }

        private string _warehouseTransferType;
        [FixedLengthField(43, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string WarehouseTransferType
        {
            get { return _warehouseTransferType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _warehouseTransferType = value;
            }
        }

        private string _businessDivision;
        [FixedLengthField(44, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string BusinessDivision
        {
            get { return _businessDivision; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _businessDivision = value;
            }
        }

        // Used by New Balance
        // Customer number
        private string _arAccountNumber;
        [FixedLengthField(45, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string ArAccountNumber
        {
            get { return _arAccountNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _arAccountNumber = value;
            }
        }

        private string _arCode;
        [FixedLengthField(46, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ArCode
        {
            get { return _arCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _arCode = value;
            }
        }

        // Used by New Balance
        // Customer PO number
        private string _customerPurchaseOrderNumber;
        [FixedLengthField(47, 26, PaddingChar = ' ', Padding = Padding.Right, NullValue="                          ")]
        public string CustomerPurchaseOrderNumber
        {
            get { return _customerPurchaseOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 26) throw new ArgumentOutOfRangeException("value");
                _customerPurchaseOrderNumber = value;
            }
        }

        // Used by New Balance
        // JBA Customer's Division
        private string _customerDepartment;
        [FixedLengthField(48, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue="        ")]
        public string CustomerDepartment
        {
            get { return _customerDepartment; }
            set
            {
                if(value != default(string) && value.Length > 8) throw new ArgumentOutOfRangeException("value");
                _customerDepartment = value;
            }
        }

        private string _verifyCartonContents;
        [FixedLengthField(49, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string VerifyCartonContents
        {
            get { return _verifyCartonContents; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _verifyCartonContents = value;
            }
        }

        private int _numberOfTimesApptChg;
        [FixedLengthField(50, 1, PaddingChar = '0', Padding = Padding.Left, NullValue="0")]
        public int NumberOfTimesApptChg
        {
            get { return _numberOfTimesApptChg; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 1) throw new ArgumentOutOfRangeException("value");
                _numberOfTimesApptChg = value;
            }
        }

        private int _appointmentDate;
        [FixedLengthField(51, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
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
        [FixedLengthField(52, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ApptMadeById
        {
            get { return _apptMadeById; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _apptMadeById = value;
            }
        }

        // Used by New Balance
        // Customer's Store Number
        private string _storeNumber;
        [FixedLengthField(53, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string StoreNumber
        {
            get { return _storeNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeNumber = value;
            }
        }

        private string _storeType;
        [FixedLengthField(54, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string StoreType
        {
            get { return _storeType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _storeType = value;
            }
        }

        private string _advertisingCode;
        [FixedLengthField(55, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string AdvertisingCode
        {
            get { return _advertisingCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _advertisingCode = value;
            }
        }

        private int _advertisingDate;
        [FixedLengthField(56, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int AdvertisingDate
        {
            get { return _advertisingDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _advertisingDate = value;
            }
        }

        private string _merchandiseCode;
        [FixedLengthField(57, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string MerchandiseCode
        {
            get { return _merchandiseCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _merchandiseCode = value;
            }
        }

        private string _merchandiseClass;
        [FixedLengthField(58, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string MerchandiseClass
        {
            get { return _merchandiseClass; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _merchandiseClass = value;
            }
        }

        // Used by New Balance
        // Same as company number above PHCO
        private string _merchandiseCompany;
        [FixedLengthField(59, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MerchandiseCompany
        {
            get { return _merchandiseCompany; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _merchandiseCompany = value;
            }
        }

        // Used by New Balance
        // If Carrier is Canadian, identified by table MRDV in NMAP050, check division/brand combo or carrier/brand combo, put the brand and canada identifier: NBACAN, ARACAN, DUNCAN, PFFCAN.  If not a Canadian carrier put in the brand description: ARAVON, DUNHAM, PFLYER, blanks for New Balance.
        private string _merchandiseDivision;
        [FixedLengthField(60, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MerchandiseDivision
        {
            get { return _merchandiseDivision; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _merchandiseDivision = value;
            }
        }

        // Used by New Balance
        // Customer's vendor
        private string _vendorNumber;
        [FixedLengthField(61, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string VendorNumber
        {
            get { return _vendorNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _vendorNumber = value;
            }
        }

        // Used by New Balance
        // If pick is rate shopped this must be blanks.  If a routing guide is the carrier this must be blanks (USPS is a special case on JBA where it is flagged as a routing guide but makes use of the rate shopping / service level functionality).  If the pick is dynamic routing this must be blanks.  Residential ship vias must be given careful attention.  It is handled on JBA by a flag on the order.  An "R" is placed in position 4 of this field if the pick is residential.
        private string _shipVia;
        [FixedLengthField(62, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ShipVia
        {
            get { return _shipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _shipVia = value;
            }
        }

        private string _billingShipVia;
        [FixedLengthField(63, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string BillingShipVia
        {
            get { return _billingShipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _billingShipVia = value;
            }
        }

        private string _outboundShipmentGroupingCode;
        [FixedLengthField(64, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string OutboundShipmentGroupingCode
        {
            get { return _outboundShipmentGroupingCode; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _outboundShipmentGroupingCode = value;
            }
        }

        private string _thirdPartyBill;
        [FixedLengthField(65, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string ThirdPartyBill
        {
            get { return _thirdPartyBill; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _thirdPartyBill = value;
            }
        }

        private string _salesmanNumber;
        [FixedLengthField(66, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string SalesmanNumber
        {
            get { return _salesmanNumber; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _salesmanNumber = value;
            }
        }

        private string _priorityCode;
        [FixedLengthField(67, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PriorityCode
        {
            get { return _priorityCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _priorityCode = value;
            }
        }

        private string _prioritySuffix;
        [FixedLengthField(68, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PrioritySuffix
        {
            get { return _prioritySuffix; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _prioritySuffix = value;
            }
        }

        // Used by New Balance
        // JBA Current Territory SLP05.REGN05  
        private string _territoryCode;
        [FixedLengthField(69, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TerritoryCode
        {
            get { return _territoryCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _territoryCode = value;
            }
        }

        // Used by New Balance
        // JBA Sales Channel
        private string _managingTerritory;
        [FixedLengthField(70, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ManagingTerritory
        {
            get { return _managingTerritory; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _managingTerritory = value;
            }
        }

        // Used by New Balance
        // Original Co and SVIA
        private string _salesGroup;
        [FixedLengthField(71, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string SalesGroup
        {
            get { return _salesGroup; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _salesGroup = value;
            }
        }

        private string _markFor;
        [FixedLengthField(72, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue="                         ")]
        public string MarkFor
        {
            get { return _markFor; }
            set
            {
                if(value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _markFor = value;
            }
        }

        // Used by New Balance
        // Do Not Ship Before Date (WM internal format not the same as PHPKTN)
        private int _orderDate;
        [FixedLengthField(73, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int OrderDate
        {
            get { return _orderDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _orderDate = value;
            }
        }

        // Used by New Balance
        // Pick Ticket Create Date
        private int _pickticketGenerationDate;
        [FixedLengthField(74, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int PickticketGenerationDate
        {
            get { return _pickticketGenerationDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _pickticketGenerationDate = value;
            }
        }

        // Used by New Balance
        // Order Request Date
        private int _startShipDate;
        [FixedLengthField(75, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int StartShipDate
        {
            get { return _startShipDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _startShipDate = value;
            }
        }

        // Used by New Balance
        // Order Cancel Date
        private int _stopShipDate;
        [FixedLengthField(76, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int StopShipDate
        {
            get { return _stopShipDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _stopShipDate = value;
            }
        }

        private int _cancelDate;
        [FixedLengthField(77, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int CancelDate
        {
            get { return _cancelDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _cancelDate = value;
            }
        }

        private int _allocShipDate;
        [FixedLengthField(78, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int AllocShipDate
        {
            get { return _allocShipDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _allocShipDate = value;
            }
        }

        // Used by New Balance
        // This field is used for Rate Shopping (and the USPS special case, USPS keeps this zero).  The complex Rate Shopping logic uses a UPS holiday table to make sure it never selects a delivery date that is a UPS holiday.  The Rate Shopping program on JBA tells the pick what to populate here.  For Friday Guarantee it calculates the next available Friday.  For XPS it calculates 2 days for morning drops, 3 days for afternoon drops.
        private int _scheduleDeliveryDate;
        [FixedLengthField(79, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ScheduleDeliveryDate
        {
            get { return _scheduleDeliveryDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduleDeliveryDate = value;
            }
        }

        private string _shipmentTypeDi;
        [FixedLengthField(80, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShipmentTypeDi
        {
            get { return _shipmentTypeDi; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipmentTypeDi = value;
            }
        }

        private string _termsCode;
        [FixedLengthField(81, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string TermsCode
        {
            get { return _termsCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _termsCode = value;
            }
        }

        private string _termsDescription;
        [FixedLengthField(82, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string TermsDescription
        {
            get { return _termsDescription; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _termsDescription = value;
            }
        }

        private int _termsPercent;
        [FixedLengthField(83, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int TermsPercent_Backing
        {
            get { return _termsPercent; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _termsPercent = value;
            }
        }
        public decimal TermsPercent
        {
            get { return TermsPercent_Backing / 100.0m; }
            set { TermsPercent_Backing = (int)(value * 100.0m); }
        }

        private string _preStickerCode;
        [FixedLengthField(84, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PreStickerCode
        {
            get { return _preStickerCode; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _preStickerCode = value;
            }
        }

        private string _shipWithControlNumber;
        [FixedLengthField(85, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string ShipWithControlNumber
        {
            get { return _shipWithControlNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _shipWithControlNumber = value;
            }
        }

        // Used by New Balance
        // If line is "Other" 52, else check NB specific database NOEP087 entries in here dictate whether the bridge value should be 65 (SKU level and 5 SKUs per carton (JCP Requirement)), 63 (SKU), 62 (Width), 61 (Style).   Default is 51 if no record in NOEP087.
        private string _printCode;
        [FixedLengthField(86, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PrintCode
        {
            get { return _printCode; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _printCode = value;
            }
        }

        private string _customerPrePack;
        [FixedLengthField(87, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CustomerPrePack
        {
            get { return _customerPrePack; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _customerPrePack = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default type set up in table entry.
        private string _cartonLabelType;
        [FixedLengthField(88, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CartonLabelType
        {
            get { return _cartonLabelType; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _cartonLabelType = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default is 1.
        private int _numberOfCartonLabels;
        [FixedLengthField(89, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int NumberOfCartonLabels
        {
            get { return _numberOfCartonLabels; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _numberOfCartonLabels = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default type set up in table entry.
        private string _contentLabelType;
        [FixedLengthField(90, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ContentLabelType
        {
            get { return _contentLabelType; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _contentLabelType = value;
            }
        }

        private int _numberOfContLabels;
        [FixedLengthField(91, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int NumberOfContLabels
        {
            get { return _numberOfContLabels; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _numberOfContLabels = value;
            }
        }

        private string _waveLabelType;
        [FixedLengthField(92, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string WaveLabelType
        {
            get { return _waveLabelType; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _waveLabelType = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default is 1.
        private int _numberOfPackingSlips;
        [FixedLengthField(93, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int NumberOfPackingSlips
        {
            get { return _numberOfPackingSlips; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _numberOfPackingSlips = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default type set up in table entry.
        private string _packingSlipType;
        [FixedLengthField(94, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PackingSlipType
        {
            get { return _packingSlipType; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _packingSlipType = value;
            }
        }

        // Used by New Balance
        // Always "00"
        private string _pickticketStatus;
        [FixedLengthField(95, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PickticketStatus
        {
            get { return _pickticketStatus; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _pickticketStatus = value;
            }
        }

        private string _packHoldFlag;
        [FixedLengthField(96, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PackHoldFlag
        {
            get { return _packHoldFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _packHoldFlag = value;
            }
        }

        private string _invoiceInCarton;
        [FixedLengthField(97, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string InvoiceInCarton
        {
            get { return _invoiceInCarton; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _invoiceInCarton = value;
            }
        }

        private string _autoInvoiceStatus;
        [FixedLengthField(98, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string AutoInvoiceStatus
        {
            get { return _autoInvoiceStatus; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _autoInvoiceStatus = value;
            }
        }

        // Used by New Balance
        // If routing guide = "Y", If dynamic routing = "Y", else "N"
        private string _customerRouting;
        [FixedLengthField(99, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CustomerRouting
        {
            get { return _customerRouting; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _customerRouting = value;
            }
        }

        private string _routingAttribute;
        [FixedLengthField(100, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue="                              ")]
        public string RoutingAttribute
        {
            get { return _routingAttribute; }
            set
            {
                if(value != default(string) && value.Length > 30) throw new ArgumentOutOfRangeException("value");
                _routingAttribute = value;
            }
        }

        private string _routeTo;
        [FixedLengthField(101, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string RouteTo
        {
            get { return _routeTo; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _routeTo = value;
            }
        }

        private string _routingType1;
        [FixedLengthField(102, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string RoutingType1
        {
            get { return _routingType1; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _routingType1 = value;
            }
        }

        private string _routingType2;
        [FixedLengthField(103, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string RoutingType2
        {
            get { return _routingType2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _routingType2 = value;
            }
        }

        private string _routingZip;
        [FixedLengthField(104, 11, PaddingChar = ' ', Padding = Padding.Right, NullValue="           ")]
        public string RoutingZip
        {
            get { return _routingZip; }
            set
            {
                if(value != default(string) && value.Length > 11) throw new ArgumentOutOfRangeException("value");
                _routingZip = value;
            }
        }

        private string _routedSwcNumber;
        [FixedLengthField(105, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string RoutedSwcNumber
        {
            get { return _routedSwcNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _routedSwcNumber = value;
            }
        }

        // Used by New Balance
        // 1 if order has single unit, else 0
        private string _singleItemOrder;
        [FixedLengthField(106, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SingleItemOrder
        {
            get { return _singleItemOrder; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _singleItemOrder = value;
            }
        }

        private long _estimatedWeightBridged;
        [FixedLengthField(107, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long EstimatedWeightBridged_Backing
        {
            get { return _estimatedWeightBridged; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _estimatedWeightBridged = value;
            }
        }
        public decimal EstimatedWeightBridged
        {
            get { return EstimatedWeightBridged_Backing / 100000.0m; }
            set { EstimatedWeightBridged_Backing = (int)(value * 100000.0m); }
        }

        private int _estimatedCartonsBridged;
        [FixedLengthField(108, 7, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000")]
        public int EstimatedCartonsBridged
        {
            get { return _estimatedCartonsBridged; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 7) throw new ArgumentOutOfRangeException("value");
                _estimatedCartonsBridged = value;
            }
        }

        private long _estimatedVolumeBridged;
        [FixedLengthField(109, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long EstimatedVolumeBridged_Backing
        {
            get { return _estimatedVolumeBridged; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _estimatedVolumeBridged = value;
            }
        }
        public decimal EstimatedVolumeBridged
        {
            get { return EstimatedVolumeBridged_Backing / 100000.0m; }
            set { EstimatedVolumeBridged_Backing = (int)(value * 100000.0m); }
        }

        private long _totNumberOfUnits;
        [FixedLengthField(110, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long TotNumberOfUnits_Backing
        {
            get { return _totNumberOfUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _totNumberOfUnits = value;
            }
        }
        public decimal TotNumberOfUnits
        {
            get { return TotNumberOfUnits_Backing / 10000.0m; }
            set { TotNumberOfUnits_Backing = (int)(value * 10000.0m); }
        }

        private long _totDlrsUndiscntd;
        [FixedLengthField(111, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long TotDlrsUndiscntd_Backing
        {
            get { return _totDlrsUndiscntd; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _totDlrsUndiscntd = value;
            }
        }
        public decimal TotDlrsUndiscntd
        {
            get { return TotDlrsUndiscntd_Backing / 10000.0m; }
            set { TotDlrsUndiscntd_Backing = (int)(value * 10000.0m); }
        }

        private long _totDlrsDiscounted;
        [FixedLengthField(112, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long TotDlrsDiscounted_Backing
        {
            get { return _totDlrsDiscounted; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _totDlrsDiscounted = value;
            }
        }
        public decimal TotDlrsDiscounted
        {
            get { return TotDlrsDiscounted_Backing / 10000.0m; }
            set { TotDlrsDiscounted_Backing = (int)(value * 10000.0m); }
        }

        // Used by New Balance
        // Currency from customer master
        private string _tpeCurrencyCode;
        [FixedLengthField(113, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string TpeCurrencyCode
        {
            get { return _tpeCurrencyCode; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _tpeCurrencyCode = value;
            }
        }

        private int _discountDate;
        [FixedLengthField(114, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int DiscountDate
        {
            get { return _discountDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _discountDate = value;
            }
        }

        private int _numberOfHangers;
        [FixedLengthField(115, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int NumberOfHangers
        {
            get { return _numberOfHangers; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _numberOfHangers = value;
            }
        }

        private string _route;
        [FixedLengthField(116, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string Route
        {
            get { return _route; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _route = value;
            }
        }

        private int _routeSequenceNumber;
        [FixedLengthField(117, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int RouteSequenceNumber
        {
            get { return _routeSequenceNumber; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _routeSequenceNumber = value;
            }
        }

        private string _billOfLadingType;
        [FixedLengthField(118, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string BillOfLadingType
        {
            get { return _billOfLadingType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _billOfLadingType = value;
            }
        }

        private string _trailerNumber;
        [FixedLengthField(119, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string TrailerNumber
        {
            get { return _trailerNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _trailerNumber = value;
            }
        }

        private string _trailerType;
        [FixedLengthField(120, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string TrailerType
        {
            get { return _trailerType; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _trailerType = value;
            }
        }

        private string _trailerSize;
        [FixedLengthField(121, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string TrailerSize
        {
            get { return _trailerSize; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _trailerSize = value;
            }
        }

        private string _shipmentControlFlag;
        [FixedLengthField(122, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ShipmentControlFlag
        {
            get { return _shipmentControlFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _shipmentControlFlag = value;
            }
        }

        private string _codFlag;
        [FixedLengthField(123, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CodFlag
        {
            get { return _codFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _codFlag = value;
            }
        }

        private long _productValue;
        [FixedLengthField(124, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long ProductValue_Backing
        {
            get { return _productValue; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _productValue = value;
            }
        }
        public decimal ProductValue
        {
            get { return ProductValue_Backing / 10000.0m; }
            set { ProductValue_Backing = (int)(value * 10000.0m); }
        }

        private string _recalculateOrderChange;
        [FixedLengthField(125, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string RecalculateOrderChange
        {
            get { return _recalculateOrderChange; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _recalculateOrderChange = value;
            }
        }

        private string _suppressFinancials;
        [FixedLengthField(126, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SuppressFinancials
        {
            get { return _suppressFinancials; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _suppressFinancials = value;
            }
        }

        private long _creditAmount;
        [FixedLengthField(127, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long CreditAmount_Backing
        {
            get { return _creditAmount; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _creditAmount = value;
            }
        }
        public decimal CreditAmount
        {
            get { return CreditAmount_Backing / 10000.0m; }
            set { CreditAmount_Backing = (int)(value * 10000.0m); }
        }

        private long _orderCharge;
        [FixedLengthField(128, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long OrderCharge_Backing
        {
            get { return _orderCharge; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _orderCharge = value;
            }
        }
        public decimal OrderCharge
        {
            get { return OrderCharge_Backing / 10000.0m; }
            set { OrderCharge_Backing = (int)(value * 10000.0m); }
        }

        private long _handlingCharges;
        [FixedLengthField(129, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long HandlingCharges_Backing
        {
            get { return _handlingCharges; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _handlingCharges = value;
            }
        }
        public decimal HandlingCharges
        {
            get { return HandlingCharges_Backing / 10000.0m; }
            set { HandlingCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _insuranceCharges;
        [FixedLengthField(130, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long InsuranceCharges_Backing
        {
            get { return _insuranceCharges; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _insuranceCharges = value;
            }
        }
        public decimal InsuranceCharges
        {
            get { return InsuranceCharges_Backing / 10000.0m; }
            set { InsuranceCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _taxCharges;
        [FixedLengthField(131, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long TaxCharges_Backing
        {
            get { return _taxCharges; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _taxCharges = value;
            }
        }
        public decimal TaxCharges
        {
            get { return TaxCharges_Backing / 10000.0m; }
            set { TaxCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _miscellaneousCharges;
        [FixedLengthField(132, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long MiscellaneousCharges_Backing
        {
            get { return _miscellaneousCharges; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _miscellaneousCharges = value;
            }
        }
        public decimal MiscellaneousCharges
        {
            get { return MiscellaneousCharges_Backing / 10000.0m; }
            set { MiscellaneousCharges_Backing = (int)(value * 10000.0m); }
        }

        private long _pickticketWageValue;
        [FixedLengthField(133, 19, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000000000")]
        public long PickticketWageValue_Backing
        {
            get { return _pickticketWageValue; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 19) throw new ArgumentOutOfRangeException("value");
                _pickticketWageValue = value;
            }
        }
        public decimal PickticketWageValue
        {
            get { return PickticketWageValue_Backing / 10000.0m; }
            set { PickticketWageValue_Backing = (int)(value * 10000.0m); }
        }

        private int _pickerStdHours;
        [FixedLengthField(134, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int PickerStdHours_Backing
        {
            get { return _pickerStdHours; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _pickerStdHours = value;
            }
        }
        public decimal PickerStdHours
        {
            get { return PickerStdHours_Backing / 100.0m; }
            set { PickerStdHours_Backing = (int)(value * 100.0m); }
        }

        private string _cartonAsnRequired;
        [FixedLengthField(135, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CartonAsnRequired
        {
            get { return _cartonAsnRequired; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _cartonAsnRequired = value;
            }
        }

        private string _asnMethod;
        [FixedLengthField(136, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string AsnMethod
        {
            get { return _asnMethod; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _asnMethod = value;
            }
        }

        // Used by New Balance
        // Always "Y"
        private string _sku100Inventory;
        [FixedLengthField(137, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Sku100Inventory
        {
            get { return _sku100Inventory; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _sku100Inventory = value;
            }
        }

        private string _crossDockPickticket;
        [FixedLengthField(138, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CrossDockPickticket
        {
            get { return _crossDockPickticket; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _crossDockPickticket = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _choppingYn;
        [FixedLengthField(139, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ChoppingYn
        {
            get { return _choppingYn; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _choppingYn = value;
            }
        }

        private string _i2Of5LabelYn;
        [FixedLengthField(140, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string I2Of5LabelYn
        {
            get { return _i2Of5LabelYn; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _i2Of5LabelYn = value;
            }
        }

        private string _collectFreight;
        [FixedLengthField(141, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CollectFreight
        {
            get { return _collectFreight; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _collectFreight = value;
            }
        }

        private string _printGarmentLbls;
        [FixedLengthField(142, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PrintGarmentLbls
        {
            get { return _printGarmentLbls; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _printGarmentLbls = value;
            }
        }

        private string _vasStatus;
        [FixedLengthField(143, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string VasStatus
        {
            get { return _vasStatus; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _vasStatus = value;
            }
        }

        private string _chuteCategory;
        [FixedLengthField(144, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ChuteCategory
        {
            get { return _chuteCategory; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _chuteCategory = value;
            }
        }

        private string _cheapRateFlag;
        [FixedLengthField(145, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CheapRateFlag
        {
            get { return _cheapRateFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _cheapRateFlag = value;
            }
        }

        private long _maxCartonWeight;
        [FixedLengthField(146, 15, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000000000")]
        public long MaxCartonWeight_Backing
        {
            get { return _maxCartonWeight; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 15) throw new ArgumentOutOfRangeException("value");
                _maxCartonWeight = value;
            }
        }
        public decimal MaxCartonWeight
        {
            get { return MaxCartonWeight_Backing / 100000.0m; }
            set { MaxCartonWeight_Backing = (int)(value * 100000.0m); }
        }

        private long _maxCartonUnits;
        [FixedLengthField(147, 11, PaddingChar = '0', Padding = Padding.Left, NullValue="00000000000")]
        public long MaxCartonUnits_Backing
        {
            get { return _maxCartonUnits; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 11) throw new ArgumentOutOfRangeException("value");
                _maxCartonUnits = value;
            }
        }
        public decimal MaxCartonUnits
        {
            get { return MaxCartonUnits_Backing / 10000.0m; }
            set { MaxCartonUnits_Backing = (int)(value * 10000.0m); }
        }

        private string _palletSequenceFlag;
        [FixedLengthField(148, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PalletSequenceFlag
        {
            get { return _palletSequenceFlag; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _palletSequenceFlag = value;
            }
        }

        private string _assignLocation;
        [FixedLengthField(149, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AssignLocation
        {
            get { return _assignLocation; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _assignLocation = value;
            }
        }

        private string _shippingWarehouse;
        [FixedLengthField(150, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingWarehouse
        {
            get { return _shippingWarehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingWarehouse = value;
            }
        }

        private string _shipToWarehouse;
        [FixedLengthField(151, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShipToWarehouse
        {
            get { return _shipToWarehouse; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shipToWarehouse = value;
            }
        }

        private string _combinePickticketFlag;
        [FixedLengthField(152, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string CombinePickticketFlag
        {
            get { return _combinePickticketFlag; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _combinePickticketFlag = value;
            }
        }

        private string _allocateCases;
        [FixedLengthField(153, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllocateCases
        {
            get { return _allocateCases; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allocateCases = value;
            }
        }

        private string _allocateInventory;
        [FixedLengthField(154, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllocateInventory
        {
            get { return _allocateInventory; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allocateInventory = value;
            }
        }

        private string _caseAllocProcessing;
        [FixedLengthField(155, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CaseAllocProcessing
        {
            get { return _caseAllocProcessing; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _caseAllocProcessing = value;
            }
        }

        private string _shippingZone1;
        [FixedLengthField(156, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone1
        {
            get { return _shippingZone1; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone1 = value;
            }
        }

        private string _shippingZone2;
        [FixedLengthField(157, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone2
        {
            get { return _shippingZone2; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone2 = value;
            }
        }

        private string _shippingZone3;
        [FixedLengthField(158, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone3
        {
            get { return _shippingZone3; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone3 = value;
            }
        }

        private string _shippingZone4;
        [FixedLengthField(159, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone4
        {
            get { return _shippingZone4; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone4 = value;
            }
        }

        private string _shippingZone5;
        [FixedLengthField(160, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone5
        {
            get { return _shippingZone5; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone5 = value;
            }
        }

        private string _shippingZone6;
        [FixedLengthField(161, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string ShippingZone6
        {
            get { return _shippingZone6; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _shippingZone6 = value;
            }
        }

        // Used by New Balance
        // Y if residential order, N if not
        private string _residentialAddress;
        [FixedLengthField(162, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string ResidentialAddress
        {
            get { return _residentialAddress; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _residentialAddress = value;
            }
        }

        // Used by New Balance
        // Complex rules are set up on JBA to determine if a pick should be selected for Rate Shopping.  Currently two programs are set up: Friday Guarantee and XPS.  If Rate Shopping is determined this field must be filled in with the appropriate WM Service Level Program along with the Scheduled Delivery Date field (PHSDDT).  Planned Ship Via (PHSVIA) and Routing (PHCURT) must both be blanks when this is used.  The USPS carrier on JBA is a special case and is flagged as a Routing Guide but actually takes advantage of Rate Shopping logic in this pick bridge.  This will bridge down the USPS service level with a zero scheduled delivery date.
        private string _serviceLevel;
        [FixedLengthField(163, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string ServiceLevel
        {
            get { return _serviceLevel; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _serviceLevel = value;
            }
        }

        private string _liabilityTerms;
        [FixedLengthField(164, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string LiabilityTerms
        {
            get { return _liabilityTerms; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _liabilityTerms = value;
            }
        }

        private int _earliestDeliveryTime;
        [FixedLengthField(165, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int EarliestDeliveryTime
        {
            get { return _earliestDeliveryTime; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _earliestDeliveryTime = value;
            }
        }

        // Used by New Balance
        // Uses NB table IMPT in NMAP050.  Default is "S", entries exist for S_'canadian carrier' with corresponding value of "E"
        private string _importer;
        [FixedLengthField(166, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Importer
        {
            get { return _importer; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _importer = value;
            }
        }

        // Used by New Balance
        // Always "EXW"
        private string _incoterms;
        [FixedLengthField(167, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string Incoterms
        {
            get { return _incoterms; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _incoterms = value;
            }
        }

        private string _incotermsNamedPlace;
        [FixedLengthField(168, 19, PaddingChar = ' ', Padding = Padding.Right, NullValue="                   ")]
        public string IncotermsNamedPlace
        {
            get { return _incotermsNamedPlace; }
            set
            {
                if(value != default(string) && value.Length > 19) throw new ArgumentOutOfRangeException("value");
                _incotermsNamedPlace = value;
            }
        }

        private string _paymentTerms;
        [FixedLengthField(169, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PaymentTerms
        {
            get { return _paymentTerms; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _paymentTerms = value;
            }
        }

        private string _exportingShipVia;
        [FixedLengthField(170, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string ExportingShipVia
        {
            get { return _exportingShipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _exportingShipVia = value;
            }
        }

        private string _portOfLoading;
        [FixedLengthField(171, 19, PaddingChar = ' ', Padding = Padding.Right, NullValue="                   ")]
        public string PortOfLoading
        {
            get { return _portOfLoading; }
            set
            {
                if(value != default(string) && value.Length > 19) throw new ArgumentOutOfRangeException("value");
                _portOfLoading = value;
            }
        }

        private string _loadingPier;
        [FixedLengthField(172, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string LoadingPier
        {
            get { return _loadingPier; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _loadingPier = value;
            }
        }

        private string _vessel;
        [FixedLengthField(173, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string Vessel
        {
            get { return _vessel; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _vessel = value;
            }
        }

        private string _portOfDischarge;
        [FixedLengthField(174, 19, PaddingChar = ' ', Padding = Padding.Right, NullValue="                   ")]
        public string PortOfDischarge
        {
            get { return _portOfDischarge; }
            set
            {
                if(value != default(string) && value.Length > 19) throw new ArgumentOutOfRangeException("value");
                _portOfDischarge = value;
            }
        }

        private string _containerized;
        [FixedLengthField(175, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Containerized
        {
            get { return _containerized; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _containerized = value;
            }
        }

        private string _validatedLicense;
        [FixedLengthField(176, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string ValidatedLicense
        {
            get { return _validatedLicense; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _validatedLicense = value;
            }
        }

        private string _economicCommodityCode;
        [FixedLengthField(177, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string EconomicCommodityCode
        {
            get { return _economicCommodityCode; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _economicCommodityCode = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _related;
        [FixedLengthField(178, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Related
        {
            get { return _related; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _related = value;
            }
        }

        // Used by New Balance
        // Always "N"
        private string _documentsOnlyShipment;
        [FixedLengthField(179, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DocumentsOnlyShipment
        {
            get { return _documentsOnlyShipment; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _documentsOnlyShipment = value;
            }
        }

        // Used by New Balance
        // Product Line description
        private string _generalMerchandiseDescription;
        [FixedLengthField(180, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string GeneralMerchandiseDescription
        {
            get { return _generalMerchandiseDescription; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _generalMerchandiseDescription = value;
            }
        }

        private string _palletSequenceUsed;
        [FixedLengthField(181, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PalletSequenceUsed
        {
            get { return _palletSequenceUsed; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _palletSequenceUsed = value;
            }
        }

        // Used by New Balance
        // Same value as PHPRCD
        private string _specialInstructionCode1;
        [FixedLengthField(182, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        // If Dynamic Routing order "DR", else blanks
        private string _specialInstructionCode2;
        [FixedLengthField(183, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode2
        {
            get { return _specialInstructionCode2; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode2 = value;
            }
        }

        // Used by New Balance
        // Product Line code
        private string _specialInstructionCode3;
        [FixedLengthField(184, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode3
        {
            get { return _specialInstructionCode3; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode3 = value;
            }
        }

        // Used by New Balance
        // JBA Order Type - OEP40.ORTY40
        private string _specialInstructionCode4;
        [FixedLengthField(185, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(186, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(187, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(188, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(189, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(190, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
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
        [FixedLengthField(191, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string SpecialInstructionCode10
        {
            get { return _specialInstructionCode10; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _specialInstructionCode10 = value;
            }
        }

        // Used by New Balance
        // An NB mod to JBA Order Entry allows the order to specifiy a billing carrier.  Rate Shopping programs can automatically set this field as well.
        private string _customerChargeShipVia;
        [FixedLengthField(192, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string CustomerChargeShipVia
        {
            get { return _customerChargeShipVia; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _customerChargeShipVia = value;
            }
        }

        private string _customerChargeOrigin;
        [FixedLengthField(193, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string CustomerChargeOrigin
        {
            get { return _customerChargeOrigin; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _customerChargeOrigin = value;
            }
        }

        private string _customerChargeServiceLevel;
        [FixedLengthField(194, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string CustomerChargeServiceLevel
        {
            get { return _customerChargeServiceLevel; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _customerChargeServiceLevel = value;
            }
        }

        private int _customerChargeDiscountPercent;
        [FixedLengthField(195, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int CustomerChargeDiscountPercent_Backing
        {
            get { return _customerChargeDiscountPercent; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _customerChargeDiscountPercent = value;
            }
        }
        public decimal CustomerChargeDiscountPercent
        {
            get { return CustomerChargeDiscountPercent_Backing / 100.0m; }
            set { CustomerChargeDiscountPercent_Backing = (int)(value * 100.0m); }
        }

        private string _codPaymentType;
        [FixedLengthField(196, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CodPaymentType
        {
            get { return _codPaymentType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _codPaymentType = value;
            }
        }

        private string _globalLocnNumber;
        [FixedLengthField(197, 13, PaddingChar = ' ', Padding = Padding.Right, NullValue="             ")]
        public string GlobalLocnNumber
        {
            get { return _globalLocnNumber; }
            set
            {
                if(value != default(string) && value.Length > 13) throw new ArgumentOutOfRangeException("value");
                _globalLocnNumber = value;
            }
        }

        private string _anchorByField1;
        [FixedLengthField(198, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string AnchorByField1
        {
            get { return _anchorByField1; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _anchorByField1 = value;
            }
        }

        private string _anchorByField2;
        [FixedLengthField(199, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string AnchorByField2
        {
            get { return _anchorByField2; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _anchorByField2 = value;
            }
        }

        private string _anchorByField3;
        [FixedLengthField(200, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string AnchorByField3
        {
            get { return _anchorByField3; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _anchorByField3 = value;
            }
        }

        private string _onCancelRequest;
        [FixedLengthField(201, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string OnCancelRequest
        {
            get { return _onCancelRequest; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _onCancelRequest = value;
            }
        }

        private string _backOrderReference;
        [FixedLengthField(202, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string BackOrderReference
        {
            get { return _backOrderReference; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _backOrderReference = value;
            }
        }

        private string _onShortage;
        [FixedLengthField(203, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string OnShortage
        {
            get { return _onShortage; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _onShortage = value;
            }
        }

        private string _documentEmailAddress;
        [FixedLengthField(204, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string DocumentEmailAddress
        {
            get { return _documentEmailAddress; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _documentEmailAddress = value;
            }
        }

        // Used by New Balance
        // Taken from new NB databse Manhattan Customer Master Extension, else default is blanks.
        private string _miscellaneousField1;
        [FixedLengthField(205, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousField1
        {
            get { return _miscellaneousField1; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField1 = value;
            }
        }

        // Used by New Balance
        // Brand code
        private string _miscellaneousField2;
        [FixedLengthField(206, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousField2
        {
            get { return _miscellaneousField2; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField2 = value;
            }
        }

        // Used by New Balance
        // Delivery sequence
        private string _miscellaneousField3;
        [FixedLengthField(207, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousField3
        {
            get { return _miscellaneousField3; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField3 = value;
            }
        }

        private string _miscellaneousField4;
        [FixedLengthField(208, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousField4
        {
            get { return _miscellaneousField4; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField4 = value;
            }
        }

        // Used by New Balance
        // Customer department
        private string _miscellaneousField5;
        [FixedLengthField(209, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousField5
        {
            get { return _miscellaneousField5; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField5 = value;
            }
        }

        // Used by New Balance
        // Customer region
        private string _miscellaneousField6;
        [FixedLengthField(210, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousField6
        {
            get { return _miscellaneousField6; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField6 = value;
            }
        }

        // Used by New Balance
        // AR Parent Acct if exists, else blanks
        private string _miscellaneousField7;
        [FixedLengthField(211, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField7
        {
            get { return _miscellaneousField7; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField7 = value;
            }
        }

        // Used by New Balance
        // Customer Number and Delivery Sequence (with 1 space between)
        private string _miscellaneousField8;
        [FixedLengthField(212, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField8
        {
            get { return _miscellaneousField8; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField8 = value;
            }
        }

        private long _miscellaneousNum1;
        [FixedLengthField(213, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(214, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        [FixedLengthField(215, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private string _allocateOpenStockForB;
        [FixedLengthField(216, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllocateOpenStockForB
        {
            get { return _allocateOpenStockForB; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allocateOpenStockForB = value;
            }
        }

        // Used by New Balance
        // Manhattan is using this in WM for cubing. Do not Use.
        private string _recordExpansionField;
        [FixedLengthField(217, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string RecordExpansionField
        {
            get { return _recordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _recordExpansionField = value;
            }
        }

        // Used by New Balance
        // Pull from BSCUST00.BSCREX -  EDI,DIV,Prtkt Lbll, HCO,Hacct, 
        private string _customRecordExpansionField;
        [FixedLengthField(218, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string CustomRecordExpansionField
        {
            get { return _customRecordExpansionField; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _customRecordExpansionField = value;
            }
        }

        private string _departmentDescription;
        [FixedLengthField(219, 25, PaddingChar = ' ', Padding = Padding.Right, NullValue="                         ")]
        public string DepartmentDescription
        {
            get { return _departmentDescription; }
            set
            {
                if(value != default(string) && value.Length > 25) throw new ArgumentOutOfRangeException("value");
                _departmentDescription = value;
            }
        }

        // Used by New Balance
        // Always "1"
        private string _function;
        [FixedLengthField(220, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string Function
        {
            get { return _function; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _function = value;
            }
        }

        private string _customerProfile;
        [FixedLengthField(221, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string CustomerProfile
        {
            get { return _customerProfile; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _customerProfile = value;
            }
        }

        private string _purchaseOrderType;
        [FixedLengthField(222, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue="    ")]
        public string PurchaseOrderType
        {
            get { return _purchaseOrderType; }
            set
            {
                if(value != default(string) && value.Length > 4) throw new ArgumentOutOfRangeException("value");
                _purchaseOrderType = value;
            }
        }

        private string _bbbCarrierCode;
        [FixedLengthField(223, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string BbbCarrierCode
        {
            get { return _bbbCarrierCode; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _bbbCarrierCode = value;
            }
        }

        private string _internalOrderNumber;
        [FixedLengthField(224, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string InternalOrderNumber
        {
            get { return _internalOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _internalOrderNumber = value;
            }
        }

        private string _ccPrimaryNumber;
        [FixedLengthField(225, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string CcPrimaryNumber
        {
            get { return _ccPrimaryNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _ccPrimaryNumber = value;
            }
        }

        private string _ccSecondaryNumber;
        [FixedLengthField(226, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string CcSecondaryNumber
        {
            get { return _ccSecondaryNumber; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _ccSecondaryNumber = value;
            }
        }

        // Used by New Balance
        // Always "2"
        private string _cartonNumberType;
        [FixedLengthField(227, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CartonNumberType
        {
            get { return _cartonNumberType; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _cartonNumberType = value;
            }
        }

        // Used by New Balance
        // Y if VAS required, blanks if not
        private string _vasType;
        [FixedLengthField(228, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string VasType
        {
            get { return _vasType; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _vasType = value;
            }
        }

        private int _dayOfWeek;
        [FixedLengthField(229, 1, PaddingChar = '0', Padding = Padding.Left, NullValue="0")]
        public int DayOfWeek
        {
            get { return _dayOfWeek; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 1) throw new ArgumentOutOfRangeException("value");
                _dayOfWeek = value;
            }
        }

        private string _shiftNumber;
        [FixedLengthField(230, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string ShiftNumber
        {
            get { return _shiftNumber; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _shiftNumber = value;
            }
        }

        private string _musicalRunAllocation;
        [FixedLengthField(231, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string MusicalRunAllocation
        {
            get { return _musicalRunAllocation; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _musicalRunAllocation = value;
            }
        }

        private int _scheduledDeliveryEndDate;
        [FixedLengthField(232, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int ScheduledDeliveryEndDate
        {
            get { return _scheduledDeliveryEndDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _scheduledDeliveryEndDate = value;
            }
        }

        private string _hazmatFlag;
        [FixedLengthField(233, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string HazmatFlag
        {
            get { return _hazmatFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _hazmatFlag = value;
            }
        }

        private string _tpePurchaseOrderFlag;
        [FixedLengthField(234, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string TpePurchaseOrderFlag
        {
            get { return _tpePurchaseOrderFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _tpePurchaseOrderFlag = value;
            }
        }

        private string _transPlanSystem;
        [FixedLengthField(235, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string TransPlanSystem
        {
            get { return _transPlanSystem; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _transPlanSystem = value;
            }
        }

        private string _tpeTrigPoint;
        [FixedLengthField(236, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string TpeTrigPoint
        {
            get { return _tpeTrigPoint; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _tpeTrigPoint = value;
            }
        }

        // Used by New Balance
        // If DC Association exists Customer number and DC Association with one space between, else same value as PHMIS8 above
        private string _miscellaneousField9;
        [FixedLengthField(237, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField9
        {
            get { return _miscellaneousField9; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField9 = value;
            }
        }

        // Used by New Balance
        // Carrier info (ie: TD,WS,INT)
        private string _miscellaneousField10;
        [FixedLengthField(238, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField10
        {
            get { return _miscellaneousField10; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField10 = value;
            }
        }

        // Used by New Balance
        // pos 1-3 = Acct type -SLP05. CGP105
        // Pos 4-6 = Cust Class - SLP05.CGP205
        // Pos 7-9 = KA Code - SLP05.CGP405
        // Pos 10-15 = CSR - OEP20E.SRRP20
        private string _miscellaneousField11;
        [FixedLengthField(239, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField11
        {
            get { return _miscellaneousField11; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField11 = value;
            }
        }

        private string _miscellaneousField12;
        [FixedLengthField(240, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField12
        {
            get { return _miscellaneousField12; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField12 = value;
            }
        }

        private string _miscellaneousField13;
        [FixedLengthField(241, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField13
        {
            get { return _miscellaneousField13; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField13 = value;
            }
        }

        private string _miscellaneousField14;
        [FixedLengthField(242, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField14
        {
            get { return _miscellaneousField14; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField14 = value;
            }
        }

        // Used by New Balance
        // Rmv UPS PO Box 
        private string _miscellaneousField15;
        [FixedLengthField(243, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField15
        {
            get { return _miscellaneousField15; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField15 = value;
            }
        }

        // Used by New Balance
        // Authorization code
        private string _miscellaneousField16;
        [FixedLengthField(244, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousField16
        {
            get { return _miscellaneousField16; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousField16 = value;
            }
        }

        // Used by New Balance
        // Est cartons in OSG0G3
        private long _miscellaneousNum4;
        [FixedLengthField(245, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        // Used by New Balance
        // Est cartons in OSG0G3
        private long _miscellaneousNum5;
        [FixedLengthField(246, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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
        // Est cartons in OSG0G3
        private long _miscellaneousNum6;
        [FixedLengthField(247, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
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

        private string _teOrderType;
        [FixedLengthField(248, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string TeOrderType
        {
            get { return _teOrderType; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _teOrderType = value;
            }
        }

        private string _hostApptNumber;
        [FixedLengthField(249, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string HostApptNumber
        {
            get { return _hostApptNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _hostApptNumber = value;
            }
        }

        private int _numberOfDetailLines;
        [FixedLengthField(250, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int NumberOfDetailLines
        {
            get { return _numberOfDetailLines; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _numberOfDetailLines = value;
            }
        }

        private string _deliveryDateFlag;
        [FixedLengthField(251, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string DeliveryDateFlag
        {
            get { return _deliveryDateFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _deliveryDateFlag = value;
            }
        }

        private int _deliveryDate;
        [FixedLengthField(252, 9, PaddingChar = '0', Padding = Padding.Left, NullValue="000000000")]
        public int DeliveryDate
        {
            get { return _deliveryDate; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 9) throw new ArgumentOutOfRangeException("value");
                _deliveryDate = value;
            }
        }

        private string _freightForwarderOrderNumber;
        [FixedLengthField(253, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string FreightForwarderOrderNumber
        {
            get { return _freightForwarderOrderNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _freightForwarderOrderNumber = value;
            }
        }

        private string _freightForwarderAccountNumber;
        [FixedLengthField(254, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string FreightForwarderAccountNumber
        {
            get { return _freightForwarderAccountNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _freightForwarderAccountNumber = value;
            }
        }

        private string _consigneeAccountNumber;
        [FixedLengthField(255, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string ConsigneeAccountNumber
        {
            get { return _consigneeAccountNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _consigneeAccountNumber = value;
            }
        }

        private string _crtOutboundAsnFiles;
        [FixedLengthField(256, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string CrtOutboundAsnFiles
        {
            get { return _crtOutboundAsnFiles; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _crtOutboundAsnFiles = value;
            }
        }

        private string _unitNumber;
        [FixedLengthField(257, 7, PaddingChar = ' ', Padding = Padding.Right, NullValue="       ")]
        public string UnitNumber
        {
            get { return _unitNumber; }
            set
            {
                if(value != default(string) && value.Length > 7) throw new ArgumentOutOfRangeException("value");
                _unitNumber = value;
            }
        }

        private string _storeDivision;
        [FixedLengthField(258, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string StoreDivision
        {
            get { return _storeDivision; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _storeDivision = value;
            }
        }

        private string _duNsNumber;
        [FixedLengthField(259, 9, PaddingChar = ' ', Padding = Padding.Right, NullValue="         ")]
        public string DuNsNumber
        {
            get { return _duNsNumber; }
            set
            {
                if(value != default(string) && value.Length > 9) throw new ArgumentOutOfRangeException("value");
                _duNsNumber = value;
            }
        }

        private string _weightUom;
        [FixedLengthField(260, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string WeightUom
        {
            get { return _weightUom; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _weightUom = value;
            }
        }

        private string _grossNetWeightOnAsn;
        [FixedLengthField(261, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string GrossNetWeightOnAsn
        {
            get { return _grossNetWeightOnAsn; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _grossNetWeightOnAsn = value;
            }
        }

        private string _volumeUom;
        [FixedLengthField(262, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string VolumeUom
        {
            get { return _volumeUom; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _volumeUom = value;
            }
        }

        private string _outboundVendorNumber;
        [FixedLengthField(263, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string OutboundVendorNumber
        {
            get { return _outboundVendorNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _outboundVendorNumber = value;
            }
        }

        private string _accountUserCode1;
        [FixedLengthField(264, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string AccountUserCode1
        {
            get { return _accountUserCode1; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _accountUserCode1 = value;
            }
        }

        private string _accountUserCode2;
        [FixedLengthField(265, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string AccountUserCode2
        {
            get { return _accountUserCode2; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _accountUserCode2 = value;
            }
        }

        private string _accountUserCode3;
        [FixedLengthField(266, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string AccountUserCode3
        {
            get { return _accountUserCode3; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _accountUserCode3 = value;
            }
        }

        private string _ediStoreId;
        [FixedLengthField(267, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string EdiStoreId
        {
            get { return _ediStoreId; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _ediStoreId = value;
            }
        }

        private string _customerCommunications;
        [FixedLengthField(268, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string CustomerCommunications
        {
            get { return _customerCommunications; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _customerCommunications = value;
            }
        }

        private string _includePackLevelIfNotMixed;
        [FixedLengthField(269, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string IncludePackLevelIfNotMixed
        {
            get { return _includePackLevelIfNotMixed; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _includePackLevelIfNotMixed = value;
            }
        }

        private string _allowStandardPack;
        [FixedLengthField(270, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string AllowStandardPack
        {
            get { return _allowStandardPack; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _allowStandardPack = value;
            }
        }

        private string _infectiousSubstanceContactName;
        [FixedLengthField(271, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string InfectiousSubstanceContactName
        {
            get { return _infectiousSubstanceContactName; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _infectiousSubstanceContactName = value;
            }
        }

        private string _infectiousSubstancePhoneNumber;
        [FixedLengthField(272, 35, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                   ")]
        public string InfectiousSubstancePhoneNumber
        {
            get { return _infectiousSubstancePhoneNumber; }
            set
            {
                if(value != default(string) && value.Length > 35) throw new ArgumentOutOfRangeException("value");
                _infectiousSubstancePhoneNumber = value;
            }
        }

        private string _sendersInsInCaseOfNonDelivery;
        [FixedLengthField(273, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SendersInsInCaseOfNonDelivery
        {
            get { return _sendersInsInCaseOfNonDelivery; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _sendersInsInCaseOfNonDelivery = value;
            }
        }

        private string _importerAccountNumber;
        [FixedLengthField(274, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue="            ")]
        public string ImporterAccountNumber
        {
            get { return _importerAccountNumber; }
            set
            {
                if(value != default(string) && value.Length > 12) throw new ArgumentOutOfRangeException("value");
                _importerAccountNumber = value;
            }
        }

        private string _sedProofofFilingCitationCode;
        [FixedLengthField(275, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SedProofofFilingCitationCode
        {
            get { return _sedProofofFilingCitationCode; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _sedProofofFilingCitationCode = value;
            }
        }

        private string _aesInternalTransactionNumber;
        [FixedLengthField(276, 15, PaddingChar = ' ', Padding = Padding.Right, NullValue="               ")]
        public string AesInternalTransactionNumber
        {
            get { return _aesInternalTransactionNumber; }
            set
            {
                if(value != default(string) && value.Length > 15) throw new ArgumentOutOfRangeException("value");
                _aesInternalTransactionNumber = value;
            }
        }

        private string _b13aFilingOption;
        [FixedLengthField(277, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string B13aFilingOption
        {
            get { return _b13aFilingOption; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _b13aFilingOption = value;
            }
        }

        private string _b13aFilingNumber;
        [FixedLengthField(278, 21, PaddingChar = ' ', Padding = Padding.Right, NullValue="                     ")]
        public string B13aFilingNumber
        {
            get { return _b13aFilingNumber; }
            set
            {
                if(value != default(string) && value.Length > 21) throw new ArgumentOutOfRangeException("value");
                _b13aFilingNumber = value;
            }
        }

        private string _frameworkId;
        [FixedLengthField(279, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(280, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue="      ")]
        public string FrameworkFlags
        {
            get { return _frameworkFlags; }
            set
            {
                if(value != default(string) && value.Length > 6) throw new ArgumentOutOfRangeException("value");
                _frameworkFlags = value;
            }
        }

        private string _splitMultipleLoads;
        [FixedLengthField(281, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string SplitMultipleLoads
        {
            get { return _splitMultipleLoads; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _splitMultipleLoads = value;
            }
        }

        private string _palletCubingMethod;
        [FixedLengthField(282, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue="  ")]
        public string PalletCubingMethod
        {
            get { return _palletCubingMethod; }
            set
            {
                if(value != default(string) && value.Length > 2) throw new ArgumentOutOfRangeException("value");
                _palletCubingMethod = value;
            }
        }

        private int _maxSkusThatCanBeCubed;
        [FixedLengthField(283, 3, PaddingChar = '0', Padding = Padding.Left, NullValue="000")]
        public int MaxSkusThatCanBeCubed
        {
            get { return _maxSkusThatCanBeCubed; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 3) throw new ArgumentOutOfRangeException("value");
                _maxSkusThatCanBeCubed = value;
            }
        }

        private string _hostDataFlag;
        [FixedLengthField(284, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string HostDataFlag
        {
            get { return _hostDataFlag; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _hostDataFlag = value;
            }
        }

        private string _generateInvoiceData;
        [FixedLengthField(285, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string GenerateInvoiceData
        {
            get { return _generateInvoiceData; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _generateInvoiceData = value;
            }
        }

        private string _hotOrder;
        [FixedLengthField(286, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string HotOrder
        {
            get { return _hotOrder; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _hotOrder = value;
            }
        }

        private int _orderPriority;
        [FixedLengthField(287, 5, PaddingChar = '0', Padding = Padding.Left, NullValue="00000")]
        public int OrderPriority
        {
            get { return _orderPriority; }
            set
            {
                if(value != default(int) && value.ToString(CultureInfo.InvariantCulture).Length > 5) throw new ArgumentOutOfRangeException("value");
                _orderPriority = value;
            }
        }

        private string _retailerReference;
        [FixedLengthField(288, 50, PaddingChar = ' ', Padding = Padding.Right, NullValue="                                                  ")]
        public string RetailerReference
        {
            get { return _retailerReference; }
            set
            {
                if(value != default(string) && value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _retailerReference = value;
            }
        }

        private string _languageId;
        [FixedLengthField(289, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string LanguageId
        {
            get { return _languageId; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _languageId = value;
            }
        }

        private string _doublebyteLanguageId;
        [FixedLengthField(290, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue="   ")]
        public string DoublebyteLanguageId
        {
            get { return _doublebyteLanguageId; }
            set
            {
                if(value != default(string) && value.Length > 3) throw new ArgumentOutOfRangeException("value");
                _doublebyteLanguageId = value;
            }
        }

        private string _pickticketImmediateNeed;
        [FixedLengthField(291, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue=" ")]
        public string PickticketImmediateNeed
        {
            get { return _pickticketImmediateNeed; }
            set
            {
                if(value != default(string) && value.Length > 1) throw new ArgumentOutOfRangeException("value");
                _pickticketImmediateNeed = value;
            }
        }

        private string _miscellaneousIns5Byte5;
        [FixedLengthField(292, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte5
        {
            get { return _miscellaneousIns5Byte5; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte5 = value;
            }
        }

        private string _miscellaneousIns5Byte6;
        [FixedLengthField(293, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte6
        {
            get { return _miscellaneousIns5Byte6; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte6 = value;
            }
        }

        private string _miscellaneousIns5Byte7;
        [FixedLengthField(294, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte7
        {
            get { return _miscellaneousIns5Byte7; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte7 = value;
            }
        }

        private string _miscellaneousIns5Byte8;
        [FixedLengthField(295, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue="     ")]
        public string MiscellaneousIns5Byte8
        {
            get { return _miscellaneousIns5Byte8; }
            set
            {
                if(value != default(string) && value.Length > 5) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns5Byte8 = value;
            }
        }

        private string _miscellaneousIns10Byte3;
        [FixedLengthField(296, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(297, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
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
        [FixedLengthField(298, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte5
        {
            get { return _miscellaneousIns10Byte5; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte5 = value;
            }
        }

        private string _miscellaneousIns10Byte6;
        [FixedLengthField(299, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue="          ")]
        public string MiscellaneousIns10Byte6
        {
            get { return _miscellaneousIns10Byte6; }
            set
            {
                if(value != default(string) && value.Length > 10) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns10Byte6 = value;
            }
        }

        private string _miscellaneousIns20Byte11;
        [FixedLengthField(300, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(301, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(302, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
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
        [FixedLengthField(303, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue="                    ")]
        public string MiscellaneousIns20Byte14
        {
            get { return _miscellaneousIns20Byte14; }
            set
            {
                if(value != default(string) && value.Length > 20) throw new ArgumentOutOfRangeException("value");
                _miscellaneousIns20Byte14 = value;
            }
        }

        private long _miscellaneousNum7;
        [FixedLengthField(304, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum7_Backing
        {
            get { return _miscellaneousNum7; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum7 = value;
            }
        }
        public decimal MiscellaneousNum7
        {
            get { return MiscellaneousNum7_Backing / 100000.0m; }
            set { MiscellaneousNum7_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum8;
        [FixedLengthField(305, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum8_Backing
        {
            get { return _miscellaneousNum8; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum8 = value;
            }
        }
        public decimal MiscellaneousNum8
        {
            get { return MiscellaneousNum8_Backing / 100000.0m; }
            set { MiscellaneousNum8_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum9;
        [FixedLengthField(306, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum9_Backing
        {
            get { return _miscellaneousNum9; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum9 = value;
            }
        }
        public decimal MiscellaneousNum9
        {
            get { return MiscellaneousNum9_Backing / 100000.0m; }
            set { MiscellaneousNum9_Backing = (int)(value * 100000.0m); }
        }

        private long _miscellaneousNum10;
        [FixedLengthField(307, 13, PaddingChar = '0', Padding = Padding.Left, NullValue="0000000000000")]
        public long MiscellaneousNum10_Backing
        {
            get { return _miscellaneousNum10; }
            set
            {
                if(value != default(decimal) &&  value.ToString(CultureInfo.InvariantCulture).Length > 13) throw new ArgumentOutOfRangeException("value");
                _miscellaneousNum10 = value;
            }
        }
        public decimal MiscellaneousNum10
        {
            get { return MiscellaneousNum10_Backing / 100000.0m; }
            set { MiscellaneousNum10_Backing = (int)(value * 100000.0m); }
        }

public int TotalFileLength { get { return 2991; } }
    }
}
// ReSharper restore InconsistentNaming
// ReSharper restore CheckNamespace
