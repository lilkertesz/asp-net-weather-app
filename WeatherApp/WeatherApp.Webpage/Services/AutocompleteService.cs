using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        const string API_KEY = "jzxwrjVpz590MChJ0KjlrLnwg_syikNAPYB0tvSemLE";

        public AutocompleteService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<Location> GetSuggestions(string query)
        {
            string jsonString = "";
            string url = $"https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?query={query}&maxresults=5&resultType=city&language=en&apikey={API_KEY}";

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
            ISet<Location> suggestionList = new HashSet<Location>();
            var jsonSuggestion = json.GetValue("suggestions");

            foreach (var element in jsonSuggestion)
            {
                var locationSuggestion = new Location()
                {
                    City = (string)element["address"]["city"],
                    State = (string)element["address"]["state"],
                    Country = (string)element["address"]["country"],
                    CountryCode = (string)element["countryCode"]
                };
                suggestionList.Add(locationSuggestion);
            }
            return suggestionList;
        }
    }
}
