﻿using System;
using System.Globalization;
using System.Linq;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Extensions;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Shipping;

namespace Middleware.Wm.Manhattan.Inventory
{
    public partial class ManhattanPickTicketHeader
    {
        public ManhattanPickTicketHeader()
        {

        }

        public ManhattanPickTicketHeader(Order order, 
                                         string batchControlNumber, 
                                         string companyNumber, 
                                         string warehouseNumber, 
                                         string shipTo, 
                                         ICountryReader countryReader, 
                                         ICarrierReadRepository carrierRepository)
        {
            // need for BNC
     

            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            UserId = order.OrderSource == null ? null : order.OrderSource.Truncate(10);
            ProgramId = UserId;
            Company = companyNumber;
            Division = warehouseNumber;
            PickticketControlNumber = order.ControlNumber.Length > 10 ? order.ControlNumber.Substring(0, 10) : order.ControlNumber;
            Warehouse = warehouseNumber;
            PickticketNumber = order.ControlNumber.Length > 10 ? order.ControlNumber.Substring(0, 10) : order.ControlNumber;
            OrderNumber = order.ControlNumber.Length > 10 ? order.ControlNumber.Substring(0, 10) : order.ControlNumber;
            MiscellaneousIns20Byte11 = order.OrderNumber; // Save order number in misc field to retrieve from ship files
            OrderType = order.OrderPriority;
            ShipTo = shipTo;
            ShipToName = order.ShippingAddress.Name;
            ShipToAddr1 = order.ShippingAddress.Line1;
            ShipToAddr2 = order.ShippingAddress.Line2;
            ShipToCity = order.ShippingAddress.City;
            ShipToState = order.ShippingAddress.State;
            ShipToZip = order.ShippingAddress.Zip;
            // PackingSlipType =
            ShipVia = carrierRepository.GetCode(order.ShippingMethod);
            ShipToCountry = countryReader.GetCountryCode(order.ShippingAddress.Country).ToString(CultureInfo.InvariantCulture);
            PackingSlipType = "P5";

            if (order.OrderType.HasValue && order.OrderType.Value == Wm.Inventory.OrderType.BrickAndClick)
            {
                CustomerPurchaseOrderNumber = order.CustomerPurchaseOrderNumber;
                ArAccountNumber = order.ArAccountNumber.Trim();
                SoldTo = ArAccountNumber;
            }
            else
            {
                SoldTo = string.Equals("NBWE", order.Company, StringComparison.InvariantCultureIgnoreCase) ? "NBUS" : order.Company;
                ArAccountNumber = SoldTo; // Requested by Manhattan team on 1/25 to be same as PHSOTO/Soldto
            }

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
        [Write(false)]
        public DateTime CreateDate
        {
            get { return MainframeExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToMainframeDate();
                TimeCreated = value.ToMainframeTime();
                ProcessedDate = DateCreated;
                ProcessedTime = TimeCreated;
                PickticketGenerationDate = value.ToMainframeDate();
                OrderDate = value.ToMainframeDate();
                CancelDate = (value + TimeSpan.FromDays(10)).ToMainframeDate();
                StopShipDate = CancelDate;
            }
        }

        public Order ToOrder(ICarrierReadRepository carrierReadRepository, ICountryReader countryReader)
        {
            int soldToCountry, shipToCountry;
            int.TryParse(SoldToCountry, out soldToCountry);
            int.TryParse(ShipToCountry, out shipToCountry);

            return new Order
            {
                BillingAddress = new Address
                {
                    City = SoldToCity,
                    Country = countryReader.GetCountryAbbreviation(soldToCountry),
                    Line1 = SoldToAddr1,
                    Line2 = SoldToAddr2,
                    Line3 = SoldToAddr3,
                    Name = SoldToName,
                    State = SoldToState,
                    Zip = SoldToZip
                },
                ShippingAddress = new Address
                {
                    City = ShipToCity,
                    Country = countryReader.GetCountryAbbreviation(shipToCountry),
                    Line1 = ShipToAddr1,
                    Line2 = ShipToAddr2,
                    Line3 = ShipToAddr3,
                    Name = ShipToName,
                    State = ShipToState,
                    Zip = ShipToZip
                },
                OrderNumber = PickticketControlNumber, //MiscellaneousIns20Byte11, ?
                OrderDate = (OrderDate != 0 ? MainframeExtensions.ParseDateTime(OrderDate, 0, DateTimeStyles.AssumeUniversal) : MainframeExtensions.ParseDateTime(DateCreated, 0, DateTimeStyles.AssumeUniversal)).ToUniversalTime(),
                BillingPhone = TelephoneNumber,
                ShippingPhone = TelephoneNumber,
                EmailAddress = "bncorder@newbalance.com",
                ShippingMethod = carrierReadRepository.GetOmsShipMethod(ShipVia)
            };
        }
    }
}
