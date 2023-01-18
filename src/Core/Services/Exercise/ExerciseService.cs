namespace Core.Services.Exercise;

public class ExerciseService : IExerciseService
{
    public Guid? CheckIfExerciseAlreadyExists(IEnumerable<Entities.Exercise> exercises, Entities.Exercise newExercise)
    {
        return exercises.FirstOrDefault(exercise => exercise.Name.Equals(newExercise.Name)
                                                    && exercise.BodyPart.Equals(newExercise.BodyPart)
                                                    && exercise.Category.Equals(newExercise.Category))?.Id;
    }
}