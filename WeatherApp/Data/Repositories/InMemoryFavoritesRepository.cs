using System.Collections.Generic;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {

        private readonly ICollection<Location> _favorites = new List<Location>() 
        {
            new Location
            {
                Latitude = 47.49973,
                Longitude = 19.05508
            }
        };

        public void Create(Location location)
        {
            if (!_favorites.Contains(location))
            {
                _favorites.Add(location);
            }
        }

        public void Delete(Location location)
        {
            if (_favorites.Contains(location))
            {
                _favorites.Remove(location);
            }
        }

        public ICollection<Location> Read()
        {
            return _favorites;
        }
    }
}
