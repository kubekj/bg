namespace Core.Entities;

public class ExerciseWorkout
{
    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; private set; }
    public Workout Workout { get; private set; }
    public Guid WorkoutId { get; private set; }
}