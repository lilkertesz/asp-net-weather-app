using Microsoft.EntityFrameworkCore;

namespace WeatherApp.WebSite.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<string> FavoriteCities { get; set; }

    }
}
