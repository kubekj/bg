using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetWorkoutQuery(Guid UserId,Guid WorkoutId) : IQuery<WorkoutDto>;