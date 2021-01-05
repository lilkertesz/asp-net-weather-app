using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite
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

            _currentWeatherService.GetCurrentWeather(city).Returns(new CurrentWeather { City = city });

            string expected = city;
            CurrentWeather currentWeather = await _currentWeatherController.Get(city);
            string actual = currentWeather.City;

            Assert.AreEqual(expected, actual);
        }
    }
}
