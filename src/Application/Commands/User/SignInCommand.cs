using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record SignInCommand(string Email, string Password) : ICommand;