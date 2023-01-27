using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetTrainingPlansQueryHandler : IQueryHandler<GetTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetTrainingPlansQuery query)
    {
        var trainingPlans = await _trainingPlanRepository
            .GetAllAsync(tp => tp.AllowedUsers.Any(user => user.UserId == query.UserId));
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}