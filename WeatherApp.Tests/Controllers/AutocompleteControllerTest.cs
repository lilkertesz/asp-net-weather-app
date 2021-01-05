using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Tests.Controllers
{
    [TestFixture]
    public class AutocompleteTests
    {
        private AutocompleteController _autocompleteController;
        private IAutocompleteService _autocompleteService;

        [SetUp]
        public void Setup()
        {
            _autocompleteService = Substitute.For<IAutocompleteService>();
            _autocompleteController = new AutocompleteController(_autocompleteService);
        }

        [Test]
        public void GetSuggestionsTest()
        {
            string input = "bud";

            ISet<Location> suggestionList = new HashSet<Location>();

            var location = new Location()
            {
                LocationID = default,
                City = "Budapest",
                State = default,
                Country = "Hungary",
                CountryCode = "HU"
            };

            suggestionList.Add(location);

            _autocompleteService.GetSuggestions(input).Returns(suggestionList);

            var result = _autocompleteController.Get(input);

            Assert.AreEqual(result, suggestionList);
        }
    }
}