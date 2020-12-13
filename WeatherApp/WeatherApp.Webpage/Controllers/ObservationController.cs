using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservationController : ControllerBase
    {
        readonly IObservationRepository _observationRepository;

        public ObservationController(IObservationRepository observationRepository)
        {
            _observationRepository = observationRepository;
        }

        public object Observation { get; private set; }

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
                where observation.City.Equals(city)
                select observation;

            return observationsByCity.ToArray();
        }

        [HttpPost("{city}")]
        [Consumes("application/x-www-form-urlencoded")]
        public void Post([FromForm] IFormCollection formCollection, string city)
        {
            string userName = formCollection[nameof(userName)];
            string description = formCollection[nameof(description)];
            //string city = formCollection[nameof(city)];

            Observation obs = new Observation()
            {
                TimeStamp = DateTime.Now,
                City = city,
                UserName = userName,
                Description = description,
            };

            _observationRepository.Create(obs);
        }

        // TODO post, put, delete http requests
    }
}
