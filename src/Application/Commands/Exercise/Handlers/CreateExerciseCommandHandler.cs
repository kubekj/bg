using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Core.Services.Exercise;
using Core.ValueObjects.Common;
using Core.ValueObjects.Exercise;

namespace Application.Commands.Exercise.Handlers;

internal sealed class CreateExerciseCommandHandler : ICommandHandler<CreateExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserExerciseRepository _userExerciseRepository;
    private readonly IUserExerciseService _service;


    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, 
        IUserExerciseRepository userExerciseRepository, IUserExerciseService service)
    {
        _exerciseRepository = exerciseRepository;
        _userExerciseRepository = userExerciseRepository;
        _service = service;
    }

    public async Task HandleAsync(CreateExerciseCommand command)
    {
        var id = new Guid();
        var exerciseName = new ExerciseName(command.Name);
        var bodyPart = new BodyPart(command.BodyPart);
        var category = new Category(command.Category);
        
        var exercise = new Core.Entities.Exercise(id,exerciseName,bodyPart,category);
        
        // var allExercises = (await _userExerciseRepository.GetAllAsync()).ToList();
        // var canBeAdded = _service.CheckIfNameAlreadyExists(allExercises,request.UserId,exerciseName);

        // if (!canBeAdded)
        //     throw new ExerciseWithProvidedNameAlreadyExistsException(exerciseName);

        await _exerciseRepository.AddAsync(exercise);
    }
}