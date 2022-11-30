using Core.ValueObjects.User;

namespace Core.Entities;

public class Trainer : User
{
    public Trainer(Guid id, FirstName firstName, LastName lastName, Email email) : base(id,firstName, lastName, email)
    {
    }
}