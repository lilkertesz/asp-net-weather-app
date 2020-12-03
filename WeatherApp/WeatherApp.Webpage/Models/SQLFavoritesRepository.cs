using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public class SQLFavoritesRepository : IFavoritesRepository
    {
        private readonly DataContext _context;
        public SQLFavoritesRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(string city)
        {
            _context.FavoriteCities.Add(city);
            _context.SaveChanges();
        }

        public void Delete(string city)
        {
            _context.FavoriteCities.Remove(city);
            _context.SaveChanges();
        }

        public ICollection<string> Read()
        {
            return (ICollection<string>)_context.FavoriteCities;
        }
    }
}
