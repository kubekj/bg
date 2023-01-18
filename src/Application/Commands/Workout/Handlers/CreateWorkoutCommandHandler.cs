using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Core.Services.Exercise;
using Core.ValueObjects.Workout;

namespace Application.Commands.Workout.Handlers;

public class CreateWorkoutCommandHandler : ICommandHandler<CreateWorkoutCommand>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IUserWorkoutService _userWorkoutService;

    public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, 
        IExerciseWorkoutRepository exerciseWorkoutRepository, 
        IUserWorkoutRepository userWorkoutRepository, 
        IUserWorkoutService userWorkoutService)
    {
        _workoutRepository = workoutRepository;
        _exerciseWorkoutRepository = exerciseWorkoutRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userWorkoutService = userWorkoutService;
    }

    public async Task HandleAsync(CreateWorkoutCommand command)
    {
        var workoutId = Guid.NewGuid();
        var workout = new Core.Entities.Workout(workoutId,command.Name,command.Category);
        
        var allUserWorkouts = (await _userWorkoutRepository
            .GetAllAsync(x => x.UserId == command.UserId)).ToList();
        var existingUserWorkoutId = _userWorkoutService.CheckIfUserWorkoutAlreadyExists(allUserWorkouts, workout);

        if (existingUserWorkoutId != null)
            throw new UserAlreadyHasThatWorkoutException(workout.Name);

        await _workoutRepository.AddAsync(workout);
        foreach (var exerciseId in command.ExerciseIds) await _exerciseWorkoutRepository.AddAsync(new ExerciseWorkout(exerciseId,workoutId));
        await _userWorkoutRepository.AddAsync(new UserWorkout(workoutId,command.UserId));
    }
}

public class UserAlreadyHasThatWorkoutException : CoreException
{
    public UserAlreadyHasThatWorkoutException(WorkoutName workoutName) : base($"Workout with that name: {workoutName} is already on your list")
    {
    }
}