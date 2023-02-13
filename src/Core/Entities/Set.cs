using Core.SeedWork;
using Core.ValueObjects.Set;

namespace Core.Entities;

public class Set : Entity
{
    public Set(Guid id, Repetition repetitions, Weight weight) : base(id)
    {
        Repetitions = repetitions;
        Weight = weight;
    }
    
    public Set(Guid id, Repetition repetitions, Weight weight, Guid workoutId ,Guid exerciseId) : base(id)
    {
        Repetitions = repetitions;
        Weight = weight;
        WorkoutId = workoutId;
        ExerciseId = exerciseId;
    }

    public void Update(Repetition repetitions, Weight weight, Guid workoutId ,Guid exerciseId)
    {
        Repetitions = repetitions;
        Weight = weight;
        WorkoutId = workoutId;
        ExerciseId = exerciseId;
    }

    public Repetition Repetitions { get; private set; }
    public Weight Weight { get; private set; }

    public ExerciseWorkout ExerciseWorkout { get; private set; }
    public Guid WorkoutId { get; private set; }
    public Guid ExerciseId { get; private set; }
}