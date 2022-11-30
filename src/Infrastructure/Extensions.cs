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
        services.AddDbContext<BodyGuardDbContext>(x =>
            x.UseNpgsql(configuration.GetConnectionString(configuration.GetConnectionString(DatabaseName)!)));
        services.AddHostedService<DbInitializer>();
    }
}