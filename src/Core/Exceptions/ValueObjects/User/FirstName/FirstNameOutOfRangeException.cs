using Core.Exceptions.Common;

namespace Core.Exceptions.ValueObjects.User.FirstName;

public class FirstNameOutOfRangeException : StringPropertyOutOfRangeException
{
    public FirstNameOutOfRangeException(string firstName, int maxLenght) : base(firstName,maxLenght,$"First name: {firstName} is too long, max lenght is: {maxLenght}") { }
}