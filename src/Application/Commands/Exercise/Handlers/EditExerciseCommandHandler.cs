using Application.Abstractions.Messaging.Command;

namespace Application.Commands.Exercise.Handlers;

public class EditExerciseCommandHandler : ICommandHandler<EditExerciseCommand>
{
    public Task HandleAsync(EditExerciseCommand command)
    {
        throw new NotImplementedException();
    }
}