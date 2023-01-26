namespace Application.DTO.Entities;

public record ExerciseDto(Guid Id,
    string? Name = default,
    string? BodyPart = default,
    string? Category = default,
    IEnumerable<SetDto>? SetDtos = default);