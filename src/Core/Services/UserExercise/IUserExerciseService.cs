namespace Core.Services.UserExercise;

public interface IUserExerciseService
{
    public Entities.UserExercise? CheckIfUserAlreadyHasExercise(IEnumerable<Entities.UserExercise> userExercises,
        Entities.UserExercise newUserExercise);
}