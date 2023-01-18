namespace Core.Entities;

public class UserExercise
{
    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
}