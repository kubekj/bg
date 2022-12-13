using System.Text.RegularExpressions;
using Core.Exceptions.ValueObjects.User;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.User;

public sealed class Email : ValueObject
{
    public const int MaxLenght = 100;
    
    private static readonly Regex Regex = new(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled);
        
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException(value);

        if (value.Length > MaxLenght)
            throw new InvalidEmailException(value);

        value = value.ToLowerInvariant();
        
        if (!Regex.IsMatch(value))
            throw new InvalidEmailException(value);

        Value = value;
    }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);
        
    public override string ToString() => Value;
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}