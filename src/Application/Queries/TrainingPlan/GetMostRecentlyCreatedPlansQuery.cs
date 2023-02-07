using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetMostRecentlyCreatedPlansQuery(string Email) : IQuery<IEnumerable<TrainingPlanDto>>;