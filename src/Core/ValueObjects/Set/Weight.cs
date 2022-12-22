using Core.Exceptions.ValueObjects.Set;
using Core.SeedWork;

namespace Core.ValueObjects.Set;

public class Weight : ValueObject
{
    public const int MaxWeight = 500;

    public Weight(double value)
    {
        if (value > MaxWeight)
            throw new InvalidWeightException(value, MaxWeight);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Weight weight)
    {
        return weight.Value;
    }

    public static implicit operator Weight(int value)
    {
        return new Weight(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}