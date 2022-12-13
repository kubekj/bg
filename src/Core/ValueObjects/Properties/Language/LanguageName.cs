using Core.Exceptions.ValueObjects.Language;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.Language;

public class LanguageName : ValueObject
{
    public string Value { get; }

    public const string Polish = nameof(Polish);
    public const string English = nameof(English);

    private LanguageName(string value)
    {
        if (value is not (Polish or English))
            throw new IncorrectLanguageNameException(value);

        Value = value;
    }

    public static implicit operator string(LanguageName languageName)
        => languageName.Value;

    public static implicit operator LanguageName(string value)
        => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}