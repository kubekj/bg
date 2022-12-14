using Core.Exceptions.ValueObjects.Set;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.Set;

public class Repetition : ValueObject
{
    public const int MinRepetition = 1;
    public const int MaxRepetition = 1000;

    public Repetition(int value)
    {
        if (value is < MinRepetition or > MaxRepetition)
            throw new InvalidRepetitionNumberException(value, MinRepetition, MaxRepetition);

        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(Repetition languageName)
    {
        return languageName.Value;
    }

    public static implicit operator Repetition(int value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}