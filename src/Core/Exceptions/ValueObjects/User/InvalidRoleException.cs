namespace Core.Exceptions.ValueObjects.User;

public sealed class InvalidRoleException : CoreException
{
    public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
    {
        Role = role;
    }

    public string Role { get; }
}