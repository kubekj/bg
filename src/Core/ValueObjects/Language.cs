using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.Properties.Language;

namespace Core.ValueObjects;

public class Language : ValueObject
{
    public static Language English() => new(LanguageCode.Eng, LanguageName.English);
    public static Language Polish() => new(LanguageCode.Pol, LanguageName.Polish);

    private Language(LanguageCode code, LanguageName name)
    {
        Code = code;
        Name = name;
    }
    
    public LanguageCode Code { get; private set; }
    public LanguageName Name { get; private set; }
    
    public static implicit operator string(Language language)
        => language.Name;

    public static implicit operator Language(LanguageCode languageCode) =>
        languageCode switch
        {
            LanguageCode.Eng => new Language(languageCode, LanguageName.English),
            LanguageCode.Pol => new Language(languageCode, LanguageName.Polish),
            _ => throw new ArgumentOutOfRangeException(nameof(languageCode), languageCode, $"Language code: {languageCode} not supported")
        };

    public override string ToString() => $"{Code}: {Name}";
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Name;
    }
}