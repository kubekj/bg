using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Core.Exceptions;
using Core.Repositories;

namespace Application.Commands.Exercise.Handlers;

public class RemoveExerciseCommandHandler : ICommandHandler<RemoveExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;

    private readonly IUserExerciseRepository _userExerciseRepository;

    public RemoveExerciseCommandHandler(IExerciseRepository exerciseRepository,
        IUserExerciseRepository userExerciseRepository, 
        IUserWorkoutRepository userWorkoutRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userExerciseRepository = userExerciseRepository;
        _userWorkoutRepository = userWorkoutRepository;
    }

    public async Task HandleAsync(RemoveExerciseCommand command)
    {
        var otherUserExercises = await _userExerciseRepository
            .GetAllAsync(x => x.ExerciseId == command.ExerciseId && x.UserId != command.UserId);

        var userWorkouts = await _userWorkoutRepository.GetAllAsync(x => x.UserId == command.UserId);

        if (userWorkouts.Any(userWorkout => userWorkout.Workout.ExerciseWorkouts.Any(x => x.ExerciseId == command.ExerciseId)))
            throw new CannotRemoveAssignedExerciseException();

        if (otherUserExercises.Any())
        {
            await _userExerciseRepository.RemoveAsync(command.UserId, command.ExerciseId);
            return;
        }
        
        await _exerciseRepository.RemoveAsync(command.ExerciseId);
    }
}

public class CannotRemoveAssignedExerciseException : CoreException
{
    public CannotRemoveAssignedExerciseException() : base("If you want to remove this exercise first remove all workouts containing it")
    {
    }
}