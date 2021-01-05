using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherForecastService
    {
        IList<WeatherForecast> GetForecasts(string city);
    }
}
