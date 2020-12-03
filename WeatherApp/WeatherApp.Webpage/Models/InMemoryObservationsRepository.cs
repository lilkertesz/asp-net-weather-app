using System;
using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public class InMemoryObservationsRepository : IObservationRepository
    {
        IList<Observation> _observations = new List<Observation>() {
            new Observation{
                ID = 1,
                City = "Budapest",
                TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation{
                ID = 2,
                City = "Budapest",
                TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation{
                ID = 3,
                City = "Madrid",
                TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            }
        };

        public void Create(Observation observation)
        {
            _observations.Add(observation);
        }

        public IEnumerable<Observation> Read()
        {
            return _observations;
        }

        // TODO
        public void Delete(long observationId)
        {
            throw new NotImplementedException();
        }

        // TODO
        public void Update(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
