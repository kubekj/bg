using System;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetPreviousWorkoutQuery(Guid UserId) : IQuery<Tuple<WorkoutDto,DateTime>>;