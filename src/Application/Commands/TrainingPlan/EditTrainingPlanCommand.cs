using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record EditTrainingPlanCommand(Guid UserId, 
    Guid TrainingId,
    double Duration, 
    decimal Price, 
    string SkillLevel, 
    string Title, 
    string Description,
    string Status,
    string Language,    
    IEnumerable<Guid> Workouts) : ICommand;