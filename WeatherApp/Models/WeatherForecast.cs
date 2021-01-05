namespace WeatherApp.WebSite.Models
{
    public class WeatherForecast
    {
        public long ExactDate { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public string Icon { get; set; }
    }
}
