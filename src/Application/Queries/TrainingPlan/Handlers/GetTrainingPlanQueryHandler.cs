using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetTrainingPlanQueryHandler : IQueryHandler<GetTrainingPlanQuery,TrainingPlanDto>
{
    public Task<TrainingPlanDto> HandleAsync(GetTrainingPlanQuery query)
    {
        throw new NotImplementedException();
    }
}