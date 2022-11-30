namespace Core.Exceptions.ValueObjects.User.FirstName;

public class InvalidFirstNameException : CoreException
{
    public InvalidFirstNameException() : base("First name should contain value !")
    {
    }
}