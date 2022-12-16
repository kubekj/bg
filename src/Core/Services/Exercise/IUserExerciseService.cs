using Core.Entities;
using Core.ValueObjects.Exercise;

namespace Core.Services.Exercise;

public interface IUserExerciseService
{
    public bool CheckIfNameAlreadyExists(IEnumerable<UserExercise> userExercises,Guid userId, ExerciseName exerciseName);
}