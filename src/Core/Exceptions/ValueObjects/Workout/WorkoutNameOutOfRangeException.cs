using Core.Exceptions.Utils;

namespace Core.Exceptions.ValueObjects.Workout;

public class WorkoutNameOutOfRangeException : StringPropertyOutOfRangeException
{
    public WorkoutNameOutOfRangeException(string value, int maxLenght) : base(value, maxLenght,
        $"Workout name: {value} is too long, max lenght is: {maxLenght}")
    {
    }
}