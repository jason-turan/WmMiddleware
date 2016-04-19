namespace Middleware.Wm.Service.Inventory.Models
{
    public partial class Store : ILocation
    {
        public string StoreId { get; set; }
        public string AltId { get; set; }
        public StoreType StoreType { get; set; }

        public Store(string storeId, string altId, StoreType storeType)
        {
            StoreId = storeId;
            AltId = altId;
            StoreType = storeType;
        } 
    }
}
