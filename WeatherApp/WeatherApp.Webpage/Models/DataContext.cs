using Microsoft.EntityFrameworkCore;

namespace WeatherApp.WebSite.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //public DbSet<Location> FavoriteCities { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Location>().HasData()
        //}
    }
}
