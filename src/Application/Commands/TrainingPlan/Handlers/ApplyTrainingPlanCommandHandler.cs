using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan.Handlers;

public class ApplyTrainingPlanCommandHandler : ICommandHandler<ApplyTrainingPlanCommand>
{
    public Task HandleAsync(ApplyTrainingPlanCommand command)
    {
        throw new NotImplementedException();
    }
}