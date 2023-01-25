using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetTrainingPlansQueryHandler : IQueryHandler<GetTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    public Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetTrainingPlansQuery query)
    {
        throw new NotImplementedException();
    }
}