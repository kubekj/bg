namespace Core.Exceptions.Shared;

public class IncorrectBodyPartException : CoreException
{
    public IncorrectBodyPartException(string value) : base($"Body part: {value} is not supported") => Value = value;

    public string Value { get; }
}