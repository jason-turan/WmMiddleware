using System;
using Middleware.Wm.Extensions;

namespace WmMiddleware.ProductUpdating.Models
{
    internal partial class ManhattanProduct
    {
        public ManhattanProduct()
        {

        }

        public ManhattanProduct(Product product, string batchControlNumber, string companyNumber, string divisionNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            Company = companyNumber;
            Division = divisionNumber;
            SeasonYear = product.MasterStyleSeason;
            Style = product.Style.Truncate(8);
            Color = product.Attribute;
            SecDimension = product.Size.ToManhattanSize().Truncate(3);
            ProductSubgroup = product.BrandCode;
            ProductType = SeasonYear;
            StyleDescription = product.Description;
            PackageBarcode = product.Sku;
            Price = product.StandardCost;
            BoxQuantity = 1;
            LenWidthSensitive = "N";
            UnitWeight = 0;
            UnitVolume = 0;
            StandardCaseWeight = 0;
            StandardCaseVolume = 0;
            ForeignTradeZone = "N";
            MultipleCountryofOrigin = "N";
            CriticalDimension1 = 0;
            CriticalDimension2 = 0;
            CriticalDimension3 = 0;
            TrackBatchNumber = "Y";
            TrackCountryofOrigin = "N";
            Function = "2";
            Producer = "N";
            NetCostValidation = "N";
            FtsrExceptionNumber = "N";
            CommodityCode = product.Gender + product.Category;
            LotControlUsed = "N";
            VendorTaggedEpc = "0";
            ProductType = "F";
            PickDeterminationType = "POP";
            SkuProfileId = product.Category.ToUpperInvariant();
            SlotMisc1 = SkuProfileId;
        }

        public DateTime CreateDate
        {
            get { return ManhattanExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToManhattanDate();
                TimeCreated = value.ToManhattanTime();
            }
        }
    }
}
