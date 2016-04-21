using System;

namespace Middleware.Wm.Service.Inventory.Models
{
    public class Address : IEquatable<Address>
    {
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }


        public override int GetHashCode()
        {
            var hashCode = Name.GetHashCode();
            hashCode = hashCode * 37 ^ Line1.GetHashCode();
            hashCode = hashCode * 37 ^ Line2.GetHashCode();
            hashCode = hashCode * 37 ^ City.GetHashCode();
            hashCode = hashCode * 37 ^ State.GetHashCode();
            hashCode = hashCode * 37 ^ ZipCode.GetHashCode();
            hashCode = hashCode * 37 ^ Country.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Address)obj);
        }

        public bool Equals(Address other)
        {
            if (other == null)
            {
                return false;
            }

            return Name == other.Name
                && Line1 == other.Line1
                && Line2 == other.Line2
                && City == other.City
                && State == other.State
                && ZipCode == other.ZipCode
                && Country == other.Country;
        }
    }
}