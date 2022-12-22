using Core.Exceptions.ValueObjects.TrainingPlan.Duration;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public sealed class Duration : ValueObject
{
    //Weeks
    public const int MaxDuration = 20;

    public Duration(double value)
    {
        if (MaxDuration < value)
            throw new TooLongTrainingPlanException(value, MaxDuration);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Duration title)
    {
        return title.Value;
    }

    public static implicit operator Duration(double value)
    {
        return new Duration(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}