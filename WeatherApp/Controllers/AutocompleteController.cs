using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
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
        public IEnumerable<Location> Get(string query)
        {
            return _autocompleteService.GetSuggestions(query);
        }
    }
}
