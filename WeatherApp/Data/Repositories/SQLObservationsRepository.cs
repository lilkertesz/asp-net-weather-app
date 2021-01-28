using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Data.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Data.Repositories
{
    public class SQLObservationsRepository : IObservationRepository
    {
        private readonly WeatherDbContext _context;

        public SQLObservationsRepository(WeatherDbContext context)
        {
            _context = context;
        }
        public async Task Create(Observation observation)
        {
            _context.Add(observation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Observation>> Read()
        {
            return await Task.FromResult(_context.Observations);
        }

        public async Task Delete(long observationId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
