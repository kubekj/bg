using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Goals;

public record SetGoalCommand(Guid UserId,int Goal) : ICommand;