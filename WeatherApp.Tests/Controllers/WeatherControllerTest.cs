using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Tests.Controllers
{
    [TestFixture]
    class WeatherControllerTest
    {
        private IWeatherService _weatherService;
        private WeatherController _weatherController;


        [SetUp]
        public void Setup()
        {
            _weatherService = Substitute.For<IWeatherService>();
            _weatherController = new WeatherController(_weatherService);
        }

        [Test]
        public void GetCurrentWeatherForCoordinates()
        {
            var weather = new Weather();
            _weatherService.GetCurrentWeather(20, 10).Returns(weather);
            var result = _weatherController.GetCurrentWeather(20, 10);
            Assert.AreEqual(result, weather);
        }

        [Test]
        public void GetDailyForecastForCoordinates()
        {
            IList<Weather> forecast = new List<Weather>();

            _weatherService.GetDailyForecast(20, 10).Returns(forecast);

            var result = _weatherController.GetDailyForecast(20, 10);

            Assert.AreEqual(result, forecast);
        }

        [Test]
        public void GetHourlyForecastForCoordinates()
        {
            IList<Weather> forecast = new List<Weather>();

            _weatherService.GetHourlyForecast(20, 10).Returns(forecast);

            var result = _weatherController.GetHourlyForecast(20, 10);

            Assert.AreEqual(result, forecast);
        }
    }
}
