namespace Core.Entities;

public class ExerciseWorkout
{
    public ExerciseWorkout(Guid exerciseId, Guid workoutId)
    {
        ExerciseId = exerciseId;
        WorkoutId = workoutId;
    }

    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; private set; }
    public Workout Workout { get; private set; }
    public Guid WorkoutId { get; private set; }
}