using Microsoft.EntityFrameworkCore;

namespace WeatherApp.WebSite.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<CurrentWeather> CurrentWeathers { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
