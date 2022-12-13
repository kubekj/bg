using Core.SeedWork;
using Core.ValueObjects.Properties.Set;

namespace Core.Entities;

public class Set : Entity
{
    public Set(Guid id, Repetition repetitions, Weight weight) : base(id)
    {
        Repetitions = repetitions;
        Weight = weight;
    }
    
    public Repetition Repetitions { get; private set; }
    public Weight Weight { get; private set; }
    
    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; private set; }
}