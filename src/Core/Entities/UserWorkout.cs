namespace Core.Entities;

public class UserWorkout
{
    public UserWorkout(Guid workoutId, Guid userId)
    {
        WorkoutId = workoutId;
        UserId = userId;
        UserWorkoutSessions = new HashSet<UserWorkoutSession>();
    }

    public Guid WorkoutId { get; }
    public Workout Workout { get; private set; }
    public Guid UserId { get; }
    public User User { get; private set; }
    public IEnumerable<UserWorkoutSession> UserWorkoutSessions { get; }
}