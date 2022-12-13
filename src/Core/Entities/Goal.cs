using Core.SeedWork;

namespace Core.Entities;

public class Goal : Entity
{
    public Goal(Guid id) : base(id)
    {
    }

    public string Value { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
}