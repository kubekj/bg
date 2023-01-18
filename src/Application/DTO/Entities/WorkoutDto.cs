namespace Application.DTO.Entities;

public record WorkoutDto(string Name, string Category, IEnumerable<ExerciseDto> Exercises);