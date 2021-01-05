using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class SQLObservationsRepository : IObservationRepository
    {
        private readonly ObservationsContext _context;

        public SQLObservationsRepository(ObservationsContext context)
        {
            _context = context;
        }
        public async Task Create(Observation observation)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long observationId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Observation>> Read()
        {
            return _context.Observations;
        }

        public async Task Update(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
