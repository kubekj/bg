using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class RemoveTrainingPlanCommandHandler : ICommandHandler<RemoveTrainingPlanCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public RemoveTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task HandleAsync(RemoveTrainingPlanCommand command)
    {
        var trainingPlan = await _trainingPlanRepository.GetByIdAsync(command.TrainingPlanId);
        trainingPlan.MarkAsDeleted();
        await _trainingPlanRepository.UpdateAsync(trainingPlan);
    }
}