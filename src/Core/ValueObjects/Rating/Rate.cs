using Core.Exceptions.ValueObjects.Rate;
using Core.SeedWork;

namespace Core.ValueObjects.Rating;

public class Rate : ValueObject
{
    public const int MinRate = 1;
    public const int MaxRate = 5;

    public Rate(int value)
    {
        if (value is < MinRate or > MaxRate)
            throw new InvalidRateException(value, MinRate, MaxRate);

        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(Rate rate)
    {
        return rate.Value;
    }

    public static implicit operator Rate(int value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}