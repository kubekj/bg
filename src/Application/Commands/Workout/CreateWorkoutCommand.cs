using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;

namespace Application.Commands.Workout;

public record CreateWorkoutCommand(Guid UserId,string Name,string Category, IDictionary<Guid,IEnumerable<SetDto>> ExerciseWithSets) : ICommand;