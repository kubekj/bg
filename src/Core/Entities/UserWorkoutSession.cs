namespace Core.Entities;

public class UserWorkoutSession
{
    public Guid UserId { get; private set; }
    public Guid WorkoutId { get; private set; }
    public UserWorkout UserWorkout { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsDone { get; private set; }
}