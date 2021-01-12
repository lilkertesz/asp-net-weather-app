using System.Collections.Generic;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {

        private readonly ICollection<Location> _favorites = new List<Location>();

        public void Create(Location location)
        {
            _favorites.Add(location);
        }

        public void Delete(Location location)
        {
            _favorites.Remove(location);
        }

        public ICollection<Location> Read()
        {
            return _favorites;
        }
    }
}
