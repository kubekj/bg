namespace Core.Entities;

public class UserTrainingPlan
{
    public UserTrainingPlan(Guid userId, Guid trainingPlanId)
    {
        UserId = userId;
        TrainingPlanId = trainingPlanId;
        BoughtAt = DateTime.Now;
    }
    public TrainingPlan TrainingPlan { get; private set; }
    public Guid TrainingPlanId { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime? From { get; private set; }
    public DateTime? To { get; private set; }
    public DateTime BoughtAt { get; private set; }
}