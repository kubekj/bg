using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Core.ValueObjects.TrainingPlan;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetAllTrainingPlansQueryHandler : IQueryHandler<GetAllTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetAllTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetAllTrainingPlansQuery query)
    {
        var trainingPlans = await _trainingPlanRepository
            .GetAllAsync(tp => tp.AllowedUsers.All(x => x.UserId != query.UserId) && tp.Status != Status.Unpublished);
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}