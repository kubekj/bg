using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.TrainingPlan.Handlers;

public class GetTrainingPlanQueryHandler : IQueryHandler<GetTrainingPlanQuery,TrainingPlanDto>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IRatingRepository _ratingRepository;

    public GetTrainingPlanQueryHandler(ITrainingPlanRepository trainingPlanRepository, 
        IRatingRepository ratingRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _ratingRepository = ratingRepository;
    }

    public async Task<TrainingPlanDto> HandleAsync(GetTrainingPlanQuery query)
    {
        var userTrainingPlan = await _trainingPlanRepository.GetByIdAsync(query.TrainingPlanId);
        var utp = userTrainingPlan.Adapt<TrainingPlanDto>();
        var canRate = await _ratingRepository.GetRatingForPlan(query.UserId,query.TrainingPlanId);

        if (canRate is not null || userTrainingPlan.AuthorId == query.UserId)
            return utp with { AlreadyRated = true };

        return utp with { AlreadyRated = false };
    }
}