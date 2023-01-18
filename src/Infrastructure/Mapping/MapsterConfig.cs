using Application.DTO.Entities;
using Core.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mapping;

public static class MapsterConfig
{
    public static void AddMapsterConfig(this IServiceCollection services)
    {
        TypeAdapterConfig<Workout, WorkoutDto>
            .NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Category, src => src.Category)
            .Map(dest => dest.Exercises, src => src.ExerciseWorkouts.Select(e => e.Exercise).ToList())
            .IgnoreNonMapped(true);

        TypeAdapterConfig<Exercise, ExerciseDto>
            .NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.BodyPart, src => src.BodyPart)
            .Map(dest => dest.Category, src => src.Category)
            .IgnoreNonMapped(true);
    }
}