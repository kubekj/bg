namespace Core.Entities;

public class UserExercise
{
    public UserExercise(Guid exerciseId, Guid userId)
    {
        ExerciseId = exerciseId;
        UserId = userId;
    }

    public Exercise Exercise { get; private set; }
    public Guid ExerciseId { get; }
    public User User { get; private set; }
    public Guid UserId { get; }
}