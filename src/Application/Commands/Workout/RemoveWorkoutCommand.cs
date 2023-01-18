using ICommand = Application.Abstractions.Messaging.Command.ICommand;

namespace Application.Commands.Workout;

public record RemoveWorkoutCommand(Guid UserId, Guid ExerciseId) : ICommand;