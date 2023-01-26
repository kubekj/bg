using Application.Abstractions.Messaging.Command;

namespace Application.Queries.Statistics;

public record GetWeightAvgByMonthCommand(Guid UserId) : ICommand;