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
    
    public Set(Guid id, Repetition repetitions, Weight weight, Guid exerciseId, Guid workoutId) : base(id)
    {
        Repetitions = repetitions;
        Weight = weight;
        ExerciseId = exerciseId;
        WorkoutId = workoutId;
    }

    public Repetition Repetitions { get; }
    public Weight Weight { get; }

    public ExerciseWorkout ExerciseWorkout { get; private set; }
    public Guid ExerciseId { get; private set; }
    public Guid WorkoutId { get; private set; }
}