using ZooApp.Domain.Common;
using ZooApp.Domain.Entities;

namespace ZooApp.Domain.Events
{
    public class AnimalCreatedEvent : DomainEvent
    {
        public AnimalCreatedEvent(AnimalEntity item)
        {
            Item = item;
        }

        public AnimalEntity Item { get; }
    }
}
