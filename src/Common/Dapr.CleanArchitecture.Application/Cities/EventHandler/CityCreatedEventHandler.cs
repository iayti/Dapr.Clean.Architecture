using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dapr.CleanArchitecture.Application.Cities.EventHandler
{
    public class CityCreatedEventHandler : INotificationHandler<DomainEventNotification<CityCreatedEvent>>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;

        public CityCreatedEventHandler(ILogger<CityActivatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(DomainEventNotification<CityCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Dapr.CleanArchitecture Dapr.CleanArchitecture.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.City != null)
            {
                // await _emailService.SendAsync(new EmailRequest
                // {
                //     Subject = domainEvent.City.Name + " is created.",
                //     Body = "City is created successfully.",
                //     FromDisplayName = "Clean Architecture",
                //     FromMail = "test@test.com",
                //     ToMail = new List<string> { "to@test.com" }
                // });
            }
        }
    }
}
