using Application.Abstractions.Messaging.Command;

namespace Application.Queries.Statistics.Handlers;

public class GetWeightAvgByMonthCommandHandler : ICommandHandler<GetWeightAvgByMonthCommand>
{
    public Task HandleAsync(GetWeightAvgByMonthCommand command)
    {
        throw new NotImplementedException();
    }
}