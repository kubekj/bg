using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Core.Services.Exercise;

namespace Application.Commands.Exercise.Handlers;

public class RemoveExerciseCommandHandler : ICommandHandler<RemoveExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;

    private readonly IUserExerciseRepository _userExerciseRepository;

    public RemoveExerciseCommandHandler(IExerciseRepository exerciseRepository,
        IUserExerciseRepository userExerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userExerciseRepository = userExerciseRepository;
    }

    public async Task HandleAsync(RemoveExerciseCommand command)
    {
        var otherUserExercises = await _userExerciseRepository
            .GetAllAsync(x => x.ExerciseId == command.ExerciseId && x.UserId != command.UserId);
        
        if (otherUserExercises.Any())
        {
            await _userExerciseRepository.RemoveAsync(command.UserId, command.ExerciseId);
            return;
        }
        
        await _exerciseRepository.RemoveAsync(command.ExerciseId);
    }
}