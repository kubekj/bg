using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Rating;

namespace Core.Entities;

public class Rating : Entity
{
    public Rating(Guid id, Rate rate, Description description, Guid userId, Guid trainingPlanId) : base(id)
    {
        Rate = rate;
        Description = description;
        UserId = userId;
        TrainingPlanId = trainingPlanId;
    }

    public Rate Rate { get; }
    public Description Description { get; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public TrainingPlan TrainingPlan { get; private set; }
    public Guid TrainingPlanId { get; private set; }
}