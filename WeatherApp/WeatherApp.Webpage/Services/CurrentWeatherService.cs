using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        readonly string apiKey;

        public CurrentWeatherService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            WebHostEnvironment = webHostEnvironment;
            apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
        }

        public CurrentWeather GetCurrentWeather(string city)
        {
            string jsonString = "";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

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
                ID =          (long)json.GetValue("id"),
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
