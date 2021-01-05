using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        CurrentWeather GetCurrentWeather(string city);
    }
}
