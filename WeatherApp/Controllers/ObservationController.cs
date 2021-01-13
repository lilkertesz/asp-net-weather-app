using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Controllers
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

        [HttpGet("observations")]
        public async Task<IEnumerable<Observation>> GetAllObservations()
        {
            var observations = await _observationRepository.Read();
            return observations;
        }

        [HttpGet("{lat}/{lon}")]
        public async Task<IEnumerable<Observation>> GetObservationsByCoords(double lat, double lon)
        {
            var observations = await _observationRepository.Read();
            var observationsByCoords =
                from observation in observations
                where observation.Latitude == lat && observation.Longitude == lon
                select observation;

            return observationsByCoords.ToArray();
        }

        [HttpPost()]
        public Observation Post([FromForm] Observation obs)
        {
            obs.TimeStamp = DateTime.Now;
            _observationRepository.Create(obs);
            return obs;
        }

    }
}
