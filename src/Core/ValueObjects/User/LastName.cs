using Core.Exceptions.ValueObjects.User.LastName;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public class LastName : ValueObject
{
    private const int MaxLength = 50;
    
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
        => lastName.Value;

    public static implicit operator LastName(string value)
        => new(value);
    
    public override string ToString() => Value;
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}