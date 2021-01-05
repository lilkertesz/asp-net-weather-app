using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public WeatherForecastService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:WeatherForecast");
        }

        public IList<WeatherForecast> GetForecasts(string city)
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
