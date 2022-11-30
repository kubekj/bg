using Application.Abstractions.Messaging.Command;
using MediatR;

namespace Application.Commands;

public record SignUpCommand(Guid UserId, string Email, string Password, string FirstName, string LastName, string Role, DateTime CreatedAt) : ICommand;