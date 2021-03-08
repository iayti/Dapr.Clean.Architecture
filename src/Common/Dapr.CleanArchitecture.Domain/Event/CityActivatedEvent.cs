using Dapr.CleanArchitecture.Domain.Common;
using Dapr.CleanArchitecture.Domain.Entities;

namespace Dapr.CleanArchitecture.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
