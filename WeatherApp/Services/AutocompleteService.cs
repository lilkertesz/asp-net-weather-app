using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public AutocompleteService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:Autocomplete");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:Autocomplete");
        }

        public IEnumerable<Location> GetSuggestions(string query)
        {
            string urlParameters = $"apikey={_apiKey}&query={query}&maxresults=5&resultType=city&language=en";
            string url = _baseUrl + urlParameters;

            string jsonString = "";
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
