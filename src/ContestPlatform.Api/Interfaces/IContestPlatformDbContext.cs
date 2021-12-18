using ContestPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace ContestPlatform.Api.Interfaces
{
    public interface IContestPlatformDbContext
    {
        DbSet<Contest> Contests { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
