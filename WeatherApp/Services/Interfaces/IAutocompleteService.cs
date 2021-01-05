using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IAutocompleteService
    {
        IEnumerable<Location> GetSuggestions(string query);
    }
}
