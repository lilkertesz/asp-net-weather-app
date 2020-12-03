using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.WebSite
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
        public async Task GetSuggestionsTest()
        {
            string input = "bud";

            ISet<Location> suggestionList = new HashSet<Location>();

            var location = new Location()
            {
                ID = default,
                City = "Budapest",
                State = default,
                Country = "Hungary",
                CountryCode = "HU"
            };

            suggestionList.Add(location);

            _autocompleteService.GetSuggestions(input).Returns(suggestionList);

            var result = await _autocompleteController.Get(input);

            Assert.AreEqual(result, suggestionList);
        }
    }
}