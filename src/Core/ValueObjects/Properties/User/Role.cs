using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.User;

public class Role : ValueObject
{
    public const int MaxLenght = 30;

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
            throw new InvalidRoleException(value);

        if (!AvailableRoles.Contains(value))
            throw new InvalidRoleException(value);

        if (value.Length > MaxLenght)
            throw new InvalidRoleException(value);

        Value = value;
    }

    public static IEnumerable<string> AvailableRoles { get; } = new[] { "athlete", "trainer" };

    public string Value { get; }

    public static Role Athlete()
    {
        return new("athlete");
    }

    public static Role Trainer()
    {
        return new("trainer");
    }

    public static implicit operator Role(string value)
    {
        return new(value);
    }

    public static implicit operator string(Role value)
    {
        return value.Value;
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