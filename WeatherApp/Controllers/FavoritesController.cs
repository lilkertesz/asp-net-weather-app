using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private IWeatherService _currentWeatherService;
        private IFavoritesRepository _favoritesRepository;
        private IAutocompleteService _autocompleteService;

        public FavoritesController(IWeatherService currentWeatherService, IFavoritesRepository favoritesRepository, IAutocompleteService autocompleteService)
        {
            _currentWeatherService = currentWeatherService;
            _favoritesRepository = favoritesRepository;
            _autocompleteService = autocompleteService;
        }
        
        [HttpPost("{lat}/{lon}")]
        public void Post(double lat, double lon)
        {
            var location = _autocompleteService.GetLocationFromCoord(lat, lon);

            _favoritesRepository.Create(location);
        }

        [HttpDelete("{lat}/{lon}")]
        public void Delete(double lat, double lon)
        {
            var location = new Location { Latitude = lat, Longitude = lon };

            _favoritesRepository.Delete(location);
        }

        //[HttpGet("favorites")]
        //public ICollection<Location> GetLocations()
        //{
        //    return _favoritesRepository.Read();
        //}

        [HttpGet("locations")]
        public IList<string> GetLocationCoords()
        {
            var locations = _favoritesRepository.Read();
            IList<string> coords = new List<string>();

            foreach (var location in locations)
            {
                coords.Add($"{location.Latitude}%{location.Longitude}");
            }

            return coords;
        }


        [HttpGet()]
        public IList<Weather> GetWeatherForFavorites()
        {
            IList<Weather> favorites = new List<Weather>();

            var coordinates = _favoritesRepository.Read();
            
            foreach (var coordinate in coordinates)
            {
                var weather = _currentWeatherService.GetCurrentWeather(coordinate.Latitude, coordinate.Longitude);

                weather.City = _autocompleteService.GetLocationFromCoord(coordinate.Latitude, coordinate.Longitude).City;

                favorites.Add(weather);
            }

            return favorites;
        }
    }
}
