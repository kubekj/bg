using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Exercise;

public record GetExerciseQuery(Guid UserId,Guid ExerciseId) : IQuery<ExerciseDto>;