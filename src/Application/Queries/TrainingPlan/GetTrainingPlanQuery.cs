using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetTrainingPlanQuery(Guid UserId, Guid TrainingPlanId) : IQuery<TrainingPlanDto>;