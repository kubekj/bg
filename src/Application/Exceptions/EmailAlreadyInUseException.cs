using Core.Exceptions;

namespace Application.Exceptions;

public class EmailAlreadyInUseException : CoreException
{
    public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.")
    {
        Email = email;
    }

    public string Email { get; }
}