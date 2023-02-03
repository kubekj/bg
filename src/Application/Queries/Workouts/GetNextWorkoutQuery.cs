using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetNextWorkoutQuery(Guid UserId) : IQuery<WorkoutDto>;