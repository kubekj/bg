using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class RateTrainingPlanCommandHandler : ICommandHandler<RateTrainingPlanCommand>
{
    private readonly IRatingRepository _ratingRepository;

    public RateTrainingPlanCommandHandler(IRatingRepository ratingRepository) => _ratingRepository = ratingRepository;

    public async Task HandleAsync(RateTrainingPlanCommand command) 
        => await _ratingRepository.RatePlan(new Rating(Guid.NewGuid(),command.Rate,DetermineDescription(command.Rate),command.UserId,command.TrainingPlanId));

    private static string DetermineDescription(int rate)
    {
        var desc = rate switch
        {
            1 => "Awful",
            2 => "Could've been better",
            3 => "Fine",
            4 => "Superb",
            5 => "Amazing",
            _ => "No comment added"
        };

        return desc;
    }
}
