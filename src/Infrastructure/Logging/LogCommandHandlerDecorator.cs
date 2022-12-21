using Application.Abstractions.Messaging.Command;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Logging;

public class LogCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly ILogger<ICommandHandler<TCommand>> _logger;

    public LogCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ILogger<ICommandHandler<TCommand>> logger)
    {
        _commandHandler = commandHandler;
        _logger = logger;
    }

    public async Task HandleAsync(TCommand command)
    {
        var commandName = typeof(TCommand).Name;
        _logger.LogInformation("Handling command named: {CommandName} started ...", commandName);
        await _commandHandler.HandleAsync(command);
        _logger.LogInformation("Handling command named: {CommandName} finished ...", commandName);
    }
}