using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetMostRecentlyCreatedPlansQueryHandler : IQueryHandler<GetMostRecentlyCreatedPlansQuery,IEnumerable<TrainingPlanDto>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetMostRecentlyCreatedPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetMostRecentlyCreatedPlansQuery query)
    {
        var trainingPlans = (await _trainingPlanRepository
            .GetAllAsync(x => x.Author.Email == query.Email))
            .ToList()
            .OrderByDescending(x => x.CreatedAt)
            .Take(3);
        
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}