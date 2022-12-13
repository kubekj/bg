using Core.SeedWork;
using Core.ValueObjects.Properties.Common;
using Core.ValueObjects.Properties.Rating;

namespace Core.Entities;

public class Rating : Entity
{
    public Rating(Guid id) : base(id)
    {
    }

    public Rate Rate { get; private set; }
    public Description Description { get; private set; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public TrainingPlan TrainingPlan { get; private set; }
    public Guid TrainingPlanId { get; private set; }
}