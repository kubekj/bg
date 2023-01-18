using Application.Abstractions.Messaging.Command;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Logging;

public static class Extensions
{
    public static void AddCustomLogging(this IServiceCollection services) => services.TryDecorate(typeof(ICommandHandler<>), typeof(LogCommandHandlerDecorator<>));

    public static void UseSerilog(this WebApplicationBuilder builder) =>
        builder.Host.UseSerilog((_, configuration) =>
            configuration.WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day).WriteTo.Console());
}