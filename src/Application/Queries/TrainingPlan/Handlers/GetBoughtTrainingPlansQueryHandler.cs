using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetBoughtTrainingPlansQueryHandler : IQueryHandler<GetAllTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    public Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetAllTrainingPlansQuery query)
    {
        throw new NotImplementedException();
    }
}