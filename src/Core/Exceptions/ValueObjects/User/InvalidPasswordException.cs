namespace Core.Exceptions.ValueObjects.User;

public sealed class InvalidPasswordException : CoreException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}