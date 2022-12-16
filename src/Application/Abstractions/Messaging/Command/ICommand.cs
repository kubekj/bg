namespace Application.Abstractions.Messaging.Command;

public interface ICommand
{
}

public interface ICommand<out TResponse>
{
}