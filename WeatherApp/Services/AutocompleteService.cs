using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        readonly string _apiKey;
        readonly string _suggestionUrl;
        readonly string _locationUrl;
        readonly string _revGeoCodeUrl;

        public AutocompleteService(IConfiguration configuration)
        {
            _apiKey = configuration["Autocomplete:ServiceApiKey"];
            _suggestionUrl = configuration.GetValue<string>("ApiBaseUrls:Autocomplete");
            _locationUrl = configuration.GetValue<string>("ApiBaseUrls:LocationDetail");
            _revGeoCodeUrl = configuration.GetValue<string>("ApiBaseUrls:RevGeoCode");
        }

        private string GetRemoteData(string url)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    response = readTask.Result;
                }
            }
            return response;
        }

        public Location GetLocationDetails(string locationId)
        {
            string urlParameters = $"apikey={_apiKey}&locationid={locationId}";
            string url = _locationUrl + urlParameters;

            string response = GetRemoteData(url);

            JObject json = JObject.Parse(response);

            return new Location
            {
                LocationID = locationId,
                Latitude = (double)json["Response"]["View"][0]["Result"][0]["Location"]["DisplayPosition"]["Latitude"],
                Longitude = (double)json["Response"]["View"][0]["Result"][0]["Location"]["DisplayPosition"]["Longitude"],
                City = (string)json["Response"]["View"][0]["Result"][0]["Location"]["Address"]["City"],
                CountryCode = (string)json["Response"]["View"][0]["Result"][0]["Location"]["Address"]["Country"],
                State = (string)json["Response"]["View"][0]["Result"][0]["Location"]["Address"]["State"],
            };
        }

        public IEnumerable<Location> GetSuggestions(string query)
        {
            string urlParameters = $"apikey={_apiKey}&query={query}&maxresults=5&resultType=city&language=en";
            string url = _suggestionUrl + urlParameters;

            string response = GetRemoteData(url);

            JObject json = JObject.Parse(response);

            var jsonSuggestions = json.GetValue("suggestions");

            ISet<Location> locations = new HashSet<Location>();
            foreach (var suggestion in jsonSuggestions)
            {
                var location = new Location()
                {
                    LocationID = (string)suggestion["locationId"],
                    City = (string)suggestion["address"]["city"],
                    State = (string)suggestion["address"]["state"],
                    Country = (string)suggestion["address"]["country"],
                    CountryCode = (string)suggestion["countryCode"]
                };
                locations.Add(location);
            }
            return locations;
        }

        public Location GetLocationFromCoord(double lat, double lon)
        {
            string urlParameters = $"at={lat}%2C{lon}&lang=en-US&apikey={_apiKey}";
            string url = _revGeoCodeUrl + urlParameters;

            string response = GetRemoteData(url);

            JObject json = JObject.Parse(response);

            return new Location
            {
                Latitude = lat,
                Longitude = lon,
                City = (string)json["items"][0]["address"]["city"],
                State = (string)json["items"][0]["address"]["state"],
                CountryCode = (string)json["items"][0]["address"]["countryCode"],
                Country = (string)json["items"][0]["address"]["countryName"],
            };

        }
    }
}
