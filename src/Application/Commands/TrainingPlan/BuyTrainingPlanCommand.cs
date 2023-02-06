using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record BuyTrainingPlanCommand(Guid UserId, Guid TrainingPlanId) : ICommand;