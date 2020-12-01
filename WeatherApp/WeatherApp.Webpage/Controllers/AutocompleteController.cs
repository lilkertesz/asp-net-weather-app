using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutocompleteController : ControllerBase
    {
        readonly IAutocompleteService _autocompleteService;

        public AutocompleteController(IAutocompleteService autocompleteService)
        {
            _autocompleteService = autocompleteService;
        }

        [HttpGet("{query}")]
        public async Task<IEnumerable<Location>> Get(string query)
        {
            return await Task.Run(() => _autocompleteService.GetSuggestions(query));
        }
    }
}
