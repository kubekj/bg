using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan;

public record GetBoughtTrainingPlansQuery(Guid UserId) : IQuery<IEnumerable<TrainingPlanDto>>;