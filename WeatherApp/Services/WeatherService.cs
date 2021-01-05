using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        readonly string _apiKey;
        readonly string _weatherUrl;

        public WeatherService(IConfiguration configuration)
        {
            _apiKey = configuration["Weather:ServiceApiKey"];
            _weatherUrl = configuration.GetValue<string>("ApiBaseUrls:Weather");
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
        public Weather GetCurrentWeather(double lat, double lon)
        {
            string urlParameters = $"appid={_apiKey}&lat={lat}&lon={lon}&exclude=minutely,hourly,daily,alerts&units=metric";
            string url = _weatherUrl + urlParameters;

            string response = GetRemoteData(url);

            JObject json = JObject.Parse(response);

            Weather weather = new Weather
            {
                Timestamp = (int)json["current"]["dt"],
                Longitude = (double)json["lon"],
                Latitude = (double)json["lat"],
                Temperature = (int)json["current"]["temp"],
                FeelsLike = (int)json["current"]["feels_like"],
                ShortDescription = (string)json["current"]["weather"][0]["main"],
                Description = (string)json["current"]["weather"][0]["description"],
                WeatherIcon = (string)json["current"]["weather"][0]["icon"],
                Pressure = (int)json["current"]["pressure"],
                Humidity = (int)json["current"]["humidity"],
                WindSpeed = (double)json["current"]["wind_speed"],
                WindDirection = (int)json["current"]["wind_deg"],
                Sunrise = (int)json["current"]["sunrise"],
                Sunset = (int)json["current"]["sunset"],
                Code = (int)json["current"]["weather"][0]["id"]
            };
            return weather;
        }

        public IList<Weather> GetHourlyForecast(double lat, double lon)
        {
            string urlParameters = $"appid={_apiKey}&lat={lat}&lon={lon}&exclude=minutely,current,daily,alerts&units=metric";
            string url = _weatherUrl + urlParameters;

            string response = GetRemoteData(url);
            var forecastDetails = JObject.Parse(response).GetValue("hourly");

            IList<Weather> forecasts = new List<Weather>();
            for (int hour = 1; hour < 25; hour++)
            {
                var weather = new Weather
                {
                    Timestamp = (int)forecastDetails[hour]["dt"],
                    Longitude = lon,
                    Latitude = lat,
                    Temperature = (int)forecastDetails[hour]["temp"],
                    FeelsLike = (int)forecastDetails[hour]["feels_like"],
                    ShortDescription = (string)forecastDetails[hour]["weather"][0]["main"],
                    Description = (string)forecastDetails[hour]["weather"][0]["description"],
                    WeatherIcon = (string)forecastDetails[hour]["weather"][0]["icon"],
                    Pressure = (int)forecastDetails[hour]["pressure"],
                    Humidity = (int)forecastDetails[hour]["humidity"],
                    WindSpeed = (double)forecastDetails[hour]["wind_speed"],
                    WindDirection = (int)forecastDetails[hour]["wind_deg"],
                    Sunrise = default,
                    Sunset = default,
                    Code = (int)forecastDetails[hour]["weather"][0]["id"]
                };
                forecasts.Add(weather);
            }
            return forecasts;
        }

        public IList<Weather> GetDailyForecast(double lat, double lon)
        {
            string urlParameters = $"appid={_apiKey}&lat={lat}&lon={lon}&exclude=minutely,current,hourly,alerts&units=metric";
            string url = _weatherUrl + urlParameters;

            string response = GetRemoteData(url);
            var forecastDetails = JObject.Parse(response).GetValue("daily");

            IList<Weather> forecasts = new List<Weather>();
            for (int day = 1; day < 8; day++)
            {
                var weather = new Weather
                {
                    Timestamp = (int)forecastDetails[day]["dt"],
                    Longitude = lon,
                    Latitude = lat,
                    Temperature = (int)forecastDetails[day]["temp"]["day"],
                    FeelsLike = (int)forecastDetails[day]["feels_like"]["day"],
                    ShortDescription = (string)forecastDetails[day]["weather"][0]["main"],
                    Description = (string)forecastDetails[day]["weather"][0]["description"],
                    WeatherIcon = (string)forecastDetails[day]["weather"][0]["icon"],
                    Pressure = (int)forecastDetails[day]["pressure"],
                    Humidity = (int)forecastDetails[day]["humidity"],
                    WindSpeed = (double)forecastDetails[day]["wind_speed"],
                    WindDirection = (int)forecastDetails[day]["wind_deg"],
                    Sunrise = (int)forecastDetails[day]["sunrise"],
                    Sunset = (int)forecastDetails[day]["sunset"],
                    Code = (int)forecastDetails[day]["weather"][0]["id"]
                };
                forecasts.Add(weather);
            }
            return forecasts;
        }
    }
}
