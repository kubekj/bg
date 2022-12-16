using Core.Services.Exercise;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUserExerciseService, UserExerciseService>();
        return services;
    }
}