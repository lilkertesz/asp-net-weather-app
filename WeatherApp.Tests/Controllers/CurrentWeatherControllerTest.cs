using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Tests.Controllers
{
    [TestFixture]
    public class CurrentWeatherControllerTest
    {
        private CurrentWeatherController _currentWeatherController;
        private ICurrentWeatherService _currentWeatherService;

        [SetUp]
        public void Setup()
        {
            _currentWeatherService = Substitute.For<ICurrentWeatherService>();
            _currentWeatherController = new CurrentWeatherController(_currentWeatherService);
        }

        [Test]
        public async Task Get_ExistingCity_ReturnCity()
        {
            string city = "Budapest";

            _currentWeatherService.GetCurrentWeather(city).Returns(new Weather { City = city });

            string expected = city;
            Weather currentWeather = await _currentWeatherController.Get(city);
            string actual = currentWeather.City;

            Assert.AreEqual(expected, actual);
        }
    }
}
