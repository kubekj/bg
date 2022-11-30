using Core.SeedWork;
using Core.ValueObjects.User;

namespace Core.Entities;

public class Athlete : User
{
    public Athlete(Guid id, FirstName firstName, LastName lastName, Email email) : base(id, firstName, lastName, email)
    {
    }
}