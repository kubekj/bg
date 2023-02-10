using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Workout;

public record RemoveWorkoutSessionCommand(Guid UserId, Guid WorkoutId, DateTime Date) : ICommand;