using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        CurrentWeather GetCurrentWeather(string city);
    }
}
