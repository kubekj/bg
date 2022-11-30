namespace Core.Exceptions.ValueObjects.User;

public class InvalidFirstNameException : CoreException
{
    public InvalidFirstNameException() : base("First name should contain value !")
    {
    }
}