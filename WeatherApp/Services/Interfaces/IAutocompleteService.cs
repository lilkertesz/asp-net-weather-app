using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IAutocompleteService
    {
        IEnumerable<Location> GetSuggestions(string query);
        Location GetCoordinates(string locationId);
    }
}
