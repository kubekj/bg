using Core.Entities;

namespace Core.Services.Exercise;

public interface IUserExerciseService
{
    public UserExercise? CheckIfUserAlreadyHasExercise(IEnumerable<UserExercise> userExercises,
        UserExercise newUserExercise);
}