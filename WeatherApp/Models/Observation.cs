using System;

namespace WeatherApp.Models
{
    public class Observation
    {
        public long ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}
