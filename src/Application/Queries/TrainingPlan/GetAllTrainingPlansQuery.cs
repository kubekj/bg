using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetAllTrainingPlansQuery() : IQuery<IEnumerable<TrainingPlanDto>>;