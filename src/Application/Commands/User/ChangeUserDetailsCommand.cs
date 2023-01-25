using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record ChangeUserDetailsCommand() : ICommand;