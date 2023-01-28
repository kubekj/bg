using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.ExerciseWorkout;
using Core.Services.UserWorkout;
using Core.Services.Workout;
using Core.ValueObjects.Common;
using Core.ValueObjects.Workout;

namespace Application.Commands.Workout.Handlers;

public class CreateWorkoutCommandHandler : ICommandHandler<CreateWorkoutCommand>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;

    private readonly IWorkoutService _workoutService;
    private readonly IUserWorkoutService _userWorkoutService;
    private readonly IExerciseWorkoutService _exerciseWorkoutService;

    public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository,
        IUserWorkoutRepository userWorkoutRepository, 
        IUserWorkoutService userWorkoutService, 
        IWorkoutService workoutService, 
        IExerciseWorkoutService exerciseWorkoutService)
    {
        _workoutRepository = workoutRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userWorkoutService = userWorkoutService;
        _workoutService = workoutService;
        _exerciseWorkoutService = exerciseWorkoutService;
    }

    public async Task HandleAsync(CreateWorkoutCommand command)
    {
        //Creation of a workout 
        var workoutId = Guid.NewGuid();
        var workoutName = new WorkoutName(command.Name);
        var category = new Category(command.Category);
        var workout = new Core.Entities.Workout(workoutId,workoutName,category);

        var exercisesWithSets = command.ExerciseWithSets
            .ToDictionary(k => k.Key,
                v => v.Value.Select(s => new Set(Guid.NewGuid(),s.Repetitions,s.Weight)));
        
        //Check if workout exists
        var allWorkouts = (await _workoutRepository.GetAllAsync()).ToList();
        var existingWorkout = _workoutService.CheckIfWorkoutAlreadyExists(allWorkouts,workout);
        
        if (existingWorkout is not null)
        {
            //Check if user already has that workout assigned
            var allUserWorkouts = (await _userWorkoutRepository
                .GetAllAsync(x => x.UserId == command.UserId)).ToList();
            var existingUserWorkout = _userWorkoutService.CheckIfUserWorkoutAlreadyExists(allUserWorkouts, existingWorkout);

            if (existingUserWorkout is not null)
                throw new UserAlreadyHasThatWorkoutException(existingWorkout.Name);
            
            //If no assign that exercise to user and add sets to certain exercises
            await _exerciseWorkoutService
                .HandleExerciseWithSetsCreation(existingWorkout.Id,exercisesWithSets);
            
            await _userWorkoutRepository.AddAsync(new UserWorkout(existingWorkout.Id, command.UserId));
        }

        await _workoutRepository.AddAsync(workout);
        await _exerciseWorkoutService.HandleExerciseWithSetsCreation(workout.Id,exercisesWithSets);
        await _userWorkoutRepository.AddAsync(new UserWorkout(workout.Id,command.UserId));
    }
}