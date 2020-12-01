using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        readonly string apiKey;

        public WeatherForecastService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            WebHostEnvironment = webHostEnvironment;
            apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
        }

        public IList<WeatherForecast> GetForecasts(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?appid={apiKey}&units=metric&q={city}";
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

            var json = JObject.Parse(jsonString).GetValue("list");

            IList<WeatherForecast> forecasts = new List<WeatherForecast>();
            foreach (var token in json)
            {
                var weatherForecast = new WeatherForecast
                {
                    ExactDate =   (int)token["dt"],
                    Date =        (string)token["dt_txt"],
                    Description = (string)token["weather"][0]["description"],
                    Temp =        (double)token["main"]["temp"],
                    Pressure =    (int)token["main"]["pressure"],
                    Humidity =    (int)token["main"]["humidity"],
                    Wind =        (double)token["wind"]["speed"],
                    Icon =        (string)token["weather"][0]["icon"],
                };
                forecasts.Add(weatherForecast);
            }
            return forecasts;
        }
    }
}
