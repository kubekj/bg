using Application.Abstractions.Messaging.Command;
using Core.Repositories;

namespace Application.Commands.Workout.Handlers;

public class RemoveWorkoutSessionCommandHandler : ICommandHandler<RemoveWorkoutSessionCommand>
{
    private readonly IUserWorkoutSessionRepository _sessionRepository;

    public RemoveWorkoutSessionCommandHandler(IUserWorkoutSessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task HandleAsync(RemoveWorkoutSessionCommand command)
    {
        var userWorkoutSession = await _sessionRepository
            .GetAllAsync(x => x.UserId == command.UserId && x.WorkoutId == command.WorkoutId && x.Date == command.Date);
        await _sessionRepository.RemoveAsync(userWorkoutSession.SingleOrDefault());
    }
}