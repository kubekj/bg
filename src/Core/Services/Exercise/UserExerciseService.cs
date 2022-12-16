using Core.Entities;
using Core.ValueObjects.Exercise;

namespace Core.Services.Exercise;

public class UserExerciseService : IUserExerciseService
{
    public bool CheckIfNameAlreadyExists(IEnumerable<UserExercise> userExercises,Guid userId, ExerciseName exerciseName)
    {
        foreach (var exercise in userExercises.Where(e => e.UserId == userId).Select(e => e.Exercise))
        {
            if (exercise.Name.Equals(exerciseName))
            {
                throw new Exception();
            }
        }

        return true;
    }
}