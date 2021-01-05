using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        Weather GetCurrentWeather(double lat, double lon);
        IList<Weather> GetHourlyForecast(double lat, double lon);
        IList<Weather> GetDailyForecast(double lat, double lon);
    }
}
