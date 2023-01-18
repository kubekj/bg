using ICommand = Application.Abstractions.Messaging.Command.ICommand;

namespace Application.Commands.Workout;

public record EditWorkoutCommand(string Name, string Category) : ICommand;