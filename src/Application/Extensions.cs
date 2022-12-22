using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Utils;
using Core.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Extensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = AssemblyReference.Assembly;

        services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddSingleton<IClock, Clock>();
    }
}