using MediatR;

namespace Application.Abstractions.Messaging.Command;

public interface ICommand : IRequest
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}