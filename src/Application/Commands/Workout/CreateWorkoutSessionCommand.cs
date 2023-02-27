using System;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Workout;

public record CreateWorkoutSessionCommand(Guid UserId, Guid WorkoutId, DateTime Date) : ICommand;