using Infrastructure.Auth;
using Infrastructure.DAL;
using Infrastructure.Logging;
using Infrastructure.Mapping;
using Infrastructure.Middleware;
using Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMapsterConfig();
        services.AddControllers();
        services.AddSingleton<ExceptionMiddleware>();
        services.AddPostgres(configuration);
        services.AddInfrastructureRepositories();
        services.AddCustomLogging();
        services.AddSecurity();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BodyGuard API",
                Version = "v1"
            });
        });
        services.AddAuth(configuration);
        services.AddAuthorization();
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSwagger();
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "docs";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
            reDoc.DocumentTitle = "BodyGuard API";
        });
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