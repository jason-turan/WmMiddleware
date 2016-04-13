// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Middleware.Wm.ProductUpdating.Models
{
    internal partial class DatabaseProduct
    {
        public string MasterStyleSeason { get; set; } //(varchar(2), null)
        public string Style { get; set; } //(varchar(15), null)
        public string Attr { get; set; } //(varchar(11), null)
        public string Size { get; set; } //(varchar(11), null)
        public string Class { get; set; } //(varchar(11), null)
        public string Description { get; set; } //(varchar(101), null)
        public string SKU { get; set; } //(varchar(31), not null)
        public decimal Standard_Cost { get; set; } //(decimal(19,5), null)
        public string Category { get; set; } //(varchar(11), null)
        public string SubCategory { get; set; } //(varchar(11), null)
        public string Vendor { get; set; } //(varchar(15), null)
        public string Gender { get; set; } //(varchar(11), null)
        public string BrandCode { get; set; } //(nchar(3), null)
    }
}
// ReSharper restore InconsistentNaming
