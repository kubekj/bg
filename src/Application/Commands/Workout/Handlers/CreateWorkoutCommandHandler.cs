using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.Exercise;
using Core.ValueObjects.Common;
using Core.ValueObjects.Workout;

namespace Application.Commands.Workout.Handlers;

public class CreateWorkoutCommandHandler : ICommandHandler<CreateWorkoutCommand>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IWorkoutService _workoutService;
    private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IUserWorkoutService _userWorkoutService;

    public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, 
        IExerciseWorkoutRepository exerciseWorkoutRepository, 
        IUserWorkoutRepository userWorkoutRepository, 
        IUserWorkoutService userWorkoutService, 
        IWorkoutService workoutService)
    {
        _workoutRepository = workoutRepository;
        _exerciseWorkoutRepository = exerciseWorkoutRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userWorkoutService = userWorkoutService;
        _workoutService = workoutService;
    }

    public async Task HandleAsync(CreateWorkoutCommand command)
    {
        var workoutId = Guid.NewGuid();
        var workoutName = new WorkoutName(command.Name);
        var category = new Category(command.Category);
        var workout = new Core.Entities.Workout(workoutId,workoutName,category);

        var allWorkouts = await _workoutRepository.GetAllAsync();
        var existingWorkoutId = _workoutService.CheckIfWorkoutAlreadyExists(allWorkouts,workout);

        if (existingWorkoutId is not null)
        {
            var allUserWorkouts = (await _userWorkoutRepository
                .GetAllAsync(x => x.UserId == command.UserId)).ToList();
            var existingUserWorkoutId = _userWorkoutService.CheckIfUserWorkoutAlreadyExists(allUserWorkouts, workout);

            if (existingUserWorkoutId is not null)
                throw new UserAlreadyHasThatWorkoutException(workout.Name);

            await _userWorkoutRepository.AddAsync(new UserWorkout(existingWorkoutId.Value,command.UserId));
            return;
        }

        await _workoutRepository.AddAsync(workout);
        foreach (var exerciseId in command.ExerciseIds) await _exerciseWorkoutRepository.AddAsync(new ExerciseWorkout(exerciseId,workoutId));
        await _userWorkoutRepository.AddAsync(new UserWorkout(workoutId,command.UserId));
    }
}