using System;

namespace WeatherApp.Models
{
    public class Location
    {
        public string LocationID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
    }
}
