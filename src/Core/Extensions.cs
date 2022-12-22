using Core.Services.Exercise;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUserExerciseService, UserExerciseService>();
        services.AddSingleton<IExerciseService, ExerciseService>();
    }
}