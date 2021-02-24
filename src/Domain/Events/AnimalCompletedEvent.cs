using ZooApp.Domain.Common;
using ZooApp.Domain.Entities;

namespace ZooApp.Domain.Events
{
    public class AnimalCompletedEvent : DomainEvent
    {
        public AnimalCompletedEvent(AnimalEntity item)
        {
            Item = item;
        }

        public AnimalEntity Item { get; }
    }
}
