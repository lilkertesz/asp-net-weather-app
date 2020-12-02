using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IFavoritesRepository
    {
        void Create(string city);
        ICollection<string> Read();
        void Delete(string city);
    }
}
