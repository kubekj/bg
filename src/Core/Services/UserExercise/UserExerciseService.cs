namespace Core.Services.UserExercise;

public class UserExerciseService : IUserExerciseService
{
    public Entities.UserExercise? CheckIfUserAlreadyHasExercise(IEnumerable<Entities.UserExercise> userExercises,
        Entities.UserExercise newUserExercise)
    {
        return userExercises.SingleOrDefault(ue =>
            ue.ExerciseId == newUserExercise.ExerciseId && ue.UserId == newUserExercise.UserId);
    }
}