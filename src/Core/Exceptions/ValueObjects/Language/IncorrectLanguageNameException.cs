namespace Core.Exceptions.ValueObjects.Language;

internal class IncorrectLanguageNameException : CoreException
{
    public string LanguageName { get; }
    public IncorrectLanguageNameException(string languageName) : base($"Language name {languageName} not supported") 
        => LanguageName = languageName;
}