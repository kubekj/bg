using MediatR;

namespace Application.Abstractions.Messaging.Query;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}