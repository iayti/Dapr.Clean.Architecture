using System.Threading.Tasks;
using Dapr.CleanArchitecture.Domain.Common;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
