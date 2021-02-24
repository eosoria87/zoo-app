using ZooApp.Application.Common.Models;
using ZooApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.EventHandlers
{
    public class AnimalCreatedEventHandler : INotificationHandler<DomainEventNotification<AnimalCreatedEvent>>
    {
        private readonly ILogger<AnimalCompletedEventHandler> _logger;

        public AnimalCreatedEventHandler(ILogger<AnimalCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<AnimalCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
