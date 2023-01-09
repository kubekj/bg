using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Core.Services.Exercise;

namespace Application.Commands.Exercise.Handlers;

public class RemoveExerciseCommandHandler : ICommandHandler<RemoveExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseService _exerciseService;

    private readonly IUserExerciseRepository _userExerciseRepository;
    private readonly IUserExerciseService _userExerciseService;

    public RemoveExerciseCommandHandler(IExerciseRepository exerciseRepository, IExerciseService exerciseService, 
        IUserExerciseRepository userExerciseRepository, IUserExerciseService userExerciseService)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseService = exerciseService;
        _userExerciseRepository = userExerciseRepository;
        _userExerciseService = userExerciseService;
    }

    public Task HandleAsync(RemoveExerciseCommand command)
    {
        throw new NotImplementedException();
    }
}