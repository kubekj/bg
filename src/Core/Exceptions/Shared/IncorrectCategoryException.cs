namespace Core.Exceptions.Shared;

public class IncorrectCategoryException : CoreException
{
    public IncorrectCategoryException(string value) : base($"Category: {value} not supported")
    {
        Value = value;
    }

    public string Value { get; }
}