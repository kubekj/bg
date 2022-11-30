using Core.Exceptions.ValueObjects.TrainingPlan.Duration;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public record Duration : ValueObject
{
    //Weeks
    public const int MaxDuration = 20;
    
    public Duration(double value)
    {
        if (MaxDuration < value)
            throw new TooLongTrainingPlanException(value,MaxDuration);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Duration title)
        => title.Value;

    public static implicit operator Duration(double value)
        => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}