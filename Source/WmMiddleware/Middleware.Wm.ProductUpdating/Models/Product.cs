namespace Middleware.Wm.ProductUpdating.Models
{
    public class Product
    {
        public string MasterStyleSeason { get; set; }
        public string Style { get; set; }
        public string Attribute { get; set; }
        public string Size { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal StandardCost { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Vendor { get; set; }
        public string Gender { get; set; }
        public string BrandCode { get; set; }

        public bool IsFootwear
        {
            get { return Class == "FOOTWEAR"; }
        }

        public override string ToString()
        {
            return Sku;
        }
    }
}
