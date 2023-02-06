using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class RateTrainingPlanCommandHandler : ICommandHandler<RateTrainingPlanCommand>
{
    private readonly IRatingRepository _ratingRepository;

    public RateTrainingPlanCommandHandler(IRatingRepository ratingRepository) => _ratingRepository = ratingRepository;

    public async Task HandleAsync(RateTrainingPlanCommand command) 
        => await _ratingRepository.RatePlan(new Rating(Guid.NewGuid(),command.Rate,""));
}