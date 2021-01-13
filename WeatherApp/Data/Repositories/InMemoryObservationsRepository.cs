using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class InMemoryObservationsRepository : IObservationRepository
    {
        readonly IList<Observation> _observations = new List<Observation>() {
            new Observation
            {
                ID = 1,
                Latitude = 47.49973,
                Longitude = 19.05508,
                TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation
            {
                ID = 2,
                Latitude = 47.49973,
                Longitude = 19.05508,
                TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation
            {
                ID = 3,
                Latitude = 40.41956,
                Longitude = -3.69196,
                TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            }
        };

        public async Task Create(Observation observation)
        {
            long newID = _observations.Select(observation => observation.ID).Max() + 1;
            observation.ID = newID;

            await Task.Run(() => _observations.Add(observation));
        }

        public async Task<IEnumerable<Observation>> Read()
        {
            return await Task.FromResult(_observations);
        }

        // TODO
        public async Task Delete(long observationId)
        {
            throw new NotImplementedException();
        }

        // TODO
        public async Task Update(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
