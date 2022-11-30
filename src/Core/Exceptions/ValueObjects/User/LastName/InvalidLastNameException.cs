namespace Core.Exceptions.ValueObjects.User.LastName;

public class InvalidLastNameException : CoreException
{
    public InvalidLastNameException() : base("Last name should contain value !")
    {
    }
}