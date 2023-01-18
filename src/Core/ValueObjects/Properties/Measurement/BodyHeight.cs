using Core.Exceptions.ValueObjects.Measurement;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.Measurement;

public class BodyHeight : ValueObject
{
    public const int MaxHeight = 250;

    public BodyHeight(double value)
    {
        if (value > MaxHeight)
            throw new InvalidBodyHeightException(value);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(BodyHeight bodyHeight)
    {
        return bodyHeight.Value;
    }

    public static implicit operator BodyHeight(double value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}