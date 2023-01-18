using Core.Exceptions.ValueObjects.Measurement;
using Core.SeedWork;

namespace Core.ValueObjects.Measurement;

public class BodyWeight : ValueObject
{
    public const int MaxWeight = 200;

    public BodyWeight(double value)
    {
        if (value > MaxWeight)
            throw new IncorrectBodyWeightException(value);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(BodyWeight bodyWeight)
    {
        return bodyWeight.Value;
    }

    public static implicit operator BodyWeight(double value)
    {
        return new BodyWeight(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}