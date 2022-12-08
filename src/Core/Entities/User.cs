using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.User;

namespace Core.Entities;

public class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Role Role { get; private set; }

    public User(Guid id,FirstName firstName, LastName lastName, Email email, Password password, DateTime createdAt, Role role) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Role = role;
    }
}