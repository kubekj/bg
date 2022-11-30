using Core.Exceptions.Common;

namespace Core.Exceptions.ValueObjects.Workout;

public class WorkoutNameOutOfRangeException : StringPropertyOutOfRangeException
{
    public WorkoutNameOutOfRangeException(string value, int maxLenght) : base(value, maxLenght, $"")
    {
    }
}