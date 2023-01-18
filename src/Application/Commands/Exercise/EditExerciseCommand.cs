using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;

namespace Application.Commands.Exercise;

public record EditExerciseCommand(ExerciseDto ExerciseDto) : ICommand;