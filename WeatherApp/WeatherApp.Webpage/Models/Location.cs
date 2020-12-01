using System;

namespace WeatherApp.WebSite.Models
{
    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   City == location.City &&
                   State == location.State &&
                   Country == location.Country &&
                   CountryCode == location.CountryCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, State, Country, CountryCode);
        }
    }
}
