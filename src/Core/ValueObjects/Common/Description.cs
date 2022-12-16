using Core.Exceptions.Shared.Description;
using Core.SeedWork;

namespace Core.ValueObjects.Common;

public sealed class Description : ValueObject
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
    {
        return description.Value;
    }

    public static implicit operator Description(string value)
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