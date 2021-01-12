using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IAutocompleteService
    {
        IEnumerable<Location> GetSuggestions(string query);
        Location GetLocationDetails(string locationId);
        Location GetLocationFromCoord(double lat, double lon);
    }
}
