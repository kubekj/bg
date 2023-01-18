using Core.Exceptions.Utils;

namespace Core.Exceptions.ValueObjects.User;

public class LastNameOutOfRangeException : StringPropertyOutOfRangeException
{
    public LastNameOutOfRangeException(string lastName, int maxLenght) : base(lastName, maxLenght,
        $"Last name: {lastName} is too long, max lenght is: {maxLenght}")
    {
    }
}