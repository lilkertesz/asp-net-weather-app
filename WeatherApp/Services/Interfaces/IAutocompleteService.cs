using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IAutocompleteService
    {
        IEnumerable<Location> GetSuggestions(string query);
        Coordinate GetCoordinate(string locationId);
    }
}
