using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record RemoveTrainingPlanCommand(Guid TrainingPlanId) : ICommand;