using System;
using System.Collections.Generic;

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
    bool AlreadyRated,
    string Status,
    IEnumerable<WorkoutDto> Workouts);