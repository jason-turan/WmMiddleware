using System;

namespace Middleware.Wm.Service.Inventory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Location : IEquatable<Location>
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

        public override int GetHashCode()
        {
            return 37 * LocationName.GetHashCode() ^ Address.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Location)obj);
        }

        public bool Equals(Location other)
        {
            if(other == null)
            {
                return false;
            }

            return LocationName == other.LocationName && Address == other.Address;
        }
    }
}
