using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetCreatedTrainingPlansQueryHandler : IQueryHandler<GetCreatedTrainingPlansQuery,IEnumerable<TrainingPlanDto>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetCreatedTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<IEnumerable<TrainingPlanDto>> HandleAsync(GetCreatedTrainingPlansQuery query)
    {
        var trainingPlans =
            await _trainingPlanRepository.GetAllAsync(tp => tp.AuthorId == query.AuthorId && !tp.IsDeleted);
        return trainingPlans.Adapt<IEnumerable<TrainingPlanDto>>();
    }
}