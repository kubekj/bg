namespace Application.Abstractions.Messaging.Command;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}

public interface ICommandHandler<in TCommand, TResponse> where TCommand : class, ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command);
}