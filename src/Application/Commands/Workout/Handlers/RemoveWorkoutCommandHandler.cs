using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.Workout.Handlers;

public class RemoveWorkoutCommandHandler : ICommandHandler<RemoveWorkoutCommand>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public RemoveWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository, IWorkoutRepository workoutRepository)
    {
        _userWorkoutRepository = userWorkoutRepository;
        _workoutRepository = workoutRepository;
    }

    public async Task HandleAsync(RemoveWorkoutCommand command)
    {
        var otherUserWorkouts = (await _userWorkoutRepository
            .GetAllAsync(x => x.WorkoutId == command.WorkoutId && x.UserId != command.UserId)).ToList();

        if (otherUserWorkouts.Any() || otherUserWorkouts.Any(x => x.Workout.TrainingPlanWorkouts
                .Any(tpw => tpw.WorkoutId == command.WorkoutId)))
        {
            await _userWorkoutRepository.RemoveAsync(command.UserId, command.WorkoutId);
            return;
        }
        
        await _workoutRepository.RemoveAsync(command.WorkoutId);
    }
}