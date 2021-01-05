using System;

namespace WeatherApp.WebSite.Models
{
    public class Location
    {
        public long ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   ID == location.ID &&
                   City == location.City &&
                   State == location.State &&
                   Country == location.Country &&
                   CountryCode == location.CountryCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, City, State, Country, CountryCode);
        }
    }
}
