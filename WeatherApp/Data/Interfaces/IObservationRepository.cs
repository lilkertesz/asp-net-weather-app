using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Data.Interfaces
{
    public interface IObservationRepository
    {
        Task Create(Observation observation);
        Task<IEnumerable<Observation>> Read();
        Task Update(long observationId);
        Task Delete(long observationId);
    }
}
