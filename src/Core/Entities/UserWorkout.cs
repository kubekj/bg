namespace Core.Entities;

public class UserWorkout
{
    public Guid WorkoutId { get; private set; }
    public Workout Workout { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
}