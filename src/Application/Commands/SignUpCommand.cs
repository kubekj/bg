using Application.Abstractions.Messaging.Command;

namespace Application.Commands;

public record SignUpCommand(Guid UserId, string Email, string Password, string FirstName, string LastName) : ICommand;