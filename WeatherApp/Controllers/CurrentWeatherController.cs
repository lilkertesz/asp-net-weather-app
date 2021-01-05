using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
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
