using Core.Exceptions.ValueObjects.Workout;
using Core.SeedWork;

namespace Core.ValueObjects.Workout;

public sealed class WorkoutName : ValueObject
{
    public const int MaxLength = 50;

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
    {
        return firstName.Value;
    }

    public static implicit operator WorkoutName(string value)
    {
        return new(value);
    }

    public override string ToString()
    {
        return Value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}