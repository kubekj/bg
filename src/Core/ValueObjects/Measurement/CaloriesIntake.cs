using Core.Exceptions.ValueObjects.Measurement;
using Core.SeedWork;

namespace Core.ValueObjects.Measurement;

public class CaloriesIntake : ValueObject
{
    public const int MaxAmount = 10000;

    public CaloriesIntake(int value)
    {
        if (value > MaxAmount)
            throw new InvalidCaloriesIntakeException(value);

        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(CaloriesIntake caloriesIntake)
    {
        return caloriesIntake.Value;
    }

    public static implicit operator CaloriesIntake(int value)
    {
        return new(value);
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}