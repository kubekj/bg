using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetTrainingPlanQueryHandler : IQueryHandler<GetTrainingPlanQuery,TrainingPlanDto>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public GetTrainingPlanQueryHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<TrainingPlanDto> HandleAsync(GetTrainingPlanQuery query)
    {
        var userTrainingPlan = await _trainingPlanRepository.GetByIdAsync(query.TrainingPlanId);
        return userTrainingPlan.Adapt<TrainingPlanDto>();
    }
}