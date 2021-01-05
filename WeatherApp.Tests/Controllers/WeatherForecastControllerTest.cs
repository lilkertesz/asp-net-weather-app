﻿using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Tests.Controllers
{
    [TestFixture]
    class WeatherForecastControllerTest
    {
        private IWeatherService _weatherForecastService;
        private WeatherController _weatherForecastController;


        [SetUp]
        public void Setup()
        {
            _weatherForecastService = Substitute.For<IWeatherService>();
            _weatherForecastController = new WeatherForecastController(_weatherForecastService);
        }

        [Test]
        public async Task GetWeatherForecastForCity()
        {
            string city = "Budapest";

            var forecast = new List<WeatherForecast>();

            var weatherForecast = new WeatherForecast
            {
                ExactDate = default(long),
                Date = default(string),
                Description = default(string),
                Temp = default(double),
                Pressure = default(int),
                Humidity = default(int),
                Wind = default(double),
                Icon = default(string),
            };

            forecast.Add(weatherForecast);

            _weatherForecastService.GetForecasts(city).Returns(forecast);

            var result = await _weatherForecastController.Get(city);

            Assert.AreEqual(result, forecast);
        }
    }
}
