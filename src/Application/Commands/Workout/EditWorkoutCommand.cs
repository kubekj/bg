using Application.DTO.Entities;
using ICommand = Application.Abstractions.Messaging.Command.ICommand;

namespace Application.Commands.Workout;

public record EditWorkoutCommand(Guid UserId, Guid WorkoutId , WorkoutDto WorkoutDto) : ICommand;