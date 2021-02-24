using ZooApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AnimalEntity> Animals { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
