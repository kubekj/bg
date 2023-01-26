using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User.Handlers;

public class ChangeUserDetailsCommandHandler : ICommandHandler<ChangeUserDetailsCommand>
{
    public Task HandleAsync(ChangeUserDetailsCommand command)
    {
        throw new NotImplementedException();
    }
}