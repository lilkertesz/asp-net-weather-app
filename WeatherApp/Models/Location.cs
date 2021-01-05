﻿using System;

namespace WeatherApp.Models
{
    public class Location
    {
        public string LocationID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   LocationID == location.LocationID &&
                   City == location.City &&
                   State == location.State &&
                   Country == location.Country &&
                   CountryCode == location.CountryCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocationID, City, State, Country, CountryCode);
        }
    }
}
