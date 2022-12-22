using Infrastructure.Auth;
using Infrastructure.DAL;
using Infrastructure.Logging;
using Infrastructure.Middleware;
using Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSingleton<ExceptionMiddleware>();
        services.AddPostgres(configuration);
        services.AddInfrastructureRepositories();
        services.AddCustomLogging();
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddAuthorization();
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        //Wyłuskanie opcji z konfiguracji poprzez wskazanie nazwy sekcji w appsettingsach
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}