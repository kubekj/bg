using Core.Exceptions.ValueObjects.Workout;
using Core.SeedWork;

namespace Core.ValueObjects.Workout;

public record WorkoutName : ValueObject
{
    private const int MaxLength = 50;
    
    public WorkoutName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            throw new InvalidWorkoutNameException();

        if (value.Length > MaxLength)
            throw new WorkoutNameOutOfRangeException(value, MaxLength);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(WorkoutName firstName)
        => firstName.Value;

    public static implicit operator WorkoutName(string value)
        => new(value);
    
    public override string ToString() => Value;
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}