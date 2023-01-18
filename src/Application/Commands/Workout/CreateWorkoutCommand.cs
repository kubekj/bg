using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Workout;

public record CreateWorkoutCommand(Guid UserId,string Name,string Category, IEnumerable<Guid> ExerciseIds) : ICommand;