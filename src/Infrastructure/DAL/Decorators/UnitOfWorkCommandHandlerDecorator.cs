using Application.Abstractions.Messaging.Command;
using Infrastructure.DAL.UoW;

namespace Infrastructure.DAL.Decorators;

internal sealed class UnitOfWorkCommandHandlerDecorator<TRequest> : ICommandHandler<TRequest> where TRequest : class, ICommand
{
    private readonly ICommandHandler<TRequest> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TRequest> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(TRequest command) => await _unitOfWork.ExecuteAsync(() => _commandHandler.HandleAsync(command));
}