using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
