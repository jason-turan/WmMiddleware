namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Location : ILocation
    {
        public string LocationName { get; set; }
        public Address Address { get; set; }

        public Location(
            string locationName, 
            Address address)
        {
            LocationName = locationName;
            Address = address; 
        } 

    }
}
