﻿using System;
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
            OrderNumber = new string(order.OrderNumber.TakeWhile(c => c != '-').ToArray());
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
            TelephoneNumber = order.BillingPhone; // Two telephone numbers in source, only 1 in target
            NumberOfPackingSlips = 1;
            PickticketStatus = "00";
            SingleItemOrder = order.Items.Sum(i => i.Quantity) == 1 ? "1" : "0";
            Sku100Inventory = "Y";
            ChoppingYn = "N";
            ResidentialAddress = "Y";
            Incoterms = "EXW";
            Related = "N";
            DocumentsOnlyShipment = "N";
            Function = "1";
            CartonNumberType = "2";
            VasType = "Y";
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
