using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetTrainingPlansQuery(Guid UserId) : IQuery<IEnumerable<TrainingPlanDto>>;