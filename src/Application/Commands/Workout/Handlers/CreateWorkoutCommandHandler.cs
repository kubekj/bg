using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.Exercise;
using Core.ValueObjects.Common;
using Core.ValueObjects.Set;
using Core.ValueObjects.Workout;
using Mapster;

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
        var existingWorkout = _workoutService.CheckIfWorkoutAlreadyExists(allWorkouts,workout);

        if (existingWorkout is not null)
        {
            var allUserWorkouts = (await _userWorkoutRepository
                .GetAllAsync(x => x.UserId == command.UserId)).ToList();
            var existingUserWorkout = _userWorkoutService.CheckIfUserWorkoutAlreadyExists(allUserWorkouts, existingWorkout.Id);

            if (existingUserWorkout != null)
                throw new UserAlreadyHasThatWorkoutException(existingWorkout.Name);

            var workoutExerciseWorkouts = existingWorkout.ExerciseWorkouts.ToList();
            workoutExerciseWorkouts
                .AddRange(command.ExerciseWithSets.Select(exercise =>
                {
                    var sets = new HashSet<Set>();
                    foreach (var setDto in exercise.Value)
                        sets.Add(new Set(Guid.NewGuid(), setDto.Repetitions, new Weight(setDto.Weight), exercise.Key,
                            existingWorkout.Id));
                    return new ExerciseWorkout(exercise.Key, existingWorkout.Id,
                            sets);
                }));

            var newWorkout = new Core.Entities.Workout(Guid.NewGuid(), workoutName, category, workoutExerciseWorkouts);
            await _workoutRepository.AddAsync(newWorkout);
            await _userWorkoutRepository.AddAsync(new UserWorkout(newWorkout.Id, command.UserId));
        } 

        await _workoutRepository.AddAsync(workout);
        foreach (var exercise in command.ExerciseWithSets)
        {
            var sets = new HashSet<Set>();
            foreach (var setDto in exercise.Value)
                sets.Add(new Set(Guid.NewGuid(), setDto.Repetitions, new Weight(setDto.Weight), exercise.Key,
                    workout.Id));
            await _exerciseWorkoutRepository.AddAsync(new ExerciseWorkout(exercise.Key, workoutId,
                sets));
        }

        await _userWorkoutRepository.AddAsync(new UserWorkout(workoutId,command.UserId));
    }
}