using Core.Exceptions;

namespace Application.Exceptions;

public class CannotAddWorkoutToPastDateException : CoreException
{
    public CannotAddWorkoutToPastDateException() : base("You cannot add workout in the past")
    {
    }
}