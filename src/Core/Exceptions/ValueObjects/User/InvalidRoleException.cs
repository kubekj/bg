namespace Core.Exceptions.ValueObjects.User;

public sealed class InvalidRoleException : CoreException
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.") => Role = role;
}