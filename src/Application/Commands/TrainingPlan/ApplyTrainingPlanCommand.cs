using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record ApplyTrainingPlanCommand(
    Guid UserId,
    Guid TrainingPlanId,
    DateTime StartDate) : ICommand;