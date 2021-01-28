using Microsoft.EntityFrameworkCore;
using System;
using WeatherApp.Models;

namespace WeatherApp
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Observation> Observations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Observation>().HasData(
            new Observation
            {
                ID = 1,
                Latitude = 47.49973,
                Longitude = 19.05508,
                TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation
            {
                ID = 2,
                Latitude = 47.49973,
                Longitude = 19.05508,
                TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation
            {
                ID = 3,
                Latitude = 40.41956,
                Longitude = -3.69196,
                TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            });
        }
    }
}
