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

        [HttpGet("{city}")]
        public Observation[] GetObservationsByCity()
        {
            return _observationRepository.Read().ToArray();
        }
    }
}
