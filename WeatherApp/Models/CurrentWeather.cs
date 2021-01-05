namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        public long CityId { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public string Icon { get; set; }
    }
}
