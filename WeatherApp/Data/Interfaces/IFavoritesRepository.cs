using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Data.Interfaces
{
    public interface IFavoritesRepository
    {
        void Create(Location location);
        ICollection<Location> Read();
        void Delete(Location location);
    }
}
