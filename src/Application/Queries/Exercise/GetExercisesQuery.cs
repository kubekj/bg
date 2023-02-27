using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Exercise;

public record GetExercisesQuery(Guid userId) : IQuery<IEnumerable<ExerciseDto>>;