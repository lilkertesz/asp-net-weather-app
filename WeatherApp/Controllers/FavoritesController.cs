using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        readonly IWeatherService _currentWeatherService;
        IFavoritesRepository _favoritesRepository;

        public FavoritesController(IWeatherService currentWeatherService, IFavoritesRepository favoritesRepository)
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
        public Weather[] GetFavorites()
        {
            IList<Weather> favorites = new List<Weather>();
            foreach (var city in _favoritesRepository.Read())
            {
                //favorites.Add(_currentWeatherService.GetCurrentWeather(city));
            }
            return favorites.ToArray();
        }
    }
}
