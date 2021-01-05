using System.Collections.Generic;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public interface IWeatherForecastService
    {
        IList<WeatherForecast> GetForecasts(string city);
    }
}
