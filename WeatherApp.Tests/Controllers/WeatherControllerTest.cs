using NSubstitute;
using NUnit.Framework;
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
        public void GetWeatherForecastForCity()
        {
            var forecast = new Weather();

            _weatherService.GetCurrentWeather(20, 10).Returns(forecast);

            var result = _weatherController.GetCurrentWeather(20, 10);

            Assert.AreEqual(result, forecast);
        }
    }
}
