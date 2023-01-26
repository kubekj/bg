namespace Core.Entities;

public class TrainingPlanWorkout
{
    public TrainingPlanWorkout(Guid trainingPlanId, Guid workoutId)
    {
        TrainingPlanId = trainingPlanId;
        WorkoutId = workoutId;
    }

    public TrainingPlan TrainingPlan { get; private set; }
    public Guid TrainingPlanId { get; private set; }
    public Workout Workout { get; private set; }
    public Guid WorkoutId { get; private set; }
    public bool IsCompleted { get; }
}