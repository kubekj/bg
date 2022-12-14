namespace Core.Exceptions.ValueObjects.Language;

internal class IncorrectLanguageNameException : CoreException
{
    public IncorrectLanguageNameException(string languageName) : base($"Language name {languageName} not supported")
    {
        LanguageName = languageName;
    }

    public string LanguageName { get; }
}