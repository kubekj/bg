using Core.SeedWork;

namespace Core.Entities;

public class Goal : Entity
{
    public Goal(Guid id, string value) : base(id)
    {
        Value = value;
    }

    public string Value { get; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
}