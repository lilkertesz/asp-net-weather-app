using System;
using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public class SQLObservationsRepository : IObservationRepository
    {
        private readonly ObservationsContext _context;

        public SQLObservationsRepository(ObservationsContext context)
        {
            _context = context;
        }
        public void Create(Observation observation)
        {
            throw new NotImplementedException();
        }

        public void Delete(long observationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Observation> Read()
        {
            return _context.Observations;
        }

        public void Update(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
