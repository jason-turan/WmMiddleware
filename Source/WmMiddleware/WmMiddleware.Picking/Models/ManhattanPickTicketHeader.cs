using System;
using System.Globalization;
using System.Linq;
using WmMiddleware.Common.Extensions;
using WmMiddleware.Common.Locations;

namespace WmMiddleware.Picking.Models
{
    internal partial class ManhattanPickTicketHeader
    {
        public ManhattanPickTicketHeader()
        {

        }

        public ManhattanPickTicketHeader(Order order, string batchControlNumber, string companyNumber, string warehouseNumber, ICountryReader countryReader)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            UserId = order.OrderSource;
            ProgramId = order.OrderSource;
            Company = companyNumber;
            Division = warehouseNumber;
            PickticketControlNumber = order.ControlNumber;
            Warehouse = warehouseNumber;
            PickticketNumber = order.ControlNumber;
            //PickticketSuffix = order type            
            OrderNumber = new string(order.OrderNumber.TakeWhile(c => c != '-').ToArray());
            //OrderSuffix = ??
            OrderType = order.OrderPriority;
            ShipTo = "CDS";
            ShipToName = order.ShippingAddress.Name;
            ShipToAddr1 = order.ShippingAddress.Line1;
            ShipToAddr2 = order.ShippingAddress.Line2;
            ShipToCity = order.ShippingAddress.City;
            ShipToState = order.ShippingAddress.State;
            ShipToZip = order.ShippingAddress.Zip;
            ShipToCountry = countryReader.GetCountryCode(order.ShippingAddress.Country).ToString(CultureInfo.InvariantCulture);
            SoldTo = "NBUS";
            SoldToName = order.BillingAddress.Name;
            SoldToAddr1 = order.BillingAddress.Line1;
            SoldToAddr2 = order.BillingAddress.Line2;
            SoldToCity = order.BillingAddress.City;
            SoldToState = order.BillingAddress.State;
            SoldToZip = order.BillingAddress.Zip;
            SoldToCountry = countryReader.GetCountryCode(order.BillingAddress.Country).ToString(CultureInfo.InvariantCulture);
            //ArAcctNumber
            //StoreNumber = ??
            //MerchandiseCompany = ??
            //MerchDiv = ??
            //VendorNumber = ??
            //ShipVia = ??
            //TerritoryCode = ??
            //ScheduleDeliveryDate = ??
            //PrintCode = ??
            //CartonLabelType = ??
            //NumberOfCartonLabels = ??
            //ContentLabelType = ??
            NumberOfPackingSlips = 1;
            //PackingSlipType = ??
            PickticketStatus = "00";
            //CustomerRouting = ??
            SingleSkuOrder = order.Items.Select(i => i.ItemSku).Distinct().Count() == 1 ? "1" : "0";
            //TpeCurrCode = ??
            Sku100Inventory = "Y";
            ChoppingYn = "N";
            ResidentialAddress = "Y";
            //ServiceLevel = shipmethod
            //Importer = ??
            Incoterms = "EXW";
            Related = "N";
            DocumentsOnlyShipment = "N";
            //GenMerchDescription = ??
            //SpeclInstructionCode1 = ??
            //SpeclInstructionCode2 = ??
            //SpeclInstructionCode3 = ??
            //SpeclInstructionCode4 = ??
            //CustChargeShipVia = ??
            //MiscellaneousField1
            //MiscellaneousField2
            //MiscellaneousField3
            //MiscellaneousField5
            //MiscellaneousField6
            //MiscellaneousField7
            //MiscellaneousField8
            //CustomRecordExpansionField = ??
            Function = "1";
            CartonNumberType = "2";
            VasType = "Y";
            //MiscellaneousField9 = ??
            //MiscellaneousField10 = ??
            //MiscellaneousField11 = ??
            //MiscellaneousField15 = ??
            //MiscellaneousField16 = ??
            //MiscellaneousNum4 = ??
            //MiscellaneousNum5 = ??
            //MiscellaneousNum6 = ??

        }

        public DateTime CreateDate
        {
            get { return ManhattanExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToManhattanDate();
                TimeCreated = value.ToManhattanTime();
                ProcessedDate = DateCreated;
                ProcessedTime = TimeCreated;
                PickticketGenerationDate = value.ToManhattanDate();
                OrderDate = value.ToManhattanDate();
                CancelDate = (value + TimeSpan.FromDays(10)).ToManhattanDate();
                StopShipDate = CancelDate;
            }
        }
    }
}
