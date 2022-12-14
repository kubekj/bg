using Core.SeedWork;
using Core.ValueObjects.Properties.Common;
using Core.ValueObjects.Properties.Rating;

namespace Core.Entities;

public class Rating : Entity
{
    public Rating(Guid id, Rate rate, Description description) : base(id)
    {
        Rate = rate;
        Description = description;
    }

    public Rate Rate { get; }
    public Description Description { get; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public TrainingPlan TrainingPlan { get; private set; }
    public Guid TrainingPlanId { get; private set; }
}