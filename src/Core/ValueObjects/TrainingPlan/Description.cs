using Core.Exceptions.ValueObjects.TrainingPlan.Description;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public class Description : ValueObject
{
    public const int MaxLength = 250;
    
    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            throw new InvalidDescriptionException();

        if (value.Length > MaxLength)
            throw new DescriptionOutOfRangeException(value, MaxLength);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(Description description)
        => description.Value;

    public static implicit operator Description(string value)
        => new(value);
    
    public override string ToString() => Value;
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}