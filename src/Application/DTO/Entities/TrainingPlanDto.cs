namespace Application.DTO.Entities;

public record TrainingPlanDto(
    string Title,
    double Duration,
    int NoOfExercises,
    string SkillLevel,
    string Description,
    string Language,
    string CreatorEmail,
    double RatingAvg,
    IEnumerable<WorkoutDto> Workouts);