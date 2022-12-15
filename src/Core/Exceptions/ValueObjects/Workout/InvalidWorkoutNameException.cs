namespace Core.Exceptions.ValueObjects.Workout;

public class InvalidWorkoutNameException : CoreException
{
    public InvalidWorkoutNameException() : base("Workout name cannot be empty !")
    {
    }
}