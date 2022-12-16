namespace Core.Exceptions.Utils;

public abstract class StringPropertyOutOfRangeException : CoreException
{
    public StringPropertyOutOfRangeException(string value, int maxLenght, string message) : base(message)
    {
        Value = value;
        MaxLenght = maxLenght;
    }

    public string Value { get; }
    public int MaxLenght { get; }
}