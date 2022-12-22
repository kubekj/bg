using Core.Entities;

namespace Core.Services.Exercise;

public class UserExerciseService : IUserExerciseService
{
    public UserExercise? CheckIfUserAlreadyHasExercise(IEnumerable<UserExercise> userExercises,
        UserExercise newUserExercise)
    {
        return userExercises.SingleOrDefault(ue =>
            ue.ExerciseId == newUserExercise.ExerciseId && ue.UserId == newUserExercise.UserId);
    }
}