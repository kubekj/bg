using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan.Handlers;

public class EditTrainingPlanCommandHandler : ICommandHandler<EditTrainingPlanCommand>
{
    public Task HandleAsync(EditTrainingPlanCommand command)
    {
        throw new NotImplementedException();
    }
}