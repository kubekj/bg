using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;
using Core.Services.TrainingPlan;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.TrainingPlan;

namespace Application.Commands.TrainingPlan.Handlers;

public class EditTrainingPlanCommandHandler : ICommandHandler<EditTrainingPlanCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly ITrainingPlanWorkoutRepository _trainingPlanWorkoutRepository;

    private readonly ITrainingPlanService _trainingPlanService;

    public EditTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository, 
        ITrainingPlanWorkoutRepository trainingPlanWorkoutRepository, 
        ITrainingPlanService trainingPlanService)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _trainingPlanWorkoutRepository = trainingPlanWorkoutRepository;
        _trainingPlanService = trainingPlanService;
    }

    public async Task HandleAsync(EditTrainingPlanCommand command)
    {
        var existingTrainingPlan = await _trainingPlanRepository.GetByIdAsync(command.TrainingId);

        if (existingTrainingPlan is null)
            return;
        
        var duration = new Duration(command.Duration);
        var price = new Price(command.Price);
        var skillLevel = new SkillLevel(command.SkillLevel);
        var title = new Title(command.Title);
        var description = new Description(command.Description);
        var status = new Status(command.Status);
        var language = new Language(command.Language);

        existingTrainingPlan.Update(duration, price, skillLevel, title, description, status, language);
        
        var currentWorkouts = existingTrainingPlan.TrainingPlanWorkouts.Select(x => x.WorkoutId).ToList();

        var workoutsToAdd = command.Workouts.Where(x => !currentWorkouts.Contains(x)).ToHashSet();
        var workoutsToRemove = existingTrainingPlan.TrainingPlanWorkouts.Where(x => !command.Workouts.Contains(x.WorkoutId));
        
        foreach (var workoutId in workoutsToAdd)
            await _trainingPlanWorkoutRepository.AddAsync(new TrainingPlanWorkout(existingTrainingPlan.Id, workoutId));
        
        foreach (var trainingPlanWorkout in workoutsToRemove)
            await _trainingPlanWorkoutRepository.RemoveAsync(trainingPlanWorkout);

        await _trainingPlanRepository.UpdateAsync(existingTrainingPlan);
    }
}