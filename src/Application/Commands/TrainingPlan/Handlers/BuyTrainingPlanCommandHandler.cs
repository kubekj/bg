using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan.Handlers;

public class BuyTrainingPlanCommandHandler : ICommandHandler<BuyTrainingPlanCommand>
{
    public Task HandleAsync(BuyTrainingPlanCommand command)
    {
        throw new NotImplementedException();
    }
}