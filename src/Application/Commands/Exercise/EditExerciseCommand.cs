using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;

namespace Application.Commands.Exercise;

public record EditExerciseCommand(Guid UserId, Guid ExerciseId,string Name, string BodyPart, string Category) : ICommand;