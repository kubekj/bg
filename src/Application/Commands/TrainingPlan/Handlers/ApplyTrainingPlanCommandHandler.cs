using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class ApplyTrainingPlanCommandHandler : ICommandHandler<ApplyTrainingPlanCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly ITrainingPlanWorkoutRepository _trainingPlanWorkoutRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepositoryRepository;

    public ApplyTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository, 
        ITrainingPlanWorkoutRepository trainingPlanWorkoutRepository, 
        IUserWorkoutRepository userWorkoutRepository, 
        IUserWorkoutSessionRepository userWorkoutSessionRepositoryRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _trainingPlanWorkoutRepository = trainingPlanWorkoutRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userWorkoutSessionRepositoryRepository = userWorkoutSessionRepositoryRepository;
    }

    public Task HandleAsync(ApplyTrainingPlanCommand command)
    {
        throw new NotImplementedException();
    }
}