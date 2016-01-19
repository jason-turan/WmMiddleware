using System;
using WmMiddleware.Common.Extensions;

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
            UnitWeight = product.IsFootwear ? 0 : .01m;
            UnitVolume = product.IsFootwear ? 0 : .000001m;
            StandardCaseWeight = product.IsFootwear ? 0 : .01m;
            StandardCaseVolume = product.IsFootwear ? 0 : .01m;
            ForeignTradeZone = "N";
            MultipleCountryofOrigin = "N";
            CriticalDimension1 = product.IsFootwear ? 0 : .01m;
            CriticalDimension2 = product.IsFootwear ? 0 : .01m;
            CriticalDimension3 = product.IsFootwear ? 0 : .01m;
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
