using Core.Enums;
using Core.ValueObjects.User;

namespace Core.Entities;

public class Trainer : User
{
    public Trainer(Guid id, FirstName firstName, LastName lastName, Email email, Password password, Role role, DateTime createdAt) : base(id, firstName, lastName, email, password, role, createdAt)
    {
    }
}