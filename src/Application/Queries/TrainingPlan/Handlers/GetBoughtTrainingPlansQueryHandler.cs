using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetBoughtTrainingPlansQueryHandler : IQueryHandler<GetBoughtTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    public Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetBoughtTrainingPlansQuery query)
    {
        throw new NotImplementedException();
    }
}