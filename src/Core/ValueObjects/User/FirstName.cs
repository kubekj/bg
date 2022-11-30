using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public sealed record FirstName : ValueObject
{
    private const int MaxLength = 50;
    
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
        => firstName.Value;

    public static implicit operator FirstName(string value)
        => new(value);
    
    public override string ToString() => Value;
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}