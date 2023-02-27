using System;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record SignUpAsCoachCommand(Guid UserId) : ICommand;