﻿using System.Collections.Generic;
using WeatherApp.Data.Interfaces;

namespace WeatherApp.Data.Repositories
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {
        IList<string> _favorites = new List<string>() { "Vienna", "Vancouver" };

        public void Create(string city)
        {
            if (!_favorites.Contains(city))
            {
                _favorites.Add(city);
            }
        }

        public void Delete(string city)
        {
            if (_favorites.Contains(city))
            {
                _favorites.Remove(city);
            }
        }

        ICollection<string> IFavoritesRepository.Read()
        {
            return _favorites;
        }
    }
}
