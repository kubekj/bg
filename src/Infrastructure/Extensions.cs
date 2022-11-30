using Infrastructure.Persistence;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Extensions
{
    private const string DatabaseName = "postgres";

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
    }

    private static void AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresConfig>(configuration.GetRequiredSection(DatabaseName));
        var postgresConfig = configuration.GetOptions<PostgresConfig>(DatabaseName);
        services.AddDbContext<BodyGuardDbContext>(x => x.UseNpgsql(postgresConfig.ConnectionString));
        services.AddHostedService<DbInitializer>();
        
        // EF Core + Npgsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}