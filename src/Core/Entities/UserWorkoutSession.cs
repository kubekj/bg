namespace Core.Entities;

public class UserWorkoutSession
{
    public UserWorkoutSession(Guid userId, Guid workoutId, DateTime date)
    {
        UserId = userId;
        WorkoutId = workoutId;
        Date = date;
        IsDone = false;
    }

    public void Edit(Guid workoutId)
    {
        WorkoutId = workoutId;
    }

    public Guid UserId { get; private set; }
    public Guid WorkoutId { get; private set; }
    public UserWorkout UserWorkout { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsDone { get; private set; }
}