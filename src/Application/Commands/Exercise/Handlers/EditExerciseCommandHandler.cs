using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Commands.Exercise.Handlers;

public class EditExerciseCommandHandler : ICommandHandler<EditExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserExerciseRepository _userExerciseRepository;

    public EditExerciseCommandHandler(IExerciseRepository exerciseRepository, 
        IUserExerciseRepository userExerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userExerciseRepository = userExerciseRepository;
    }

    public async Task HandleAsync(EditExerciseCommand command)
    {
        var userExercise = await _userExerciseRepository.GetByIdAsync(command.UserId,command.ExerciseId);

        if (userExercise is null)
            return;

        var otherUsersExercises = await _userExerciseRepository
            .GetAllAsync(x => x.ExerciseId == command.ExerciseId && x.UserId != command.UserId);

        if (otherUsersExercises.Any())
        {
            var copiedExercise = userExercise.Exercise.CreateCopyForUser(command.ExerciseDto.Name,command.ExerciseDto.BodyPart,command.ExerciseDto.Category);
            await _exerciseRepository.AddAsync(copiedExercise);

            var newUserExercise = new UserExercise(copiedExercise.Id, command.UserId);
            await _userExerciseRepository.AddAsync(newUserExercise);
            
            return;
        }

        var exercise = command.ExerciseDto.Adapt<Core.Entities.Exercise>();
        await _exerciseRepository.EditAsync(exercise);
    }
}