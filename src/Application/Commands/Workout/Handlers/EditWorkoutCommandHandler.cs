using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.Workout.Handlers;

public class EditWorkoutCommandHandler : ICommandHandler<EditWorkoutCommand>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;

    public EditWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository) => _userWorkoutRepository = userWorkoutRepository;

    public Task HandleAsync(EditWorkoutCommand command)
    {
        throw new NotImplementedException();
    }
}