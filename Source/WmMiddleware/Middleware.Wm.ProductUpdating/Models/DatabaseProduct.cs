namespace Middleware.Wm.ProductUpdating.Models
{
    internal partial class DatabaseProduct
    {
        public Product ToProduct()
        {
            return new Product
            {
                Attribute = Attr,
                Style = Style,
                Size = Size,
                Class = Class,
                Sku = SKU,
                Category = Category,
                Description = Description,
                MasterStyleSeason = MasterStyleSeason,
                StandardCost = Standard_Cost,
                SubCategory = SubCategory,
                Vendor = Vendor,
                Gender = Gender
            };
        }
    }
}
