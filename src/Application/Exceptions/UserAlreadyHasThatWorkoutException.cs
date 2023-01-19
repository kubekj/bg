using Core.Exceptions;
using Core.ValueObjects.Workout;

namespace Application.Exceptions;

public class UserAlreadyHasThatWorkoutException : CoreException
{
    public UserAlreadyHasThatWorkoutException(WorkoutName workoutName) : base($"Workout with that name: {workoutName} is already on your list")
    {
    }
}