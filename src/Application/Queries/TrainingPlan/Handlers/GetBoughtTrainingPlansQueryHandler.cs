using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetBoughtTrainingPlansQueryHandler : IQueryHandler<GetBoughtTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetBoughtTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetBoughtTrainingPlansQuery query)
    {
        var trainingPlans = 
            await _trainingPlanRepository.GetAllAsync(tp => tp.AllowedUsers.Any(x => x.UserId == query.UserId) || tp.AuthorId == query.UserId);
        
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}