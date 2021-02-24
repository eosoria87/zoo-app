using ZooApp.Application.Common.Models;
using ZooApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.EventHandlers
{
    public class AnimalCompletedEventHandler : INotificationHandler<DomainEventNotification<AnimalCompletedEvent>>
    {
        private readonly ILogger<AnimalCompletedEventHandler> _logger;

        public AnimalCompletedEventHandler(ILogger<AnimalCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<AnimalCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
