using System.Collections;

namespace Application.DTO.Entities;

public record ExerciseWorkoutDto(Guid Id, 
    string Name, 
    string Category,
    IEnumerable<ExerciseDto> ExerciseDtos ,
    IEnumerable<SetDto> SetDtos);