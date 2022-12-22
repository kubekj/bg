namespace Core.Services.Exercise;

public interface IExerciseService
{
    public Guid? CheckIfExerciseAlreadyExists(IEnumerable<Entities.Exercise> exercises, Entities.Exercise newExercise);
}