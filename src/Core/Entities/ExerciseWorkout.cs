namespace Core.Entities;

public class ExerciseWorkout
{
    public ExerciseWorkout(Guid exerciseId, Guid workoutId, IEnumerable<Set> sets)
    {
        ExerciseId = exerciseId;
        WorkoutId = workoutId;
        Sets = sets;
    }
    
    private ExerciseWorkout(Guid exerciseId, Guid workoutId)
    {
        ExerciseId = exerciseId;
        WorkoutId = workoutId;
        Sets = new HashSet<Set>();
    }

    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; }
    public Workout Workout { get; private set; }
    public Guid WorkoutId { get; }
    public IEnumerable<Set> Sets { get; }
}