using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetWorkoutsQuery(Guid UserId) : IQuery<IEnumerable<WorkoutDto>>;