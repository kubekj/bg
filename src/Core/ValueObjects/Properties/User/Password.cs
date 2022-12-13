using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.User;

public sealed class Password : ValueObject
{
    public string Value { get; }
        
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 200 or < 6)
            throw new InvalidPasswordException();

        Value = value;
    }

    public static implicit operator Password(string value) => new(value);

    public static implicit operator string(Password value) => value.Value;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}