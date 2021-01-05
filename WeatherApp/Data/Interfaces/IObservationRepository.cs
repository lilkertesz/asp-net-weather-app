using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IObservationRepository
    {
        Task Create(Observation observation);
        Task<IEnumerable<Observation>> Read();
        Task Update(long observationId);
        Task Delete(long observationId);
    }
}
