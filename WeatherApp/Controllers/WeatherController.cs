using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{lat}/{lon}")]
        public Weather GetCurrentWeather(double lat, double lon)
        {
            return _weatherService.GetCurrentWeather(lat, lon);
        }

        [HttpGet("daily/{lat}/{lon}")]
        public IList<Weather> GetDailyForecast(double lat, double lon)
        {
            return _weatherService.GetDailyForecast(lat, lon);
        }

        [HttpGet("hourly/{lat}/{lon}")]
        public IList<Weather> GetHourlyForecast(double lat, double lon)
        {
            return _weatherService.GetHourlyForecast(lat, lon);
        }
    }
}
