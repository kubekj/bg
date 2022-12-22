using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.Exercise;
using Core.ValueObjects.Common;
using Core.ValueObjects.Exercise;

namespace Application.Commands.Exercise.Handlers;

internal sealed class CreateExerciseCommandHandler : ICommandHandler<CreateExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseService _exerciseService;

    private readonly IUserExerciseRepository _userExerciseRepository;
    private readonly IUserExerciseService _userExerciseService;


    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository,
        IUserExerciseRepository userExerciseRepository,
        IExerciseService exerciseService,
        IUserExerciseService userExerciseService)
    {
        _exerciseRepository = exerciseRepository;
        _userExerciseRepository = userExerciseRepository;
        _exerciseService = exerciseService;
        _userExerciseService = userExerciseService;
    }

    public async Task HandleAsync(CreateExerciseCommand command)
    {
        var id = new Guid();
        var exerciseName = new ExerciseName(command.Name);
        var bodyPart = new BodyPart(command.BodyPart);
        var category = new Category(command.Category);

        var exercise = new Core.Entities.Exercise(id, exerciseName, bodyPart, category);

        var allExercises = (await _exerciseRepository.GetAllAsync()).ToList();
        var existingExerciseId = _exerciseService.CheckIfExerciseAlreadyExists(allExercises, exercise);

        UserExercise userExercise;

        if (existingExerciseId is not null)
        {
            userExercise = new UserExercise(existingExerciseId.Value, command.UserId);
            var allUserExercises = (await _userExerciseRepository.GetAllAsync()).ToList();
            var userExerciseAlreadyAssignedToUser =
                _userExerciseService.CheckIfUserAlreadyHasExercise(allUserExercises, userExercise);

            if (userExerciseAlreadyAssignedToUser is not null)
                throw new ExerciseAlreadyAssignedToUserException(command.UserId, existingExerciseId.Value);

            await _userExerciseRepository.AddAsync(userExercise);
            return;
        }

        await _exerciseRepository.AddAsync(exercise);
        userExercise = new UserExercise(exercise.Id, command.UserId);
        await _userExerciseRepository.AddAsync(userExercise);
    }
}