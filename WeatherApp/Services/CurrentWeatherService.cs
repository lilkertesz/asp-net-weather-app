﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public CurrentWeatherService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:CurrentWeather");
        }

        public CurrentWeather GetCurrentWeather(string city)
        {
            string urlParameters = $"appid={_apiKey}&q={city}&units=metric";
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

            var currentWeather = new CurrentWeather()
            {
                CityId =      (long)json.GetValue("id"),
                City =        (string)json.GetValue("name"),
                Description = (string)json["weather"][0]["description"],
                Icon =        (string)json["weather"][0]["icon"],
                Humidity =    (int)json.GetValue("main")["humidity"],
                Temp =        (int)json.GetValue("main")["temp"],
                Pressure =    (int)json.GetValue("main")["pressure"],
                Wind =        (double)json.GetValue("wind")["speed"]
            };
            return currentWeather;
        }
    }
}
