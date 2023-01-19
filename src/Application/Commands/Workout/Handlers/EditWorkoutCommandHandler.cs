using Application.Abstractions.Messaging.Command;
using Application.DTO.Entities;
using Core.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Commands.Workout.Handlers;

public class EditWorkoutCommandHandler : ICommandHandler<EditWorkoutCommand>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public EditWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository, IWorkoutRepository workoutRepository)
    {
        _userWorkoutRepository = userWorkoutRepository;
        _workoutRepository = workoutRepository;
    }

    public async Task HandleAsync(EditWorkoutCommand command)
    {
        var userWorkout = await _userWorkoutRepository.GetByIdAsync(command.UserId, command.WorkoutId);

        if (userWorkout is null)
            return;

        var otherUserWorkouts = await _userWorkoutRepository
            .GetAllAsync(x => x.WorkoutId == command.WorkoutId && x.UserId != command.UserId);

        if (otherUserWorkouts.Any())
        {
            var copiedWorkout = userWorkout.Workout.CreateCopyForUser(command.WorkoutDto.Name,command.WorkoutDto.Category);
            await _workoutRepository.AddAsync(copiedWorkout);

            var newUserWorkout = new UserWorkout(copiedWorkout.Id, command.UserId);
            await _userWorkoutRepository.AddAsync(newUserWorkout);

            return;
        }

        var workout = command.WorkoutDto.Adapt<Core.Entities.Workout>();
        await _workoutRepository.AddAsync(workout);
    }
}