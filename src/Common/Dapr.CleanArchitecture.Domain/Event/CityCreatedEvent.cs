using Dapr.CleanArchitecture.Domain.Common;
using Dapr.CleanArchitecture.Domain.Entities;

namespace Dapr.CleanArchitecture.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
