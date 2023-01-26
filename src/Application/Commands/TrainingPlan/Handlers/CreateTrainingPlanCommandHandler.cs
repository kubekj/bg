using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.TrainingPlan;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.TrainingPlan;

namespace Application.Commands.TrainingPlan.Handlers;

public class CreateTrainingPlanCommandHandler : ICommandHandler<CreateTrainingPlanCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly ITrainingPlanWorkoutRepository _trainingPlanWorkoutRepository;

    private readonly ITrainingPlanService _trainingPlanService;

    public CreateTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository,  
        ITrainingPlanWorkoutRepository trainingPlanWorkoutRepository, 
        ITrainingPlanService trainingPlanService)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _trainingPlanWorkoutRepository = trainingPlanWorkoutRepository;
        _trainingPlanService = trainingPlanService;
    }

    public async Task HandleAsync(CreateTrainingPlanCommand command)
    {
        var trainingId = Guid.NewGuid();
        var duration = new Duration(command.Duration);
        var price = new Price(command.Price);
        var skillLevel = new SkillLevel(command.SkillLevel);
        var title = new Title(command.Title);
        var description = new Description(command.Description);
        var authorId = command.AuthorId;
        var status = new Status(command.Status);
        var language = new Language(command.Language);

        var trainingPlan = new Core.Entities.TrainingPlan(trainingId,duration,price,skillLevel,title,description,authorId,status,language);

        var allTrainingPlans = await _trainingPlanRepository.GetAllAsync();
        var existingTrainingPlan = _trainingPlanService.CheckIfTrainingPlanExists(allTrainingPlans,trainingPlan);

        if (existingTrainingPlan is not null)
            throw new TrainingPlanAlreadyExistsException(trainingPlan.Title);

        await _trainingPlanRepository.AddAsync(trainingPlan);
        foreach (var workoutId in command.Workouts)
            await _trainingPlanWorkoutRepository.AddAsync(new TrainingPlanWorkout(trainingId, workoutId));
    }
}