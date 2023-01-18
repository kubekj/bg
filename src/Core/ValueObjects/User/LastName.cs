using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public class LastName : ValueObject
{
    public const int MaxLength = 50;

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            throw new InvalidLastNameException();

        if (value.Length > MaxLength)
            throw new LastNameOutOfRangeException(value, MaxLength);

        Value = value;
    }

    public string Value { get; set; }

    public static implicit operator string(LastName lastName)
    {
        return lastName.Value;
    }

    public static implicit operator LastName(string value)
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