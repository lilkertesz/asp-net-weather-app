using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        readonly ICurrentWeatherService _currentWeatherService;
        IFavoritesRepository _favoritesRepository;

        public FavoritesController(ICurrentWeatherService currentWeatherService, IFavoritesRepository favoritesRepository)
        {
            _currentWeatherService = currentWeatherService;
            _favoritesRepository = favoritesRepository;
        }
        
        [HttpPost("{city}")]
        public void Post(string city)
        {
            _favoritesRepository.Create(city);
        }

        [HttpDelete("{city}")]
        public void Delete(string city)
        {
            _favoritesRepository.Delete(city);
        }

        [HttpGet("cities")]
        public CurrentWeather[] GetFavorites()
        {
            IList<CurrentWeather> favorites = new List<CurrentWeather>();
            foreach (var city in _favoritesRepository.Read())
            {
                favorites.Add(_currentWeatherService.GetCurrentWeather(city));
            }
            return favorites.ToArray();
        }
    }
}
