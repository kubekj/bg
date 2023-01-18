using Core.Exceptions.ValueObjects.TrainingPlan.Status;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.TrainingPlan;

public class Status : ValueObject
{
    public const string Draft = nameof(Draft);
    public const string Active = nameof(Active);
    public const string InActive = nameof(InActive);

    public Status(string value)
    {
        if (value is not (Active or Draft or InActive))
            throw new IncorrectStatusException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(Status status)
    {
        return status.Value;
    }

    public static implicit operator Status(string value)
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