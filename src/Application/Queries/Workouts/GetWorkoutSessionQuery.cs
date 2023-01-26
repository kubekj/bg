using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetWorkoutSessionQuery(Guid UserId) : IQuery<WorkoutDto>;