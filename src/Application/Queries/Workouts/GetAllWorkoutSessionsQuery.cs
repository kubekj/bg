using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetAllWorkoutSessionsQuery(Guid UserId) : IQuery<IEnumerable<WorkoutSessionDto>>;