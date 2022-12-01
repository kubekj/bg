using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class Extensions
{
    private const string DatabaseName = "postgres";
    
    internal static void AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresConfig>(configuration.GetRequiredSection(DatabaseName));
        var postgresConfig = configuration.GetOptions<PostgresConfig>(DatabaseName);
        services.AddDbContext<BodyGuardDbContext>(x => x.UseNpgsql(postgresConfig.ConnectionString));
        services.AddHostedService<DbInitializer>();
        
        // EF Core + Npgsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}