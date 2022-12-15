using Application.Utils;
using Core.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Extensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);
        services.AddSingleton<IClock, Clock>();
    }
}