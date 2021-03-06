﻿using Middleware.Wm.Manhattan.Extensions;

namespace Middleware.Wm.ProductReceiving.Models
{
    internal partial class DatabasePurchaseOrder
    {
        public PurchaseOrder ToPurchaseOrder()
        {
            return new PurchaseOrder
            {
                ActionCode = ActionCode,
                AmountCost = AmtCost,
                AmountFreight = AmtFreight,
                BuyerReferenceNumber = BuyerRefNbr,
                CreateReceiver = CreateReceiver,
                DateDue = DateDue,
                DiscAvailability = DiscAvail,
                ExternalUid = ExternalUID,
                FacilityNumber = FacilityNbr,
                InterfaceDate = InterfaceDate,
                InterfaceStatus = InterfaceStatus,
                PurchaseOrderDate = PODate,
                VendorAccount = VendorAcct,

            };
        }

        public LineItem ToLineItem()
        {
            return new LineItem
            {
                BuyerReference = BuyerRef,
                Class = Class,
                Extension = Extension,
                IdPurchaseOrderHeaderInterface = IDPOHeaderInterface,
                Price = Price,
                PurchaseOrderLineNumber = POLineNbr,
                QuantityOrdered = QtyOrd,
                Sku = SKU,
                Uom = UOM,
                Upc = UPC,
                VendorPartNumber = VendorPartNbr,
                Style = Style,
                Color = Color,
                SeasonYear = SeasonYear,
                Size = Size
            };
        }
    }
}
