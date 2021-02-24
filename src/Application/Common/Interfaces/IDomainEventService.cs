using ZooApp.Domain.Common;
using System.Threading.Tasks;

namespace ZooApp.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
