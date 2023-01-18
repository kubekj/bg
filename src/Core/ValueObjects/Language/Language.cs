using Core.Exceptions.ValueObjects.Language;
using Core.SeedWork;

namespace Core.ValueObjects.Language;

public class Language : ValueObject
{
    public const string Polish = nameof(Polish);
    public const string English = nameof(English);

    public Language(string value)
    {
        if (value is not (Polish or English))
            throw new IncorrectLanguageNameException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(Language language)
    {
        return language.Value;
    }

    public static implicit operator Language(string value)
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