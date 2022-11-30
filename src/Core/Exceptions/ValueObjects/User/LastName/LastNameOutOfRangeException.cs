using Core.Exceptions.Common;

namespace Core.Exceptions.ValueObjects.User.LastName;

public class LastNameOutOfRangeException : StringPropertyOutOfRangeException
{
    public LastNameOutOfRangeException(string lastName, int maxLenght) : base(lastName, maxLenght, $"Last name: {lastName} is too long, max lenght is: {maxLenght}")
    {
    }
}