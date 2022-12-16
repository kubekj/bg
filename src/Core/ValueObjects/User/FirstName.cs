using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            throw new InvalidFirstNameException();

        if (value.Length > MaxLength)
            throw new FirstNameOutOfRangeException(value, MaxLength);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(FirstName firstName)
    {
        return firstName.Value;
    }

    public static implicit operator FirstName(string value)
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