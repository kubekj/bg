using Core.Exceptions.ValueObjects.TrainingPlan.Status;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public class Status : ValueObject
{
    public const string Active = nameof(Active);
    public const string Unpublished = nameof(Unpublished);
    public const string Published = nameof(Published);

    public Status(string value)
    {
        if (value is not (Active or Unpublished or Published))
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
        return new Status(value);
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