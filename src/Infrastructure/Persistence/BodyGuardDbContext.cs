using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal sealed class BodyGuardDbContext : DbContext
{
    public BodyGuardDbContext(DbContextOptions<BodyGuardDbContext> dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}