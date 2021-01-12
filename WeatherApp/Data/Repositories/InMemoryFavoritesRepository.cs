using System.Collections.Generic;
using System.Linq;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {

        private readonly ICollection<Location> _favorites = new HashSet<Location>();

        public void Create(Location location)
        {
            _favorites.Add(location);
        }

        public void Delete(Location location)
        {
            var item = _favorites.FirstOrDefault(
                x => x.Latitude == location.Latitude && 
                x.Longitude == location.Longitude);

            if (item != null) _favorites.Remove(item);
        }

        public ICollection<Location> Read()
        {
            return _favorites;
        }
    }
}
