using ICommand = Application.Abstractions.Messaging.Command.ICommand;

namespace Application.Commands.Workout;

public record EditWorkoutCommand(Guid ExerciseId,string Name, string Category) : ICommand;