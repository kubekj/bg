using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Exercise;

public record RemoveExerciseCommand(Guid UserId, Guid ExerciseId) : ICommand;