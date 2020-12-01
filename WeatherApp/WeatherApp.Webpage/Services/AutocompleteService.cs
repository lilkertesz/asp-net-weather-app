using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        readonly string apiKey;

        public AutocompleteService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            WebHostEnvironment = webHostEnvironment;
            apiKey = configuration.GetValue<string>("ApiKeys:Autocomplete");
        }

        public IEnumerable<Location> GetSuggestions(string query)
        {
            string jsonString = "";
            string url = $"https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?query={query}&maxresults=5&resultType=city&language=en&apikey={apiKey}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    jsonString = readTask.Result;
                }
            }

            var json = JObject.Parse(jsonString);
            var jsonSuggestions = json.GetValue("suggestions");

            ISet<Location> locations = new HashSet<Location>();
            foreach (var suggestion in jsonSuggestions)
            {
                var location = new Location()
                {
                    City =        (string)suggestion["address"]["city"],
                    State =       (string)suggestion["address"]["state"],
                    Country =     (string)suggestion["address"]["country"],
                    CountryCode = (string)suggestion["countryCode"]
                };
                locations.Add(location);
            }
            return locations;
        }
    }
}
