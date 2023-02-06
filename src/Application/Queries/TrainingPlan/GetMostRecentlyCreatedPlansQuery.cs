using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetMostRecentlyCreatedPlansQuery(Guid TrainerId) : IQuery<IEnumerable<TrainingPlanDto>>;