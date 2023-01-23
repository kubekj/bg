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
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Category, src => src.Category)
            .Map(dest => dest.ExerciseDtos, src => src.ExerciseWorkouts.Select(ew => new ExerciseDto(
                ew.ExerciseId,
                ew.Exercise.Name,
                ew.Exercise.BodyPart,
                ew.Exercise.Category,
                ew.Sets
                    .Adapt<IEnumerable<SetDto>>()
                    .ToList()
            )).ToList().Adapt<IEnumerable<ExerciseDto>>().ToList())
            .IgnoreNonMapped(true);

        TypeAdapterConfig<Exercise, ExerciseDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.BodyPart, src => src.BodyPart)
            .Map(dest => dest.Category, src => src.Category)
            .IgnoreNonMapped(true);
        
        TypeAdapterConfig<Set, SetDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Repetitions, src => src.Repetitions)
            .Map(dest => dest.Weight, src => src.Weight)
            .IgnoreNonMapped(true);
    }
}