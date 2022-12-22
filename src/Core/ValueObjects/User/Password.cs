using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public sealed class Password : ValueObject
{
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 200 or < 6)
            throw new InvalidPasswordException();

        Value = value;
    }

    public string Value { get; }

    public static implicit operator Password(string value)
    {
        return new(value);
    }

    public static implicit operator string(Password value)
    {
        return value.Value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}