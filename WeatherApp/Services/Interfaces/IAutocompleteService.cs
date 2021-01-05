using System.Collections.Generic;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public interface IAutocompleteService
    {
        IEnumerable<Location> GetSuggestions(string query);
    }
}
