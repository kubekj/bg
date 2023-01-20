namespace Application.DTO.Entities;

public record WorkoutDto(Guid Id,
    string? Name = default, 
    string? Category = default, 
    IEnumerable<ExerciseDto>? ExerciseDtos = default);