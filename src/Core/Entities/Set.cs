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

    public Repetition Repetitions { get; }
    public Weight Weight { get; }

    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; private set; }
}