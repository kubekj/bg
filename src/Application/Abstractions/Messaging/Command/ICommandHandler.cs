namespace Application.Abstractions.Messaging.Command;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}
