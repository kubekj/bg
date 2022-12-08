using Application.Abstractions.Messaging.Command;
using Core.ValueObjects.User;

namespace Application.Commands;

public record SignUpCommand(Guid UserId, string Email, string Password, string FirstName, string LastName, DateTime CreatedAt, string Role) : ICommand;