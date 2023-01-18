namespace Application.DTO.Entities;

public record WorkoutDto(Guid Id,string Name, string Category, IEnumerable<ExerciseDto> Exercises);