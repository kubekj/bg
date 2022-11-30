using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.User;

namespace Core.Entities;

public abstract class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public HashSet<Role> Roles { get; private set; } = new();
    public DateTime CreatedAt { get; private set; }

    protected User(Guid id,FirstName firstName, LastName lastName, Email email, Password password, Role role, DateTime createdAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Roles.Add(role);
        CreatedAt = createdAt;
    }
}