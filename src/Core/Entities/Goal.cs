using Core.SeedWork;

namespace Core.Entities;

public class Goal : Entity
{
    public Goal(Guid id, int value, Guid userId) : base(id)
    {
        Month = DateTime.Now.Month;
        Value = value;
        UserId = userId;
    }

    public void EditGoal(int value)
    {
        Value = value;
    }
    public int Month { get; }
    public int Value { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
}