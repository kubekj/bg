namespace Application.DTO.Entities;

public record TrainingPlanDto(
    Guid Id,
    string Title,
    double Duration,
    int NoOfWorkouts,
    string SkillLevel,
    string Description,
    string Language,
    string CreatorEmail,
    double RatingAvg,
    int RatingsApplied,
    decimal Price,
    DateTime CreatedAt,
    IEnumerable<WorkoutDto> Workouts);