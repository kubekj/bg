using Core.Exceptions;

namespace Application.Exceptions;

public class EmailAlreadyInUseException : CoreException
{
    public string Email { get; }

    public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.") => Email = email;
}