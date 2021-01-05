namespace WeatherApp.Models
{
    public class Weather
    {
        public int Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Temperature { get; set; }
        public int FeelsLike { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string WeatherIcon { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int Code { get; set; }
    }
}
