using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservationController : ControllerBase
    {
        IObservationRepository _observationRepository;
        public ObservationController(IObservationRepository observationRepository)
        {
            _observationRepository = observationRepository;
        }

        [HttpGet("observations")]
        public Observation[] GetAllObservations()
        {
            return _observationRepository.Read().ToArray();
        }

        [HttpGet("{city}")]
        public Observation[] GetObservationsByCity(string city)
        {
            var observations = _observationRepository.Read();
            var observationsByCity =
                from observation in observations
                where observation.City.ToLower().Equals(city)
                select observation;

            return observationsByCity.ToArray();
        }

        // TODO post, put, delete http requests
    }
}
