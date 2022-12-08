using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.User;

public class Role : ValueObject
{
    public static IEnumerable<string> AvailableRoles { get; } = new[] {"athlete", "trainer"};

    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
            throw new InvalidRoleException(value);

        if (!AvailableRoles.Contains(value))
            throw new InvalidRoleException(value);

        Value = value;
    }

    public static Role Athlete() => new("athlete");
    
    public static Role Trainer() => new("trainer");

    public static implicit operator Role(string value) => new(value);

    public static implicit operator string(Role value) => value.Value;

    public override string ToString() => Value;
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}