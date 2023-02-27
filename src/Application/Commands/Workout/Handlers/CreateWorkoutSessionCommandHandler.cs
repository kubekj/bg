using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Shared;

namespace Application.Commands.Workout.Handlers;

public class CreateWorkoutSessionCommandHandler : ICommandHandler<CreateWorkoutSessionCommand>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IClock _clock;
    
    public CreateWorkoutSessionCommandHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository, IClock clock)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _clock = clock;
    }

    public async Task HandleAsync(CreateWorkoutSessionCommand command)
    {
        if (_clock.Current() > command.Date)
            throw new CannotAddWorkoutToPastDateException();

        var userWorkoutSession = new UserWorkoutSession(command.UserId,command.WorkoutId,command.Date);
        await _userWorkoutSessionRepository.AddAsync(userWorkoutSession);
    }
}