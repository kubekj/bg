using System;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Exercise;

public record CreateExerciseCommand(Guid UserId, string Name, string BodyPart, string Category) : ICommand;