using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.Workout.Handlers;

public class RemoveWorkoutCommandHandler : ICommandHandler<RemoveWorkoutCommand>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;

    public RemoveWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository) => _userWorkoutRepository = userWorkoutRepository;

    public async Task HandleAsync(RemoveWorkoutCommand command) => await _userWorkoutRepository.RemoveAsync(command.UserId, command.ExerciseId);
}