using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

internal sealed class BodyGuardDbContext : DbContext
{
    public BodyGuardDbContext(DbContextOptions<BodyGuardDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}