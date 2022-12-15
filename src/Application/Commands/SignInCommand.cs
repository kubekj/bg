using Application.Abstractions.Messaging.Command;

namespace Application.Commands;

public record SignInCommand(string Email, string Password) : ICommand;