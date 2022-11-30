using Core.SeedWork;
using Core.ValueObjects.User;

namespace Core.Entities;

public abstract class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    protected User(Guid id,FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}