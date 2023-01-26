using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Workout.Handlers;

public class CreateWorkoutSessionCommandHandler : ICommandHandler<CreateWorkoutSessionCommand>
{
    public Task HandleAsync(CreateWorkoutSessionCommand command)
    {
        throw new NotImplementedException();
    }
}