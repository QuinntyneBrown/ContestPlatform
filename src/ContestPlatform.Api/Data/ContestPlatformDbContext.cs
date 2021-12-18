using ContestPlatform.Api.Models;
using ContestPlatform.Api.Core;
using ContestPlatform.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ContestPlatform.Api.Data
{
    public class ContestPlatformDbContext: DbContext, IContestPlatformDbContext
    {
        public DbSet<Contest> Contests { get; private set; }
        public ContestPlatformDbContext(DbContextOptions options)
            :base(options) { }

    }
}
