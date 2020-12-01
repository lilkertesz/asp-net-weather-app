using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        readonly ICurrentWeatherService _currentWeatherService;
        FavoriteContext _context;

        public FavoriteController(ICurrentWeatherService currentWeatherService, FavoriteContext favoriteContext)
        {
            _currentWeatherService = currentWeatherService;
            _context = favoriteContext;
        }
        
        [HttpPost("{city}")]
        public CurrentWeather Post(string city)
        {
            _context.FavoriteSet.Add(city);
            return _currentWeatherService.GetCurrentWeather(city);
        }
        
        [HttpGet("favorites")]
        public CurrentWeather[] GetFavorites()
        {
            ISet<CurrentWeather> favorites = new HashSet<CurrentWeather>();
            foreach (var city in _context.FavoriteSet)
            {
                favorites.Add(_currentWeatherService.GetCurrentWeather(city));
            }
            return favorites.ToArray();
        }
    }
}
