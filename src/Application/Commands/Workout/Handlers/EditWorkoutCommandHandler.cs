using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.ExerciseWorkout;
using Core.Services.Workout;

namespace Application.Commands.Workout.Handlers;

public class EditWorkoutCommandHandler : ICommandHandler<EditWorkoutCommand>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IWorkoutRepository _workoutRepository;

    private readonly IWorkoutService _workoutService;
    private readonly IExerciseWorkoutService _exerciseWorkoutService;

    public EditWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository,
        IWorkoutRepository workoutRepository, 
        IExerciseWorkoutService exerciseWorkoutService,
        IWorkoutService workoutService)
    {
        _userWorkoutRepository = userWorkoutRepository;
        _workoutRepository = workoutRepository;
        _exerciseWorkoutService = exerciseWorkoutService;
        _workoutService = workoutService;
    }

    public async Task HandleAsync(EditWorkoutCommand command)
    {
        var userWorkout = await _userWorkoutRepository.GetByIdAsync(command.UserId, command.WorkoutId);

        if (userWorkout is null)
            return;
        
        var userWorkouts = (await _userWorkoutRepository
            .GetAllAsync(x => x.WorkoutId != command.WorkoutId && x.UserId == command.UserId)).ToList();

        if (userWorkouts.Any(uw => uw.Workout.Name.Value == command.Name))
            throw new UserAlreadyHasThatWorkoutException(command.Name);

        var anotherUserWorkouts = (await _userWorkoutRepository
            .GetAllAsync(x => x.WorkoutId == command.WorkoutId && x.UserId != command.UserId)).ToList();

        var exercisesWithSets = command.ExerciseWithSets
            .ToDictionary(k => k.Key, 
                v => v.Value.Select(s => new Set(s.Id,s.Repetitions,s.Weight)));

        if (anotherUserWorkouts.Any())
        {
            var copiedWorkout = userWorkout.Workout.CreateCopyForUser(command.Name,command.Category);
            await _workoutRepository.AddAsync(copiedWorkout);

            await _exerciseWorkoutService.HandleExerciseWithSetsCreation(copiedWorkout.Id,exercisesWithSets);

            await _userWorkoutRepository.RemoveAsync(userWorkout.UserId,userWorkout.WorkoutId);
            
            var newUserWorkout = new UserWorkout(copiedWorkout.Id, command.UserId);
            await _userWorkoutRepository.AddAsync(newUserWorkout);

            return;
        }

        if (exercisesWithSets.Any())
            await _exerciseWorkoutService.HandleExerciseWithSetsEdition(command.WorkoutId, exercisesWithSets);

        var newWorkout = new Core.Entities.Workout(command.WorkoutId, command.Name, command.Category);
        await _workoutRepository.EditAsync(newWorkout);
    }
}