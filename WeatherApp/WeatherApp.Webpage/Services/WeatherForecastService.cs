using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        const string API_KEY = "3c850b0463346d2fffad82b66d5eb561";

        public WeatherForecastService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IList<WeatherForecast> GetForecasts(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?appid={API_KEY}&units=metric&q={city}";
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
            List<WeatherForecast> forecasts = new List<WeatherForecast>();

            foreach (var token in json)
            {
                var weatherForecast = new WeatherForecast
                {
                    ExactDate = Convert.ToInt64(token["dt"]),
                    Date = Convert.ToString(token["dt_txt"]),
                    Description = Convert.ToString(token["weather"][0]["description"]),
                    Temp = Convert.ToDouble(token["main"]["temp"]),
                    Pressure = Convert.ToInt32(token["main"]["pressure"]),
                    Humidity = Convert.ToInt32(token["main"]["humidity"]),
                    Wind = Convert.ToDouble(token["wind"]["speed"]),
                    Icon = Convert.ToString(token["weather"][0]["icon"]),
                };

                forecasts.Add(weatherForecast);
            }

            return forecasts;
        }
    }
}
