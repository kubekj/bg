using Core.Exceptions.Utils;

namespace Core.Exceptions.Shared.Description;

public class DescriptionOutOfRangeException : StringPropertyOutOfRangeException
{
    public DescriptionOutOfRangeException(string value, int maxLenght) : base(value, maxLenght,
        $"Description: {value} is too long, max lenght is: {maxLenght}")
    {
    }
}