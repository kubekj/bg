namespace Core.Exceptions.ValueObjects.User;

public class InvalidEmailException : CoreException
{
    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }

    public string Email { get; }
}