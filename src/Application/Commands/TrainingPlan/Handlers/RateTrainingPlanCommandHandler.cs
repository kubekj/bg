using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan.Handlers;

public class RateTrainingPlanCommandHandler : ICommandHandler<RateTrainingPlanCommand>
{
    public Task HandleAsync(RateTrainingPlanCommand command)
    {
        throw new NotImplementedException();
    }
}