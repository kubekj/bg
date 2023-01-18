namespace Core.Entities;

public class UserWorkoutSession
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid WorkoutId { get; set; }
    public Workout Workout { get; set; }
    public DateTime Date { get; set; }
}