using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record SignUpCommand(Guid UserId, string Email, string Password, string FirstName, string LastName) : ICommand;