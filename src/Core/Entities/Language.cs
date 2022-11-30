using Core.Enums;

namespace Core.Entities;

public class Language
{
    public LanguageCode Code { get; private set; }
    public string Name { get; private set; }
}