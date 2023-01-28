using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
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
        var trainingPlans = await _trainingPlanRepository.GetAllAsync();
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}