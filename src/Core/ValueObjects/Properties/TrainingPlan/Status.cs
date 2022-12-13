using Core.Exceptions.ValueObjects.TrainingPlan.Status;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.TrainingPlan;

public class Status : ValueObject
{
    public string Value { get; }

    public const string Draft = nameof(Draft);
    public const string Active = nameof(Active);
    public const string InActive = nameof(InActive);

    private Status(string value)
    {
        if (value is not (Active or Draft or InActive))
            throw new IncorrectStatusException(value);

        Value = value;
    }

    public static implicit operator string(Status status)
        => status.Value;

    public static implicit operator Status(string value)
        => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}