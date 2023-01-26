using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Goals.Handlers;

public class SetGoalCommandHandler : ICommandHandler<SetGoalCommand>
{
    public Task HandleAsync(SetGoalCommand command)
    {
        throw new NotImplementedException();
    }
}