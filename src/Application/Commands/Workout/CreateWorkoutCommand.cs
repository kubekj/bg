using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;
using Core.Entities;

namespace Application.Commands.Workout;

public record CreateWorkoutCommand(Guid UserId,string Name,string Category, IDictionary<Guid,IEnumerable<SetDto>> ExerciseWithSets) : ICommand;