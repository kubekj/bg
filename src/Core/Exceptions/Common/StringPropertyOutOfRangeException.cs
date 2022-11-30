namespace Core.Exceptions.Common;

public abstract class StringPropertyOutOfRangeException : CoreException
{
    public string Value { get; }
    public int MaxLenght { get; }
    
    public StringPropertyOutOfRangeException(string value, int maxLenght,string message) : base(message)
    {
        Value = value;
        MaxLenght = maxLenght;
    }
}