using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetCreatedTrainingPlansQueryHandler : IQueryHandler<GetCreatedTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    public Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetCreatedTrainingPlansQuery query)
    {
        throw new NotImplementedException();
    }
}