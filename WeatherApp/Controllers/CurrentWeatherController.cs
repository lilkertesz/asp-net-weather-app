using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentWeatherController : ControllerBase
    {
        readonly ICurrentWeatherService _currentWeatherService;

        public CurrentWeatherController(ICurrentWeatherService currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        [HttpGet("{city}")]
        public async Task<CurrentWeather> Get(string city)
        {
            return await Task.Run(() => _currentWeatherService.GetCurrentWeather(city));
        }
    }
}
