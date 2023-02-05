namespace Application.DTO.Entities;

public record TrainerDto(
    string FirstName,
    string LastName,
    string Description,
    string PreferredLanguage,
    string TrainerEmail
    // IEnumerable<WorkoutDto> BestSellers,
    // IEnumerable<WorkoutDto> MostRecent
    );