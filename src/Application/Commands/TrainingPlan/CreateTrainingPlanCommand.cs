using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record CreateTrainingPlanCommand(
    double Duration, 
    decimal Price, 
    string SkillLevel, 
    string Title, 
    string Description,
    Guid AuthorId,
    string Status,
    string Language,    
    IEnumerable<Guid> Workouts) : ICommand;