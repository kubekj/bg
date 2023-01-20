using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;

namespace Application.Commands.Exercise;

public record CreateExerciseCommand(Guid UserId, string Name, string BodyPart, string Category) : ICommand;