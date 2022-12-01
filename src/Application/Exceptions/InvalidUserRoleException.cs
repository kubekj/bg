using Core.Exceptions;

namespace Application.Exceptions;

public class InvalidUserRoleException : CoreException
{
    public InvalidUserRoleException() : base("Provided user role does not exists")
    {
    }
}