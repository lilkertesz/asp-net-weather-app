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
        public ICollection<Location> Post(double lat, double lon)
        {
            var location = _autocompleteService.GetLocationFromCoord(lat, lon);

            _favoritesRepository.Create(location);
            return _favoritesRepository.Read();
        }

        [HttpDelete("{locationID}")]
        public void Delete(string locationID)
        {
            var location = _autocompleteService.GetLocationDetails(locationID);

            _favoritesRepository.Delete(location);
        }

        [HttpGet()]
        public ICollection<Location> GetLocations()
        {
            return _favoritesRepository.Read();
        }
    }
}
