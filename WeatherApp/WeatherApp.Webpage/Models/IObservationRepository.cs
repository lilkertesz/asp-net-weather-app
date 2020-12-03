using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public interface IObservationRepository
    {
        void Create(Observation observation);
        IEnumerable<Observation> Read();
        void Update(long observationId);
        void Delete(long observationId);
    }
}
