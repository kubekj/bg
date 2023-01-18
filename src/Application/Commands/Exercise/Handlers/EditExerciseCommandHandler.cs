using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Mapster;

namespace Application.Commands.Exercise.Handlers;

public class EditExerciseCommandHandler : ICommandHandler<EditExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;

    public EditExerciseCommandHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task HandleAsync(EditExerciseCommand command)
    {
        var exercise = command.ExerciseDto.Adapt<Core.Entities.Exercise>();
        await _exerciseRepository.EditAsync(exercise);
    }
}