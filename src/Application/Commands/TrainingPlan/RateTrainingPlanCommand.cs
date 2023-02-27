using System;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.TrainingPlan;

public record RateTrainingPlanCommand(
    Guid UserId,
    Guid TrainingPlanId,
    int Rate) : ICommand;